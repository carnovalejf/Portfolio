using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeEnemySpawner : MonoBehaviour {

    public EyeEnemy toSpawn;

    public int cap;

    public float spawnRate;

    float timeTillSpawn;

    Timer timer;

    GameObject[] enemies;
    // Use this for initialization
    void Start()
    {

        cap = 3;
        spawnRate = 20.0f;
        timeTillSpawn = 10.0f;
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
            if (enemies[i].GetComponent<EyeEnemy>())
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
