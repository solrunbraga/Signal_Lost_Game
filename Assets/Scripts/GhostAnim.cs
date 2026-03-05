using UnityEngine;

public class GhostAnim : MonoBehaviour
{
    [SerializeField] 
    private Animator myGhost; 

    [SerializeField]
    private string surprised = "surprised"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myGhost.Play(surprised, 0, 0.0f); 
        }
    }
}
