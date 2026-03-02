using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_CharFst : MonoBehaviour
{
    private enum CURRENT_TERRAIN { CONCRETE };
    [SerializeField] 
    private CURRENT_TERRAIN currentTerrain;

    private FMOD.Studio.EventInstance footsteps;

    private void Update()
    {
        DetermineTerrain(); 
    }

    private void DetermineTerrain()
    {
        RaycastHit[] hit;

        hit = Physics.RaycastAll(transform.position, Vector3.down, 10.0f);

        foreach (RaycastHit rayhit in hit)
        {
            if (rayhit.transform.gameObject.layer == LayerMask.NameToLayer("Concrete"))
            {
                currentTerrain = CURRENT_TERRAIN.CONCRETE;
                break; 
            }
        }
    }

    public void SelectAndPlayFootstep()
    {
        switch (currentTerrain)
        {
            case CURRENT_TERRAIN.CONCRETE:
                PlayFootstep(0); 
                break;
            
            default:
                PlayFootstep(0); 
                break; 
        }
    }

    private void PlayFootstep(int terrain)
    {
        footsteps = FMODUnity.RuntimeManager.CreateInstance("event:/Char/footsteps");
        footsteps.setParameterByName("Terrain", terrain);
        footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        footsteps.start();
        footsteps.release();
    }
}
