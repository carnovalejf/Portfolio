using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EyeEnemy : MonoBehaviour {
    Transform player;

    protected GameObject[] players;
    protected bool multiPlayer;

    public Transform projectileSpawn;
    public GameObject projectile;

    protected EnemyHealth health;

    protected int damage;

    void Start()
    {
        damage = 15;

        health = GetComponent<EnemyHealth>();
        health.health = 100;
        health.spawner = false;
        health.scoreValue = 500;

        players = GameObject.FindGameObjectsWithTag("Target");
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

        for (int i = 0; i < players.Length; i++)
        {
            if (Vector3.Distance(transform.position, players[i].transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, players[i].transform.position);
                player = players[i].transform;
            }
        }
        if (distance <= 100.0f)
        {
            transform.LookAt(player);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartCoroutine("Shooting");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StopCoroutine("Shooting");
        }
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }
}
