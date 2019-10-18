using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    protected GameObject target;
    protected GameObject[] players;
    protected bool multiPlayer;

    protected NavMeshAgent agent;
    protected Animator animator;
    protected EnemyHealth health;

    protected int damage;
    protected float cooldown;
    protected float rotationSpeed;

    // Use this for initialization
    void Start() {
        damage = 5;
        cooldown = 1.5f;
        rotationSpeed = 20f;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        health = GetComponent<EnemyHealth>();
        health.health = 20;
        health.spawner = false;
        health.scoreValue = 100;
        players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length > 1)
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
        for (int i = 0; i <players.Length; i++)
        {
            if(Vector3.Distance(transform.position, players[i].transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, players[i].transform.position);
                target = players[i];
            }
        }
       
        if (distance <= 100.0f)
        {
            agent.destination = target.transform.localPosition;
            animator.SetFloat("speed", 1.0f);
        }
        else
        {
            animator.SetFloat("speed", 0.0f);
        }
        agent.stoppingDistance = 2.0f;
        
        if(distance <= 2.0f)
        {
            RotateTowards(target.transform);
            animator.SetFloat("speed", 0.0f);
        }

        if (distance <= 2.0f)
        {
            if (cooldown <= 0)
            {
                Attack();
            }
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }

        
    }

    public int getDamage()
    {
        return damage;
    }

    public void Attack()
    {
        animator.SetBool("isAttacking", true);
        cooldown = 1.5f;
        target.GetComponent<PlayerHealth>().ReduceHealth(damage);
        
    }

    protected void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
