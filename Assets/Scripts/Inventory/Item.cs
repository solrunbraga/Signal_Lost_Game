using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    [SerializeField]
    private int quantity;

    [SerializeField]
    private Sprite sprite;

    [TextArea]
    [SerializeField]
    private string itemDescription;

    [SerializeField] 
    private bool countsTowardUnlock = false;
    public GameObject guiObject;
    

    private InventoryManager inventoryManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("InventoryCanvas").GetComponent<InventoryManager>();
        guiObject.SetActive(false); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            guiObject.SetActive(true); 
            if (guiObject.activeSelf && Input.GetKeyDown(KeyCode.E))
            {
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);

                if (countsTowardUnlock)
                {
                    inventoryManager.ItemCollected();
                }


                Destroy(gameObject); 
                
                guiObject.SetActive(false); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        guiObject.SetActive(false); 
        
    }
}
