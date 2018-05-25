using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{

    public Enemy_HEalth enemy;
    public int player_dmg;
    public int dash_dmg;
    float timer = 0;
    public float time;
    public dash DASH;
    public Transform Player;
    public Transform Enemy;

    void Start()
    {

    }

    void Dash_Attack ()
    {
        enemy.life -= player_dmg + dash_dmg;
        if (Player.position.x < Enemy.position.x)
            Player.position = new Vector2(Enemy.position.x + Enemy.localScale.x + 0.5f, Enemy.position.y);
        else if (Player.position.x > Enemy.position.x)
            Player.position = new Vector2(-Enemy.position.x - Enemy.localScale.x - 0.5f, Enemy.position.y);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "ENEM")
        {
            enemy = col.GetComponent<Enemy_HEalth>();
            Enemy = col.GetComponent<Transform>();
            if (Input.GetKeyDown("k") && timer == time)
            {
                enemy.life -= player_dmg;
                timer = 0;
            }

            if (DASH.IsDashing == true)
                Dash_Attack();
          


        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        enemy = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < time)
            timer += 0.5f;
    }
}