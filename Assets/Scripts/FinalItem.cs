using UnityEngine;

public class FinalItem : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false); //hide item 

        if (InventoryManager.instance != null)
        {
            InventoryManager.instance.RegisterFinalItem(this);
                
        }
    }

    public void Reveal()
    {
        gameObject.SetActive(true); //reveal item
    }
}
