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
                Destroy(gameObject); 
                guiObject.SetActive(false); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
