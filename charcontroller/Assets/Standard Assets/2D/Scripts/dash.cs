using UnityEngine;
using UnityStandardAssets._2D;

public class dash : MonoBehaviour
{

    public PlatformerCharacter2D Speed;
    public float cool = 50;
    public float duration = 0;
    public float increase = 50;
    private float timer;
     float Speed2;
    public float timer2;
    void Awake()
    {
        Speed2 = Speed.m_MaxSpeed;
    }
    public float x;
    void Update()
    {
        if (Input.GetKeyUp("d"))
        {
           timer = 0f;
        }
            if (timer <=0.2 )
                timer+=Time.deltaTime;
        if (Input.GetKeyDown("d") && cool==50 && timer<=0.2)
        {

            Speed.m_MaxSpeed = Speed.m_MaxSpeed + increase;
            duration = 10;
            cool = 0;
        }



        if (Input.GetKeyUp("a"))
        {
            timer2 = 0f;
        }
        if (timer2 <= 0.2)
            timer2 += Time.deltaTime;
        if (Input.GetKeyDown("a") && cool == 50 && timer2 <= 0.2)
        {

            Speed.m_MaxSpeed = Speed.m_MaxSpeed + increase;
            duration = 10;
            cool = 0;
        }




        if (cool < 50)
            cool += 0.5f;
        if (duration > 0)
            duration -= 0.5f;
        else if (duration == 0)
            Speed.m_MaxSpeed = Speed2;
    }
}
