using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Grappler_move : MonoBehaviour {

    CircleCollider2D collider;
    GameObject firepoint;

    public float activateRadius = 1f;
    public float move_distance = 10f;
    Rigidbody2D rb;
    RaycastHit2D hit;
    public float angle;
    public GameObject Player;
    float TimeSearch;

    Vector3 birth;
	// Use this for initialization


	void Start () {
        transform.parent = null;
        collider = transform.GetComponent<CircleCollider2D>();
        rb = transform.GetComponent<Rigidbody2D>();
        collider.enabled = true;
        firepoint = GameObject.Find("FirePoint");
        birth = transform.position;
        hit = GameObject.Find("Pistol").GetComponent<Weapon>().hit;
        angle = Mathf.Deg2Rad * transform.eulerAngles.z;
        if (Player==null)
        {
            FindPlayer();
            return;
        }
        if (Player.GetComponent<PlatformerCharacter2D>().m_FacingRight == false) angle += Mathf.PI;
    }

    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                Player = Search;
            TimeSearch = Time.time + 0.5f;
        }
    }


    // Update is called once per frame


    void Update () {

        
        if(collider.enabled == false && Vector3.Distance(transform.position, firepoint.transform.position) > activateRadius)
        {
            collider.enabled = true;
        }

        Vector2 DirectionPointer = new Vector2(firepoint.transform.position.x, firepoint.transform.position.y) - hit.point;

      
      
        transform.position += new Vector3(move_distance * Mathf.Cos(angle), move_distance * Mathf.Sin(angle), 0);

        if(Vector3.Distance(transform.position, birth)>50f)
        {
            Destroy(GameObject.Find("Grappler(Clone)"));
        }

	}
}
