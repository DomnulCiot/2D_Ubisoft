using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_HEalth : MonoBehaviour {

    public int life = 35;
    public GameObject enem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (life <= 0)
            Destroy(enem);

	}
}
