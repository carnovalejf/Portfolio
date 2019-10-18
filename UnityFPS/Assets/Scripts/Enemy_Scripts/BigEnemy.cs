using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigEnemy : Enemy {

	// Use this for initialization
	void Start () {
        damage = 25;
        cooldown = 4.0f;
        rotationSpeed = 20f;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        target = GameObject.FindGameObjectWithTag("Player");
        health.health = 250;
        health.spawner = true;
        health.scoreValue = 1000;
        players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 1)
        {
            multiPlayer = true;
        }
        else
        {
            multiPlayer = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        float distance = 1000000f;

        cooldown -= Time.deltaTime;
        for (int i = 0; i < players.Length; i++)
        {
            if (Vector3.Distance(transform.position, players[i].transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, players[i].transform.position);
                target = players[i];
            }
        }
        if (distance <= 1000.0f)
        {
            agent.destination = target.transform.localPosition;
            animator.SetFloat("speed", 1.0f);
        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }
        agent.stoppingDistance = 2.0f;

        if (distance <= 2.0f)
        {
            RotateTowards(target.transform);
            animator.SetFloat("speed", 0.0f);
        }

        if (distance <= 2.0f)
        {
            if (cooldown <= 1.5f)
            {
                animator.SetBool("isAttacking", true);
                
            }
            if(cooldown <= 0.0f)
            {
                Attack();
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    public new void Attack()
    {
        cooldown = 4.0f;
        target.GetComponent<PlayerHealth>().ReduceHealth(damage);

    }

}
