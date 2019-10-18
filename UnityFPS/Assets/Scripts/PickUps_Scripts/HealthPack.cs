using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : PickUps {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().IncreaseHealth(50);
            Debug.Log("healbaby!");
            Destroy(gameObject);
        }
    }
}
