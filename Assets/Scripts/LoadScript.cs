using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{

    public Transform thingstoNuke;
    public Transform spawnpoint;
    public Transform player;

    public string[] scenes;
    public int sceneNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.L))   //make sure it's a oneshot
       {
            Debug.Log("L key pressed");

            foreach(Transform fred in thingstoNuke)
            {
                Destroy(fred.gameObject);
            }

            Destroy(thingstoNuke.gameObject);
            thingstoNuke = null;

            Debug.Log("scene number is  " + sceneNumber);

            Debug.Log("Loading scene " + scenes[sceneNumber]);

            SceneManager.LoadScene(scenes[sceneNumber], LoadSceneMode.Additive);

            sceneNumber++;

            return;

    
       }

       if(thingstoNuke == null)
        {
            //do what you need to do to start this scene
            thingstoNuke = GameObject.Find("ThingsToNuke").transform;
            spawnpoint = GameObject.Find("SpawnPoint").transform;
            Debug.Log(thingstoNuke);
            Debug.Log(spawnpoint);

            if (spawnpoint)
            {
                player.position = spawnpoint.position;

            }
        }
    }
}
