using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        Vector3 difference = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,100)) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
	}
}
