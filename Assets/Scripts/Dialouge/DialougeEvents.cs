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
}
