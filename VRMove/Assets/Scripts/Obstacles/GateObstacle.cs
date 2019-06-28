using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateObstacle : Obstacle
{

    public Animator animator;
    public SoundManager soundManager;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Trigger()
    {
        soundManager.playSound("gateOpen");
        animator.SetBool("OpenGate", true);
    }
}
