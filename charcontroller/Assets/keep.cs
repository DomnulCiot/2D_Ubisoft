using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keep : MonoBehaviour {


    public static keep KP;

	void Awake ()
    {
        if (KP == null)
        {
            KP = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (KP != this)
        {
            Destroy(gameObject);
            Debug.Log("osop");
        }
    }
	
	// Update is called once per frame
	void Update () {
	}
}
