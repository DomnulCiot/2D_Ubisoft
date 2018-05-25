using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class LookAt : MonoBehaviour
{
    public GameObject Player;
    float TimeSearch;

    private void Start()
    {



    }

    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                Player = Search;
            TimeSearch = Time.time + 0.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Player == null)
        {
            FindPlayer();
            return;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100)) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;



        if (Player.GetComponent<PlatformerCharacter2D>().m_FacingRight)  transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
        }
    }
}
