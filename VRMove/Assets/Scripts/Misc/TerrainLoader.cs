using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{

    public GameObject deactivate;
    public GameObject activate;

    private List<MeshRenderer> activeRenderers = new List<MeshRenderer>();
    private List<MeshRenderer> deactiveRenderers = new List<MeshRenderer>();

    private void Start()
    {
        //Load Render
        StartCoroutine(GetActiveRenderers());
        StartCoroutine(GetDeactiveRenderers());
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Terrain Change detected");
        if(deactivate)
        {
            Debug.Log("Deactivating..." + deactivate.name);
            StartCoroutine(DeactivateRenderers());
        }

        if (activate)
        {
            Debug.Log("Activating..." + activate.name);
            StartCoroutine(ActivateRenderers());
        }
    }

    IEnumerator GetActiveRenderers()
    {
        //For Activate
        foreach(Transform t in activate.transform)
        {
            activeRenderers.AddRange(t.GetComponentsInChildren<MeshRenderer>(true));
            yield return null;
        }
    }

    IEnumerator GetDeactiveRenderers()
    {
        //For Deactivate
        foreach (Transform t in deactivate.transform)
        {
            deactiveRenderers.AddRange(t.GetComponentsInChildren<MeshRenderer>(true));
            yield return null;
        }
    }

    IEnumerator DeactivateRenderers()
    {
        foreach(MeshRenderer r in deactiveRenderers)
        {
            r.enabled = false;
            yield return null;
        }
    }

    IEnumerator ActivateRenderers()
    {
        foreach (MeshRenderer r in activeRenderers)
        {
            r.enabled = true;
            yield return null;
        }
    }
}
