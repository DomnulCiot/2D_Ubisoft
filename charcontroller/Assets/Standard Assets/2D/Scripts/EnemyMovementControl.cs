﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementControl : MonoBehaviour {

    public float nr;
    public float speed = 10.0f;
    public Transform target;
    public float posIn;
    public bool FacingRight = false;
    public bool GeneralRoutine = true;
    public bool MovingRight = true;
    float TimeSearch;
    public bool gotoplayer;

    void Start()
    {
        posIn = transform.position.x;
    }

    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                target = Search.GetComponent<Transform>();
            TimeSearch = Time.time + 0.5f;
        }
    }
   /* void Update ()
    {
        if (target ==null)
        {
            FindPlayer();
            return ;
        }
    }*/
    void OnTriggerStay2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        gotoplayer = true;
    }

    void OnTriggerExit2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
            gotoplayer = false;
    }
    void FixedUpdate()
    {
        if (target == null)
        {
            FindPlayer();
            return;
        }
        
        if (gotoplayer == true)
        {
            GeneralRoutine = false;
            if (Vector3.Distance(transform.position, target.position) > 1f)
            {
                if(transform.position.x > target.position.x)
                {
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }
                    
                else
                {
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
                    
            }
        }
        else if (GeneralRoutine == false)
        {
            if (transform.position.x > posIn)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                if (transform.position.x < posIn)
                        transform.position = new Vector3 (posIn,transform.position.y,0);
            }
                
            else if (transform.position.x < posIn)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                if (transform.position.x > posIn)
                    transform.position = new Vector3(posIn, transform.position.y, 0);

            }
            else

            if (transform.position.x == posIn )
                GeneralRoutine = true;


               
        }

        if ((target.position.x < transform.position.x /*|| posIn<transform.position.x*/) && FacingRight == true)
        {
            FlipEnemy();
        }
        else if ((target.position.x > transform.position.x /*|| posIn > transform.position.x*/) && FacingRight == false)
        {
            FlipEnemy();
        }

       if (GeneralRoutine == true)
        {
            if (transform.position.x > posIn + nr)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                if (transform.position.x < posIn + nr)
                    transform.position = new Vector3(posIn+nr, transform.position.y, 0);
            }

            else if (transform.position.x < posIn + nr)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                if (transform.position.x > posIn + nr)
                    transform.position = new Vector3(posIn + nr, transform.position.y, 0);
            }
            else if (transform.position.x == posIn + nr)
            {
                nr = -nr;
            }
        }
    }

    private void FlipEnemy()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
