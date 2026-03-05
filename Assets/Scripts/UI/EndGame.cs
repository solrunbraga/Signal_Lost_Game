using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 


public class EndGame : MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("play button clicked!"); 
        SceneManager.LoadSceneAsync("StartMenu"); 
    }
}
