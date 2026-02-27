using UnityEngine;

public class EndTigger : MonoBehaviour
{
    public GameObject endPanel;      // Panel when player HAS KeyCard
    public GameObject noKeyPanel;    // Panel when player DOES NOT have KeyCard
    public GameObject guiObject; //press E ui 

    private bool playerInside = false;
    private bool panelOpen = false;

    private void Start()
    {
        endPanel.SetActive(false);
        noKeyPanel.SetActive(false);
    }

    private void Update()
    {
        if (playerInside && !panelOpen && Input.GetKeyDown(KeyCode.E))
        {
            guiObject.SetActive(false); // Hide "(E)" prompt
            TryInteract();
        }

        // Close "no key" panel with Space
        if (panelOpen && noKeyPanel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            ClosePanels();
        }
    }

    private void TryInteract()
    {
        if (InventoryManager.instance.HasItem("KeyCard"))
        {
            endPanel.SetActive(true);
            panelOpen = true;

            
        }
        else
        {
            noKeyPanel.SetActive(true);
            panelOpen = true;
        }
    }

    private void ClosePanels()
    {
        endPanel.SetActive(false);
        noKeyPanel.SetActive(false);
        panelOpen = false;
        Time.timeScale = 1f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guiObject.SetActive(true);
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guiObject.SetActive(false);
            playerInside = false;
        }
    }
}
