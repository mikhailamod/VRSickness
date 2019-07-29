using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeObstacle : Obstacle
{

    public ParticleSystem fire;
    public ParticleSystem smoke;

    public string soundKey;

    MeshRenderer mesh;

    protected override void Start()
    {
        base.Start();
        mesh = GetComponent<MeshRenderer>();
    }

    protected override void Trigger()
    {
        hasTriggered = true;

        if(mesh != null)
        {
            mesh.enabled = false;
        }

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
