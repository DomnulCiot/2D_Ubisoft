using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;
    public GameObject Grappler;
    public GameObject Anchor;
    public RaycastHit2D hit;
    Transform Pistol;
    float timeToFire = 0;
    Transform firePoint;
  public  bool canShoot = true;
    GameObject Bullet;
    DistanceJoint2D dist_joint;
    float TimeSearch;

    //   Transform grap;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        Pistol = transform.Find("Pistol");
        dist_joint = GameObject.Find("player").GetComponent<DistanceJoint2D>();
    }

    void FindDistJoint()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                dist_joint = Search.GetComponent<DistanceJoint2D>();
            TimeSearch = Time.time + 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dist_joint == null)
        {
            FindDistJoint();
            return;
        }


        if (dist_joint.enabled)
        {
            if (Input.GetKey("up"))
            {
                dist_joint.distance -= 0.1f;
            }

        }

        if (dist_joint.enabled)
        {
            if (Input.GetKey("down"))
            {
                dist_joint.distance += 0.1f;
            }

        }


        // Debug.Log(GameObject.Find("Grappler(Clone)"));
        Bullet = GameObject.Find("Grappler(Clone)");
        if (canShoot == false && Bullet == null) canShoot = true ;
        if(Bullet != null)
        {
            if(Vector3.Distance(hit.point, Bullet.transform.position)<0.7f)
            {
                Destroy(GameObject.Find("Grappler(Clone)"));
                Instantiate(Anchor, hit.point, Quaternion.identity);
                dist_joint.connectedBody = GameObject.Find("Anchor(Clone)").GetComponent<Rigidbody2D>();
                dist_joint.connectedAnchor = Vector3.zero;
                dist_joint.distance = Vector3.Distance(firePoint.position, hit.point);
                dist_joint.enabled = true;

            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(!canShoot)
            {
                Destroy(GameObject.Find("Grappler(Clone)"));
                GameObject.Find("Anchor(Clone)");
                dist_joint.enabled = false;
            }

            else
            {
                if(dist_joint.enabled == false)
                {
                    Shoot();
                    canShoot = false;
                }
                if(dist_joint.enabled == true)
                {
                    Destroy(GameObject.Find("Anchor(Clone)"));
                    dist_joint.enabled = false;

                }
            }

        }



    }

    void Shoot()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 106.56f));
        hit = Physics2D.Raycast(firePoint.position, mousePosition - firePoint.position, 100, whatToHit);
        Debug.DrawLine(firePoint.position, (mousePosition - firePoint.position) * 100, Color.magenta);
        if (hit.collider != null)
        {
            Debug.Log("lol");
            Debug.DrawLine(firePoint.position, hit.point, Color.red);
        }

        Instantiate(Grappler, this.gameObject.transform);
    }
}
