using UnityEngine;
using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;

public class ItemToReveal : MonoBehaviour
{
    [SerializeField] 
    private string inkVariableName;

    private void Start()
    {
        gameObject.SetActive(false);

        DialogueManager.GetInstance().ObserveVariable(inkVariableName, OnVariableChanged);
    }

    //Signature must match Ink.Runtime.Story.VariableObserver
    private void OnVariableChanged(string variableName, object newValue)
    {
        if ((bool)newValue)
        {
            gameObject.SetActive(true);
        }
    }
}
