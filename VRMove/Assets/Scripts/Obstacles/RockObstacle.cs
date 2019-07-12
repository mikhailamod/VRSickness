using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockObstacle : Obstacle
{

    public ParticleSystem particleEffect;

    public string soundEffectKey;

    protected override void Trigger()
    {
        hasTriggered = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        particleEffect.Play();
        PlaySound(soundEffectKey);
    }

    void PlaySound(string key)
    {
        if(key.Length > 0)
        {
            SoundManager.Instance.PlaySound(key);
            return;
        }
        return;
    }

}
