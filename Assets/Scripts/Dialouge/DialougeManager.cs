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

    private TextMeshProUGUI[] choicesText; 

    private Story currentStory; 

    public bool dialougeIsPlaying { get; private set;}

    private static DialogueManager instance; 

    private const string SPEAKER_TAG = "speaker"; 

    private int currentChoiceCount = 0; 

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory(); 
        }
        
    }

    public void EnterDialogueMode(TextAsset inkJSON, string knotName)
    {
        currentStory = new Story(inkJSON.text); 
        currentStory.ChoosePathString(knotName); //start from a specific knot in the ink story file
        dialougeIsPlaying = true; 
        dialougePanel.SetActive(true); 
        
        ContinueStory(); 
    }

    private IEnumerator ExitDialogueMode()
    {
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

        //chacking if UI can support the number of choices coming in 
        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices where given than the UI can support. number of choices given;" + currentChoices.Count); 
        }

        int index = 0; 
        //enable and initialize the choices to the amount in the ink story 
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true); 
            choicesText[index].text = choice.text; 
            index++; 
        }
        for (int i = 0; i < currentChoices.Count; i++)
        {
            int choiceIndex = i; // Capture variable for closure
            choices[i].SetActive(true);
            choicesText[i].text = currentChoices[i].text;

            // Remove previous listeners if any
            UnityEngine.UI.Button button = choices[i].GetComponent<UnityEngine.UI.Button>();
            button.onClick.RemoveAllListeners();

            // Add new listener
            button.onClick.AddListener(() => MakeChoice(choiceIndex));
        }
        // go through the remaining choices the UI supports and make sure they are hidden 
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false); 
        }
        
        StartCoroutine(SelectFirstChoice()); 
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null); 
        yield return new WaitForEndOfFrame(); 
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject); 
    }

    public void MakeChoice(int choiceIndex)
    {
        if (choiceIndex < 0 || choiceIndex >= currentChoiceCount)
        {
            Debug.LogError("Choice index out of range: " + choiceIndex); 
            return; 
        }
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory(); 
    }

    public void OnChoiceButtonClicked(int index)
    {
        DialogueManager.GetInstance().MakeChoice(index);
    }
}
