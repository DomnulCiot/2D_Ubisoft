using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidLineRenderer : MonoBehaviour {

    // Use this for initialization
    LineRenderer line;

	void Start () {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
        line.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        line.SetPosition(0, GameObject.Find("LineStartPoint").transform.position);

        if (GameObject.Find("Anchor(Clone)") != null)
        {
            line.SetPosition(1, GameObject.Find("Anchor(Clone)").transform.position);
            line.enabled = true;
        }
        else line.enabled = false;
	}
}
