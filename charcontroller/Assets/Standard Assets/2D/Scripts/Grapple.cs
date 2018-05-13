using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour {


    // Use this for initialization

    Vector3 targetPos;
     RaycastHit2D hit;
   
    public float distance = 100f;
    public LayerMask mask;
    public Vector3 offset = new Vector3(1f, 1f,0f);
    public float decrement = 10f;
    public float leastDistance = 1f;
    private float initDistance;
    

    DistanceJoint2D joint;
   // SpringJoint2D joint;
    void Start()
    {

        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(joint.enabled)
        {
            if(Input.GetKey("up")&&joint.distance > leastDistance)
            {
                joint.distance -= decrement;
            }
            if(Input.GetKey("down")&&joint.distance <= initDistance)
            {
                joint.distance += decrement;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {

           
            if (joint.enabled == true)
            {
                joint.enabled = false;
            }
            else if (joint.enabled == false)
            {

                var mousePos = Input.mousePosition;
                mousePos.z = 10f; // select distance = 10 units from the camera
                targetPos = Camera.main.ScreenToWorldPoint(mousePos);
                // Debug.Log(targetPos);

                hit = Physics2D.Raycast(transform.position + offset, targetPos - transform.position, distance, mask);
                if (hit.collider != null)
                {
                    //Debug.Log(hit.collider);
                    Debug.Log(hit.collider.gameObject.GetComponent<Rigidbody2D>());
                    Debug.Log(hit.collider.gameObject.GetComponent<Rigidbody2D>().position);
                }



                if (hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {

                    //joint.enabled = true;
                    joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                    joint.distance = Vector2.Distance(transform.position, hit.point);

                    Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                    connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                    connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                    Debug.Log(connectPoint);
                    joint.connectedAnchor = connectPoint;

                    initDistance = joint.distance;
                    
                    joint.enabled = true;
                }


            }

        }



    }

    
}
