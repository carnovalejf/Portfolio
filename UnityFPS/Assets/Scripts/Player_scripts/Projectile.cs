using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    //int currentProjectile = 1;

    public float projectileLife;
    public float projectileForce;
    public int projectileDmg;

    Rigidbody rb;
	// Use this for initialization
	void Start () {
		if(projectileLife <= 0) {
            projectileLife = 2.0f;
        }

        if(projectileForce <= 0) {
            projectileForce = 20.0f;
        }

        rb = GetComponent<Rigidbody>();
        if (!rb) {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        

        Destroy(gameObject, projectileLife);
        rb.AddForce(transform.forward * projectileForce, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnCollisionEnter(Collision c) {

            Destroy(gameObject);

    }

    public void SetDamage(int dmg)
    {
        projectileDmg = dmg;
    }
    public int GetDamage()
    {
        return projectileDmg;
    }
}
