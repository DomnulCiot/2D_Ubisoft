using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Grappler_move : MonoBehaviour
{

    CircleCollider2D collider;
    GameObject firepoint;
    private bool move = true;

    public float activateRadius = 1f;
    public float move_distance = 10f;
    Rigidbody2D rb;
    RaycastHit2D hit;
    public float angle;
    public GameObject player;

    Vector3 birth;
    public Vector2 DirectionPointer;
    // Use this for initialization


    void Start()
    {
        transform.parent = null;
        collider = transform.GetComponent<CircleCollider2D>();
        rb = transform.GetComponent<Rigidbody2D>();
        collider.enabled = true;
        firepoint = GameObject.Find("FirePoint");
        birth = transform.position;
        hit = GameObject.Find("Pistol").GetComponent<Weapon>().hit;
        angle = Mathf.Deg2Rad * transform.eulerAngles.z;
        if (GameObject.Find("player").GetComponent<PlatformerCharacter2D>().m_FacingRight == false) angle += Mathf.PI;
        DirectionPointer = new Vector2(firepoint.transform.position.x, firepoint.transform.position.y) - hit.point;

      

    }


    // Update is called once per frame

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.collider.name != "player")
        {
            move = false;
            GameObject.Find("Pistol").GetComponent<Weapon>().hasCollided = true;
        }

    }


    void Update()
    {


        //  Debug.Log(Vector3.Distance(transform.position, firepoint.transform.position));

        //  Vector2 DirectionPointer = new Vector2(firepoint.transform.position.x, firepoint.transform.position.y) - hit.point;



        //  rb.AddForce(DirectionPointer.normalized * 100);

        if (Vector3.Distance(transform.position, birth) > 50f)
        {
            Destroy(GameObject.Find("Grappler(Clone)"));
        }

    }

    private void FixedUpdate()
    {if (move)
        {
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            rb.AddForce(direction * 0.1f);
        }
    }
}
