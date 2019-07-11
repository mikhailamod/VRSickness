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
        SoundManager.Instance.PlaySound("gateOpen");
        animator.SetBool("OpenGate", true);
    }
}
