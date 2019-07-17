using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObstacle : Obstacle
{

    public ParticleSystem fire;
    public ParticleSystem smoke;

    public string soundKey;

    protected override void Trigger()
    {
        hasTriggered = true;
        fire.Play();
        smoke.Play();
        PlaySound(soundKey);
    }

    protected override void Update()
    {
        base.Update();
        if(hasTriggered && !fire.isPlaying && !smoke.isPlaying)
        {
            gameObject.SetActive(false);
        }
    }

    void PlaySound(string key)
    {
        if (soundKey.Length > 0)
        {
            SoundManager.Instance.PlaySound(key);
            return;
        }
        return;
    }
}
