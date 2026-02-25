using UnityEngine;
using System.Collections.Generic; 
using System.Collections; 
using System; 

public class DialougeEvents 
{
    public event Action<string> onEnterDialouge; 

    public void EnterDialouge(string knotName)
    {
        if (onEnterDialouge != null)
        {
            onEnterDialouge(knotName); 
        }
    }

    public event Action onDialogueStarted; 

    public void DialougeStarted()
    {
        if (onDialogueStarted != null)
        {
            onDialogueStarted(); 
        }
    }

    public event Action onDialogueFinished; 

    public void DialogueFinished()
    {
        if (onDialogueFinished != null)
        {
            onDialogueFinished();   
        }
    }

    public event Action<string> onDisplayDialogue; 

    public void DisplayDialogue(string dialogueLine)
    {
        if (onDisplayDialogue != null)
        {
            onDisplayDialogue(dialogueLine); 
        }
    }
}
