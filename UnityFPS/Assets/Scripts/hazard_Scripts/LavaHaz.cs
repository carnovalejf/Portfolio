using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaHaz : Hazard {

    public override void Effect(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().ReduceHealth(30);
            Debug.Log("ouchie lava hot");
        }
    }
}
