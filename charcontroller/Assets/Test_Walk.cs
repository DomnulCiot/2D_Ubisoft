using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Walk : MonoBehaviour {

    public LayerMask MaskOfLayer;
    public bool walk = true;
    public Transform ground_walk;

	void Update ()
    {
        walk = Physics2D.OverlapCircle(ground_walk.position, 0.1f, MaskOfLayer);
    }
	
}
