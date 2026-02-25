using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; 
using Ink.Runtime; 
using UnityEngine.EventSystems; 

public class DialogueManager : MonoBehaviour
{
    [Header("Dialouge UI")]

    [SerializeField]
    private GameObject dialougePanel;

    [SerializeField]
    private TextMeshProUGUI dialougeText; 

    [SerializeField]
    private TextMeshProUGUI displayNameText; 

    [Header("Choices UI")]
    [SerializeField]
    private GameObject[] choices; 

    [Header("Ink JSON")]
    [SerializeField] 
    private TextAsset inkJSON;

    [SerializeField]
    private MonoBehaviour playerMovementScript; 

    private TextMeshProUGUI[] choicesText; 

    private Story currentStory; 

    public bool dialougeIsPlaying { get; private set;}

    private static DialogueManager instance; 

    private const string SPEAKER_TAG = "speaker"; 

    private int currentChoiceCount = 0; 

    public GameObject itemToReveal; 

    private void Awake()
    {
        if(instance != null)
        {
            //if there are multiple instances of dialouge managers  
            Debug.LogWarning("Found more than one Dialouge Manager in the scene"); 
        }
        
        instance = this; 
    }

    public static DialogueManager GetInstance()
    {
        return instance; 
    }

    private void Start()
    {
        currentStory = new Story(inkJSON.text);
        //quest item not active 
        itemToReveal.SetActive(false); 

        dialougeIsPlaying = false; 
        dialougePanel.SetActive(false); 

        //Get all choices text
        choicesText = new TextMeshProUGUI[choices.Length]; 
        int index = 0; 
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>(); 
            index++; 
        }

    }

    private void Update()
    {
        //Return if dialouge isnt playing right away 
        if (!dialougeIsPlaying)
        {
            return; 
        }

        //handle continue to next line of dialouge when E is pressed
        if (Input.GetKeyDown(KeyCode.Space) && currentStory.currentChoices.Count == 0)
        {
            ContinueStory();
        }
        
    }

    public void EnterDialogueMode(string knotName)
    {
        //disable movement during dialogue
        playerMovementScript.enabled = false;

        currentStory.ChoosePathString(knotName); //start from a specific knot in the ink story file
        dialougeIsPlaying = true; 
        dialougePanel.SetActive(true); 
        
        ContinueStory(); 
    }

    private IEnumerator ExitDialogueMode()
    {
        //enable movement after dialouge ends 
        playerMovementScript.enabled = true;

        Debug.Log("Exiting dialouge");
        yield return new WaitForSeconds(0.2f); 

        dialougeIsPlaying = false; 
        dialougePanel.SetActive(false); 
        dialougeText.text = ""; 
        displayNameText.text = "";
        foreach (var choice in choices)
        {
            choice.SetActive(false);
        }

    }

    private void ContinueStory()
    {
         if (currentStory.canContinue)
        {
            //set text for current dialouge
            dialougeText.text = currentStory.Continue(); 
            //display choices, if any, for this dialouge line 
            DisplayChoices(); 
            //handle Names
            HandleTags(currentStory.currentTags); 
        }
        else
        {
            StartCoroutine(ExitDialogueMode()); 
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        //loop each tag and handle it accordingly 
        foreach (string tag in currentTags)
        {
            //parse tag 
            string[] splitTag = tag.Split(':'); 
            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be appropriatly oarsed; " + tag); 
            }
            string tagKey = splitTag[0].Trim(); 
            string tagValue = splitTag[1].Trim(); 

            //handle tag 
            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue; 
                    break; 
                
                default: 
                Debug.LogWarning("Tag came in but us not currently being handled; " + tag); 
                break; 
            }
        }
    }

    //checking if dialouge is active
    public bool IsDialogueActive()
    {
        return dialougeIsPlaying; 
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        currentChoiceCount = currentChoices.Count;

        // Hide all choice buttons first
        for (int i = 0; i < choices.Length; i++)
        {
            choices[i].SetActive(false);
        }

        // If no choices, stop here
        if (currentChoiceCount == 0)
        {
            return;
        }

        if (currentChoiceCount > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices: " + currentChoiceCount);
        }

        for (int i = 0; i < currentChoiceCount; i++)
        {
            int choiceIndex = i;

            choices[i].SetActive(true);
            choicesText[i].text = currentChoices[i].text;

            UnityEngine.UI.Button button = choices[i].GetComponent<UnityEngine.UI.Button>();
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => MakeChoice(choiceIndex));
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        if (currentChoiceCount == 0)
        {
            yield break; 
        }

        EventSystem.current.SetSelectedGameObject(null); 
        yield return new WaitForEndOfFrame(); 
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject); 
    }

    public void MakeChoice(int choiceIndex)
    {
        if (currentStory.currentChoices.Count == 0)
        {
            Debug.LogWarning("tried to choose but no choices exist."); 
            return; 
        }

        if (choiceIndex < 0 || choiceIndex >= currentChoiceCount)
        {
            Debug.LogError("Choice index out of range: " + choiceIndex); 
            return; 
        }
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(); 
    }

    public void ObserveVariable(string variableName, Story.VariableObserver callback)
    {
        currentStory.ObserveVariable(variableName, callback);
    }
}
