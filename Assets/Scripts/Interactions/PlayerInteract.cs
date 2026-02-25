using UnityEngine;
using System.Collections; 
using System.Collections.Generic; 

public class PlayerInteract : MonoBehaviour
{
    private void Update()
    {
        //prevent interacting when dialogue is active 
        if (DialogueManager.GetInstance().IsDialogueActive())
        {
            return; 
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 1f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.Interact(); 
                    break; //stop after first npc 
                }
            }
        }
    }

    public NPCInteractable GetInteractableObject()
    {
        List<NPCInteractable> npcInteractableList = new List<NPCInteractable>(); 
        float interactRange = 1f; 
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange); 
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractableList.Add(npcInteractable);
                }
        }
        
        NPCInteractable closestNPCInteractable = null; 
        foreach (NPCInteractable npcInteractable in npcInteractableList)
        {
            if (closestNPCInteractable == null)
            {
                closestNPCInteractable = npcInteractable; 
            }
            else
            {
                if (Vector3.Distance(transform.position, npcInteractable.transform.position) < Vector3.Distance(transform.position, closestNPCInteractable.transform.position))
                {
                    //Closer
                    closestNPCInteractable = npcInteractable; 
                }
            }
        }
        return closestNPCInteractable; 
            
    }
}
