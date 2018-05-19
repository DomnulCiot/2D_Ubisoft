using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementControl : MonoBehaviour {

    public Vector3 pos1 = new Vector3(-4, 0, 0);
    public Vector3 pos2 = new Vector3(4, 0, 0);
    public float speed = 10.0f;
    private CanBeDetected player;
    public Transform target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CanBeDetected>();
    }
    void Update()
    {
        if (player.gotoplayer == true)
        {
            if (Vector3.Distance(transform.position, target.position) > 1f)
            {
                if(transform.position.x > target.position.x)
                    transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                else
                    transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
        }
    }
}
