using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_platform : MonoBehaviour {

    public Rigidbody2D rb2D;
    public float time;
    float timer = 0;
    bool start=false;

	void Start () {
        rb2D = GameObject.FindGameObjectWithTag("falling_platform").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer < time && start==true)
            timer += 0.5f;
        if (timer == time)
            rb2D.bodyType = RigidbodyType2D.Dynamic;
	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        start = true;

    }
}
