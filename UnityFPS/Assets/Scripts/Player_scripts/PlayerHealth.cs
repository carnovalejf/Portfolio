using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    private Player playerControl;
    private Player2 playerControl2;
    Animator animator;

    GameObject[] players;

    public int health;
    int maxhealth = 100;
    bool isDead = false;

    public HUD hud;
    Timer timer;
    SceneMenuManager sceneMan;

    // Use this for initialization
    void Start () {
        health = maxhealth;
        if (GetComponent<Player>())
        {
            playerControl = GetComponent<Player>();
        }else if (GetComponent<Player2>())
        {
            playerControl2 = GetComponent<Player2>();
        }
        animator = GetComponent<Animator>();
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        sceneMan = GameObject.FindWithTag("SceneMan").GetComponent<SceneMenuManager>();
        players = GameObject.FindGameObjectsWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        hud.UpdateHealthBar(health, maxhealth);
        Alive();

        if(isDead)
        {
            for(int i = 0; i<players.Length; i++)
            {
                if (players[i].GetComponent<PlayerHealth>())
                {
                    players[i].GetComponent<PlayerHealth>().Die();
                }
            }
            
        }
	}

    //private void OnControllerColliderHit(ControllerColliderHit c)
    //{
       // if (c.gameObject.CompareTag("Enemy"))
      //  {
            //need to set a invulnerability timer
            //health -= c.gameObject.GetComponent<Enemy>().getDamage();
   //     }
  //  }

    private void Alive()
    {
        if (!isDead)
        {
            if (health <= 0)
            {
                isDead = true;
                Score score = GameObject.FindWithTag("Score").GetComponent<Score>();
                score.EndGameBonus(timer.time);
                sceneMan.gameEnd = true;
            }
        }
    }

    public void Die()
    {
        if (GetComponent<Player>())
        {
            Destroy(playerControl);
        }
        if (GetComponent<Player2>())
        {
            Destroy(playerControl2);
        }
        animator.SetBool("isDead", true);
        hud.dead = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("EnemyProjectile"))
        {
            ReduceHealth(other.collider.GetComponent<EnemyProjectile>().GetDamage());
        }
    }

    public void ReduceHealth(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            health = 0;
        }
    }

    public void IncreaseHealth(int amount)
    {
        health += amount;
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }

    public int getHealth()
    {
        return health;
    }
}
