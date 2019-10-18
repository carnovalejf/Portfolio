using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour {

    Score score;
    public int scoreValue;

    Animator animator;
    NavMeshAgent agent;
    PickUpSpawner spawn;

    public int health;
    public bool spawner;
    float timeOfDeath = 0.0f;

    bool isDead = false;

    // Use this for initialization
    void Start () {
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        spawn = GetComponent<PickUpSpawner>();
	}
	
	// Update is called once per frame
	void Update () {
        timeOfDeath -= Time.deltaTime;
        Alive();

        if (isDead && timeOfDeath < 0.0f)
        {
            Die();
        }

        if(isDead && timeOfDeath <= 0.1f)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Projectile")){
            ReduceHealth(other.collider.GetComponent<Projectile>().GetDamage());
        }
    }

    private void ReduceHealth(int amount)
    {
        health -= amount;
        if(health < 0)
        {
            health = 0;
        }
    }

    private void Alive()
    {
        if (health <= 0)
        {
            isDead = true;
        }
    }

    private void Die()
    {
        score.IncreaseScore(scoreValue);

        timeOfDeath = 5.0f;
        if (spawner)
        {
            spawn.enabled = true;
        }
        Destroy(agent);
        if (GetComponent<Enemy>())
        {
            Destroy(GetComponent<Enemy>());
        }else if (GetComponent<EyeEnemy>())
        {
            Destroy(GetComponent<EyeEnemy>());
        }
        if (!GetComponent<EyeEnemy>())
        {
            animator.SetBool("isDead", true);
        }
    }
}
