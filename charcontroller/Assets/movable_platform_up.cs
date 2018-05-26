using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable_platform_up : MonoBehaviour {
    public bool movingUp = true;
    public Rigidbody2D rb2D;
    public float move = 10;
    public float initialPosition;
    // public Transform pos;

    void Start()
    {
        rb2D = GameObject.FindGameObjectWithTag("movable_platform_up").GetComponent<Rigidbody2D>();
        initialPosition = transform.position.y;

    }
    [SerializeField]
    private Vector3 velocity;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (initialPosition + move <= transform.position.y)
            movingUp = !movingUp;

        else if (transform.position.y < initialPosition)
            movingUp = !movingUp;

        if (movingUp == true)
        {
            transform.position += (velocity * Time.deltaTime);
        }
        else
        {
            transform.position += (velocity * Time.deltaTime * -1);
        }


    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        rb2D.velocity = new Vector3(0, 0, 0);
        if (col.gameObject.tag == "Player")
            col.collider.transform.SetParent(transform);

    }
    private void OnCollisionExit2D(Collision2D col)
    {
        rb2D.velocity = new Vector3(0, 0, 0);

        if (col.gameObject.tag == "Player")
        {
            col.collider.transform.SetParent(null);
        }
    }





}
