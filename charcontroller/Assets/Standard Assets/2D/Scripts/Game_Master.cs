﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Master : MonoBehaviour {

    public Player_Health player;

    public static Game_Master gm;
    void Start ()
    {
        if (gm==null)
            gm=GameObject.FindGameObjectWithTag("GM").GetComponent<Game_Master>();

    }

    public Transform playerPreFab;
    public Transform spawnPoint;

    public void RespawnPlayer ()
    {
        Instantiate(playerPreFab, spawnPoint.position, spawnPoint.rotation);
        player.curHealth = player.maxHealth;

    }


	public static void killPlayer (GameObject player)
    {
            Destroy(player);
        gm.RespawnPlayer();
    }
        
}
