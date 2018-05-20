using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Draw : MonoBehaviour {

    // Use this for initialization

    LineRenderer line;
	void Start () {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Grappler(Clone)") != null)
        {
            line.SetPosition(1, GameObject.Find("Grappler(Clone)").transform.position);
            line.SetPosition(0, GameObject.Find("LineStartPoint").transform.position);
            line.enabled = true;
        }
        else line.enabled = false;
  
       
	}
}
