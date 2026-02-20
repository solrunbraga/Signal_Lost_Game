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
    private Animator animator; 

    private void Awake()
    {
        animator = GetComponent<Animator>(); 

    }
    public void Interact()
    {
        Debug.Log("Interact!"); 

        animator.SetTrigger("Talk"); 
        //start the dialouge
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON); 


    }

    public string GetInteractText()
    {
        return interactText; 
    }


}
