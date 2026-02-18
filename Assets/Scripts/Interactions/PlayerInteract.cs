using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange); 
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact(); 
                }
            }
        }
    }

    public NPCInteractable GetInteractableObject()
    {
        float interactRange = 1f; 
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange); 
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    return npcInteractable; 
                }
        }
        return null; 
            
    }
}
