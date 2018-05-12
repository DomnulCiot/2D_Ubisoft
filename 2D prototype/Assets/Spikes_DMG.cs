using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes_DMG : MonoBehaviour {

    public Player_Health player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Health>();
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
            player.Damage(10);

        StartCoroutine(player.KnockBack(0.02f, 350f, player.transform.position));
    }
}
