using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject guiObject; 
    public string levelToLoad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       guiObject.SetActive(false); 
    }

    void OnTriggerStay (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guiObject.SetActive(true); 
            if (guiObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    void OnTriggerExit (Collider other)
    {
        
        guiObject.SetActive(false); 
        
    }

}
