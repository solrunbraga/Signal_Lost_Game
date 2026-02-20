using UnityEngine;
using TMPro; 
using System.Collections; 
using System.Collections.Generic; 

public class PlayerInteractUI : MonoBehaviour
{
    [SerializeField]
    private GameObject containerGameObject; 

    [SerializeField]
    private PlayerInteract playerInteract;
    
    [SerializeField]
    private TextMeshProUGUI interactTextMeshProUGUI;

    private void Update()
    {
        // hide UI if dialogue is active 
        if (DialogueManager.GetInstance().IsDialogueActive())
        {
            //skipping UI during Dialogue
            Hide(); 
            return; 
        }
        if (playerInteract.GetInteractableObject() != null)
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }

    private void Show(NPCInteractable npcInteractable)
    {
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = npcInteractable.GetInteractText(); 

    }

    private void Hide()
    {
        containerGameObject.SetActive(false); 
    }


    

}
