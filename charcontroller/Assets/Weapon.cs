using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 0;
    public float damage = 10;
    public LayerMask whatToHit;

    float timeToFire = 0;
    Transform firePoint;

	// Use this for initialization
	void Awake () {
        firePoint = transform.Find("FirePoint");
   
	}
	
	// Update is called once per frame
	void Update () {



       

		if(fireRate == 0)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        else if (Input.GetMouseButtonDown(0) && Time.time > timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
	}

    void Shoot()
    {
        Vector3 mousePosition =  Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position,mousePosition - firePoint.position,100,whatToHit);
        Debug.DrawLine(firePoint.position, (mousePosition-firePoint.position)*100, Color.magenta);
        if (hit.collider != null)
        {
            Debug.Log("lol");
            Debug.DrawLine(firePoint.position, hit.point, Color.red);
        }
    }
}
