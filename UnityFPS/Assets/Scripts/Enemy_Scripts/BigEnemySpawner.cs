using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemySpawner : MonoBehaviour {

    public BigEnemy toSpawn;

    public int cap;

    public float spawnRate;

    float timeTillSpawn;

    Timer timer;

    GameObject[] enemies;
    // Use this for initialization
    void Start()
    {

        cap = 5;
        spawnRate = 30.0f;
        timeTillSpawn = 20.0f;
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();

    }

    // Update is called once per frame
    void Update()
    {
        timeTillSpawn -= Time.deltaTime;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        int amount = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<BigEnemy>())
            {
                amount++;
            }
        }

        if (amount < cap)
        {
            if (timeTillSpawn <= 0.0f)
            {
                Instantiate(toSpawn, transform.position, transform.rotation);
                timeTillSpawn = spawnRate;
            }
        }
    }
}
