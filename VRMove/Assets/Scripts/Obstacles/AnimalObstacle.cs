using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObstacle : Obstacle
{

    public Animator animator;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        if (Mathf.Abs(transform.position.z - player.position.z) < proximity)
        {
            Trigger();
        }
    }

    protected override void Trigger()
    {
        animator.SetBool("isWalking", true);
    }
}
