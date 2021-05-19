using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        if (instance == null){
            instance = this;

        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds) {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start() {
        Play("bg_song");
    }

    public void Play(string name) {
        Sound sound = Array.Find(sounds, s => s.name == name);
        if (sound == null) {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

        sound.source.Play();
    }
}
