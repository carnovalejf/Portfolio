using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PickUps {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().SpeedBoost();
            Debug.Log("FFFFAAAAAAST");
            Destroy(gameObject);
        }
    }
}
