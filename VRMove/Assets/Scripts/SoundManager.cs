using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
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

    public void playSound(string key)
    {
        soundEffectsMap[key].Play();
    }

    public void stopSound(string key)
    {
        soundEffectsMap[key].Stop();
    }

    public bool isPlaying(string key)
    {
        return soundEffectsMap[key].isPlaying;
    }
}
