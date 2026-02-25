using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 
using Ink.Runtime;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField]
    private string interactText; 

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
        DialogueManager.GetInstance().EnterDialogueMode(npcKnotName); 


    }

    public string GetInteractText()
    {
        return interactText; 
    }


}
