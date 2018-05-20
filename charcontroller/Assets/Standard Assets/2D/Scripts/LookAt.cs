using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LookAt : MonoBehaviour
{


    private void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;



        if (GameObject.Find("player").GetComponent<PlatformerCharacter2D>().m_FacingRight) transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
        }
    }
}
