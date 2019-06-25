using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObstacle : Obstacle
{

    public Animator animator;


    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Trigger()
    {
        Debug.Log("Working");
        animator.SetBool("OpenGate", true);
    }
}
