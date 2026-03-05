using UnityEngine;

public class BedSleep : MonoBehaviour
{

    public GameObject pressEUI;        // UI that shows "(E)"
    public GameObject canvasToShow;    // Main UI canvas
    public GameObject objectToEnable;  // Object to make visible
    public GameObject objectToDestroy; // Object to destroy

    private bool playerInTrigger = false;

    void Start()
    {

        pressEUI.SetActive(false);
        canvasToShow.SetActive(false);
        objectToEnable.SetActive(false); // start hidden

    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // Show canvas
            canvasToShow.SetActive(true);

            // Enable object
            objectToEnable.SetActive(true);

            // Destroy object
            Destroy(objectToDestroy);

            // Hide "(E)" prompt
            pressEUI.SetActive(false);

            // Disable further interactions with bed
            GetComponent<Collider>().enabled = false;

            enabled = false; //disable script no further interactions 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            pressEUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;
            pressEUI.SetActive(false);
        }
    }
}
