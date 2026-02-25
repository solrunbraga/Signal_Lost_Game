using UnityEngine;
using System; 

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance {get; private set;}

    public DialougeEvents dialougeEvents; 
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene");
        }
        instance = this; 

        dialougeEvents = new DialougeEvents(); 
        
    }
}
