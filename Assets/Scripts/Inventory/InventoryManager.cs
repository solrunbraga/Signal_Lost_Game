using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu; 
    private bool menuActivated; 
    public ItemSlot[] itemSlot;
    public GameObject lastItem; //last item to reveal 

    private int itemsCollected = 0; 
    public int itemsNeeded = 4; //items requierd

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && menuActivated)
        {
            Time.timeScale = 1f;
            InventoryMenu.SetActive(false); 
            menuActivated = false;
        }
        else if (Input.GetKeyDown(KeyCode.B) && !menuActivated)
        {
            Time.timeScale = 0f;
            InventoryMenu.SetActive(true); 
            menuActivated = true;
        }
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        // Here you would add the item to your inventory data structure
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                break;
            }
        }
        // You can also update the UI to reflect the new item
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void ItemCollected()
    {
        itemsCollected++;
        Debug.Log("items collected: " + itemsCollected); 

        if(itemsCollected >= itemsNeeded)
        {
            RevealLastItem();
        }
    }

    private void RevealLastItem()
    {
        if(lastItem != null)
        {
            lastItem.SetActive(true); // The player can now pick it up
            Debug.Log("Last item is now revealed!");
        }
    }
}
