using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartObstacle : Obstacle
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
        soundManager.playSound("wagonmove");
        animator.SetBool("MoveCart", true);
    }
}
