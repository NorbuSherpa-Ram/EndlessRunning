using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusicContoller : MonoBehaviour
{

    [System.Serializable]
    class Sound
    {
        public string audioName;
        public float volume;
        public bool loop;
        public AudioClip clip;
        public AudioSource audioSource;
    }

    [SerializeField] Sound[] sound;
 

    void Awake()
    {
        foreach (Sound s in sound)
        {
            s.audioSource = gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.clip;
            s.audioSource.volume  = 0.28f;
            s.audioSource.loop = s.loop;
        }
    }
    private void Start()
    {
        Music("Music1");
    }

    public void Music(string name)
    {
  
        foreach (Sound s in sound)
        {
            if (s.audioName == name)
            {
                s.audioSource.Play();
            }
            else
            {
                s.audioSource.Stop();
            }
        }
  
    }

}
