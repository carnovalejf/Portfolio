using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    //int currentProjectile = 1;

    public float projectileLife;
    public float projectileForce;
    public int projectileDmg;

    Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        projectileDmg = 20;
        if (projectileLife <= 0)
        {
            projectileLife = 5.0f;
        }

        if (projectileForce <= 0)
        {
            projectileForce = 40.0f;
        }

        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        Destroy(gameObject, projectileLife);
        rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision c)
    {
        if (!(c.gameObject.CompareTag("Projectile")))
        {
            Destroy(gameObject);
        }
        

    }

    public int GetDamage()
    {
        return projectileDmg;
    }
}
