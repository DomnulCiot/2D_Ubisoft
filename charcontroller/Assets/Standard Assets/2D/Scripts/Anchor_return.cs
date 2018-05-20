using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor_return : MonoBehaviour {

    public float move_distance = 0.1f;
    public Vector3 ReturnPoint;
    public bool allowed = false;
    float angle;
	// Use this for initialization
	void Start () {
        ReturnPoint = GameObject.Find("LineStartPoint").transform.position;
        Vector2 Direction = ReturnPoint - transform.position;

       angle = Mathf.Atan2(Direction.y, Direction.x);
    }

    // Update is called once per frame
    void Update()
    {

        if (allowed)
        {
          
           

            transform.position += new Vector3(move_distance * Mathf.Cos(angle), move_distance * Mathf.Sin(angle), 0);
          

            if(Vector3.Distance(transform.position, ReturnPoint)<2f)
            {
                Debug.Log("Cristiciotei");
                Destroy(GameObject.Find("Anchor(Clone)"));
            }
        }
    }
}
