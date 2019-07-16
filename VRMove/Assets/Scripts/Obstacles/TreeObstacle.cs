using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObstacle : Obstacle
{

    public ParticleSystem fire;
    public ParticleSystem smoke;

    protected override void Trigger()
    {
        hasTriggered = true;
        fire.Play();
        smoke.Play();
    }

    protected override void Update()
    {
        base.Update();
        if(hasTriggered && !fire.isPlaying && !smoke.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }
}
