using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Enemy : MonoBehaviour {

    public Player_Health HP;
    public int dmg =2;
    public float tm = 100;
    public float timer = 0;
    float TimeSearch = 0;
    public dash DASH;
    void Awake ()
    {
        HP = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }


   void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag ("Player") && timer==tm)
        {
            
                timer = 0;
            if (DASH.IsDashing == false)
                HP.curHealth -= dmg;
            
        }
       


    }
	
	// Update is called once per frame
	void Update () {
		if (timer !=tm)
        {
            timer += 0.5f;
        }

        if (HP != null)
        {
            FindPlayer();
            return;
        }
    }
    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                HP = Search.GetComponent<Player_Health>();
            TimeSearch = Time.time + 0.5f;
        }
    }
}
