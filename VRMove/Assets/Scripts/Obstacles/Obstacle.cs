using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Obstacle : MonoBehaviour
{

    public float proximity;
    public KeyCode input;

    protected Transform player;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Mathf.Abs(transform.position.z - player.position.z) < proximity && Input.GetKeyDown(input))
        {
            Trigger();   
        }
    }

    protected abstract void Trigger();
}
