using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basic moving cart obstacle
/// </summary>
public class CartObstacle : Obstacle
{
    public Animator animator;
    public string soundKey;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Trigger()
    {
        SoundManager.Instance.PlaySound(soundKey);
        animator.SetBool("MoveCart", true);
    }
}
