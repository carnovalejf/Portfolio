using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : PickUps {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().DamageBoost();
            Debug.Log("HIT HARD");
            Destroy(gameObject);
        }
    }
}
