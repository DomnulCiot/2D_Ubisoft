using UnityEngine.Audio;
using UnityEngine;
[System.Serializable]
public class sound1  {
    public string name;
    public AudioClip clip;
    [Range(1f,100f)]
    public float volume;
    [Range(0.3f,2f)]
    public float pitch;
    //[HideInInspector]
    public AudioSource source;
    public AudioMixerGroup mixer;
	
}
