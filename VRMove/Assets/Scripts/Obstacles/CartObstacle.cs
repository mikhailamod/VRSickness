using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartObstacle : Obstacle
{
    public Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Trigger()
    {
        SoundManager.Instance.playSound("wagonmove");
        animator.SetBool("MoveCart", true);
    }
}
