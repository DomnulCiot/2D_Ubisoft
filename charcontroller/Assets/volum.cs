using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volum : MonoBehaviour {
    // public float vol;
    public AudioMixer audiomixer;
    public Slider slider;
     float Val;

   void Start ()
    {
        audiomixer.GetFloat("volum", out Val);
        slider.value = Val;
    }
		public void SetVolume (float volume)
    {
       audiomixer.SetFloat("volum",volume);
    }
	
}
