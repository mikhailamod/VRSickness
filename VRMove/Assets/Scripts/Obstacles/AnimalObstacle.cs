using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalObstacle : Obstacle
{

    public Animator animator;
    public string walkingAnimationKey;
    public string idleAnimationKey;

    public Transform beginPos;
    public Transform endPos;
    public float maxDistanceDelta = 0.5f;

    public bool isMovable = false;
    bool canMove = false;
    public float animationLength = 6.8f;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        if(!idleAnimationKey.Equals("none"))
        {
            animator.SetBool(idleAnimationKey, true);
        }

    }

    protected override void Update()
    {
        if (Mathf.Abs(transform.position.z - player.position.z) < proximity)
        {
            if (isMovable) { canMove = true; }
            Trigger();
            Move();
        }
        else if (!idleAnimationKey.Equals("none"))
        {
            animator.SetBool(idleAnimationKey, true);
        }

    }

    protected override void Trigger()
    {
        if (!hasTriggered)
        {
            if(!idleAnimationKey.Equals("none"))
            {
                animator.SetBool(idleAnimationKey, false);
            }
            animator.SetBool(walkingAnimationKey, true);
            hasTriggered = true;
            StartCoroutine(BackToIdle());
        }
        
    }

    void Move()
    {
        if (canMove)
        {
            transform.position = Vector3.MoveTowards(beginPos.position,
                                                    endPos.position,
                                                    maxDistanceDelta * Time.deltaTime);
        }
    }

    IEnumerator BackToIdle()
    {
        Debug.Log("backtoodle");
        yield return new WaitForSecondsRealtime(animationLength);
        animator.SetBool(walkingAnimationKey, false);
        Debug.Log("End");
    }
}
