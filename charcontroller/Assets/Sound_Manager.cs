using UnityEngine.Audio;
using UnityEngine;
using System;

public class Sound_Manager : MonoBehaviour {

    public sound1[] sounds;
    void Awake ()
    {
        foreach (sound1 s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.outputAudioMixerGroup = s.mixer;
        }
    }
    public sound1 P;
    public void Play (string name)
    {
        P = Array.Find(sounds, sound1 => sound1.name == name);
        P.source.Play();
    }
    void Start ()
    {
        Play("tema");
    }
   // public volum x;
   // public sound1 S;
    /*public void Volume (string name)
    {
        S = Array.Find(sounds, sound1 => sound1.name == name);
        S.source.volume = x.vol;
    }*/
   /* void Update ()
    {
        Volume("tema");
    }*/
    

}
