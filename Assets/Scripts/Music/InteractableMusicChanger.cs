using UnityEngine;

public class InteractableMusicChanger : MonoBehaviour
{
    [SerializeField]
    private string musicStateLabel;

    private bool playerInTrigger = false; 

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Changing music state to: " + musicStateLabel);
            MusicManager.Instance.SetMusicState(musicStateLabel); 
        }
    }

    private void onTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
        }
    }

    private void onTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
        }
    }
}
