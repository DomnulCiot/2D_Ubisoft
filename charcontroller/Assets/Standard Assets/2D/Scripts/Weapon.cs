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
    public bool canShoot = true;
    GameObject Bullet;
    DistanceJoint2D dist_joint;
    public bool hasCollided = false;
    //   Transform grap;

    // Use this for initialization
    void Awake()
    {
        firePoint = transform.Find("FirePoint");
        Pistol = transform.Find("Pistol");
        // dist_joint = GameObject.Find("player").GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {


        // Debug.Log(GameObject.Find("Grappler(Clone)"));
        Bullet = GameObject.Find("Grappler(Clone)");
        if (canShoot == false && Bullet == null) canShoot = true;
        if (Bullet != null)
        {
            if (Vector3.Distance(hit.point, Bullet.transform.position) < 1f)
            {
                Debug.Log("entered");
                Destroy(GameObject.Find("Grappler(Clone)"));
                Instantiate(Anchor, hit.point, Quaternion.identity);
             /*   dist_joint = GameObject.Find("Anchor(Clone)").GetComponent<DistanceJoint2D>();
                dist_joint.connectedBody = GameObject.Find("player").GetComponent<Rigidbody2D>();
                dist_joint.connectedAnchor = Vector3.zero;
                dist_joint.distance = Vector3.Distance(GameObject.Find("Anchor(Clone)").transform.position, GameObject.Find("player").transform.position);
                dist_joint.enabled = true; */

            }
        else if (hasCollided)
            {
                Instantiate(Anchor, GameObject.Find("Grappler(Clone)").transform.position, Quaternion.identity);
                Destroy(GameObject.Find("Grappler(Clone)"));
                //Instantiate(Anchor, hit.point, Quaternion.identity);
              /*  dist_joint = GameObject.Find("Anchor(Clone)").GetComponent<DistanceJoint2D>();
                dist_joint.connectedBody = GameObject.Find("player").GetComponent<Rigidbody2D>();
                dist_joint.connectedAnchor = Vector3.zero;
                dist_joint.distance = Vector3.Distance(GameObject.Find("Anchor(Clone)").transform.position, GameObject.Find("player").transform.position);
                dist_joint.enabled = true;  */
                hasCollided = false;
            }   
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!canShoot)
            {
                if (Bullet != null) Destroy(Bullet);
            }

            else
            {
                if (GameObject.Find("Anchor(Clone)") != null)
                {
                    Destroy(GameObject.Find("Anchor(Clone)"));
                }
                else
                {
                    Shoot();
                    canShoot = false;
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
