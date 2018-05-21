using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_vault : MonoBehaviour {

    // Use this for initialization

    public Rigidbody2D Erb2D;
    public float jump_pwr;
    public bool isGrounded;
    public Transform GroundCheck;
    public LayerMask layerMask;

    void Start ()
    {
        //Erb2D = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody2D>();
        //GroundCheck = GameObject.FindGameObjectWithTag("EGC").GetComponent<Transform>();
    }
	
    void OnTriggerStay2D (Collider2D col)
    {
        if (!col.CompareTag ("Player") && isGrounded == true && !col.CompareTag ("PlayerRelated"))
        {
            Erb2D.AddForce(new Vector2 (0f,jump_pwr));
            Debug.Log(col.name);
            isGrounded = false;
        }
            
            
    }

	// Update is called once per frame
	void Update () {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.01f, layerMask);

    }
}
