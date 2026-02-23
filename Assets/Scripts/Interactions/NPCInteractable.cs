using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
using Ink.Runtime;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField]
    private string interactText; 
    [Header("Ink JSON")]
    [SerializeField]
    private TextAsset inkJSON; //ink story 

    [SerializeField]
    private string npcKnotName; // assign in inspector
    private Animator animator; 

    

    private void Awake()
    {
        animator = GetComponent<Animator>(); 

    }
    public void Interact()
    {
        Debug.Log("Interact!"); 

        animator.SetTrigger("Talk"); 
        //start the dialouge from specific knot in story
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, npcKnotName); 


    }

    public string GetInteractText()
    {
        return interactText; 
    }


}
