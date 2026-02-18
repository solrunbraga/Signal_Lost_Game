using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

public class NPCInteractable : MonoBehaviour
{
    [SerializeField]
    private string interactText; 
    private Animator animator; 

    private void Awake()
    {
        animator = GetComponent<Animator>(); 

    }
    public void Interact()
    {
        Debug.Log("Interact!"); 

        animator.SetTrigger("Talk"); 

    }

    public string GetInteractText()
    {
        return interactText; 
    }


}
