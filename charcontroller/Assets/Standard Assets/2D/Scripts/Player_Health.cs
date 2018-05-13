using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;


public class Player_Health : MonoBehaviour {

    public int curHealth;
    public int maxHealth = 100;
    private Rigidbody2D rb2D;
	// Use this for initialization
	void Start () {
        curHealth = maxHealth;
        rb2D = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (curHealth > maxHealth)
            curHealth = maxHealth;
        if (curHealth <= 0)
            Die();
	}


    void Die ()
    {
  
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   public void Damage (int Dmg)
    {
        curHealth -= Dmg;
    }

    public IEnumerator KnockBack (float Duration , float PowerOfKnockBack , Vector3 DirectionOfKnockBack)
    {
        float timer = 0;

        while (Duration>=timer)
        {
            timer += Time.deltaTime;
            rb2D.AddForce(new Vector3(DirectionOfKnockBack.x * 0 -700, DirectionOfKnockBack.y * PowerOfKnockBack , DirectionOfKnockBack.z));
        }
        yield return 0;
    }
}
