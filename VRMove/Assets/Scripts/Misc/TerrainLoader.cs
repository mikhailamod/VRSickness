using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainLoader : MonoBehaviour
{

    public GameObject deactivate;
    public GameObject activate;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Terrain Change detected");
        if(deactivate)
        {
            Debug.Log("Deactivating..." + deactivate.name);
            deactivate.SetActive(false);
        }

        if (activate)
        {
            Debug.Log("Activating..." + activate.name);
            activate.SetActive(true);
        }
    }
}
