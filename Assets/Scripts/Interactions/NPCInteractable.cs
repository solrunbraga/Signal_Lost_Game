using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
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
}
