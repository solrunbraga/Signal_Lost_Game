using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll(); // or DeleteKey("BedUsed")
        PlayerPrefs.Save();

        Debug.Log("play button clicked!"); 
        SceneManager.LoadSceneAsync("HotelScene"); 
    }

      public void QuitGame()
    {
        Debug.Log("Quitting Game..."); 
        Application.Quit(); 
    }
}
