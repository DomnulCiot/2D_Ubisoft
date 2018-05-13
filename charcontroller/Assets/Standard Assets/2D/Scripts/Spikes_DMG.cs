using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_DMG : MonoBehaviour
{

    public Player_Health player;
    float TimeSearch = 0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }

    void Update()
    {
        if (player != null)
        {
            FindPlayer();
            return;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.CompareTag("Player"))
            player.Damage(10);
        if (player == null)
        {
            FindPlayer();
            return;
        }
        StartCoroutine(player.KnockBack(0.02f, 350f, player.transform.position));
    }
    void FindPlayer()
    {
        if (TimeSearch <= Time.time)
        {
            GameObject Search = GameObject.FindGameObjectWithTag("Player");
            if (Search != null)
                player = Search.GetComponent<Player_Health>();
            TimeSearch = Time.time + 0.5f;
        }
    }
}
