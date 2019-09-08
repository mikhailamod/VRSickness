using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class activates or deactivates a group of MeshRenders
/// This is required to reduce GPU load
/// </summary>
public class TerrainLoader : MonoBehaviour
{

    public static int iterations = 5;

    public GameObject deactivate;
    public GameObject activate;

    private List<MeshRenderer> activeRenderers = new List<MeshRenderer>();
    private List<MeshRenderer> deactiveRenderers = new List<MeshRenderer>();

    private void Start()
    {
        //Load Render
        GetActiveRenderers();
        GetDeactiveRenderers();
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Terrain Change detected");
        if(deactivate)
        {
            Debug.Log("Deactivating..." + deactivate.name);
            DeactivateRenderers();
        }

        if (activate)
        {
            Debug.Log("Activating..." + activate.name);
            ActivateRenderers();
        }
    }

    void GetActiveRenderers()
    {
        if (activate != null)
        {
            foreach (Transform t in activate.transform)
            {
                activeRenderers.AddRange(t.GetComponentsInChildren<MeshRenderer>(true));
            }
        }
    }

    void GetDeactiveRenderers()
    {
        if(deactivate != null)
        {
            foreach (Transform t in deactivate.transform)
            {
                deactiveRenderers.AddRange(t.GetComponentsInChildren<MeshRenderer>(true));
            }
        }
    }

    void DeactivateRenderers()
    {
        foreach(MeshRenderer r in deactiveRenderers)
        {
            r.enabled = false;
            
        }
    }

    void ActivateRenderers()
    {
        foreach (MeshRenderer r in activeRenderers)
        {
            r.enabled = true;
        }
    }
}
