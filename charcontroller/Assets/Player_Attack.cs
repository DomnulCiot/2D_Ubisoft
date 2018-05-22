using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour {

    public Enemy_HEalth enemy;
    public int player_dmg;
    float timer = 0;
    public float time;
	void Start () {
		
	}
	
    void OnTriggerStay2D (Collider2D col)
    {
        if (col.tag == "ENEM")
        {
            enemy = col.GetComponent<Enemy_HEalth>();
            if (Input.GetKeyDown("k") && timer == time)
            {
                enemy.life -= player_dmg;
                        timer = 0;
            }
            
            
        }
            
    }
    void OnTriggerExit2D (Collider2D col)
    {
        enemy = null;
    }

	// Update is called once per frame
	void Update () {
        if (timer < time)
            timer += 0.5f;
	}
}
