﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Singleton is responsible for all sound effects within the environment
/// </summary>
public class SoundManager : MonoBehaviour
{
    public static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [System.Serializable]
    public struct KeyVal
    {
        public string key;
        public AudioSource value;
    }
    public KeyVal[] soundEffects;
    public Dictionary<string, AudioSource> soundEffectsMap;

    private void Start()
    {
        soundEffectsMap = new Dictionary<string, AudioSource>();
        for(int i = 0; i < soundEffects.Length; i++)
        {
            soundEffectsMap.Add(soundEffects[i].key, soundEffects[i].value);
        }
    }

    public void PlaySound(string key)
    {
        if(soundEffectsMap.ContainsKey(key) && soundEffectsMap[key] != null)
        {
            soundEffectsMap[key].Play();
        }
        
    }

    public void StopSound(string key)
    {
        if (soundEffectsMap.ContainsKey(key) && soundEffectsMap[key] != null)
        {
            soundEffectsMap[key].Stop();
        }
    }

    public bool IsPlaying(string key)
    {
        if (soundEffectsMap.ContainsKey(key) && soundEffectsMap[key] != null)
        {
            return soundEffectsMap[key].isPlaying;
        }
        return false;
    }

}
