using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoost : PickUps {

    public override void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().ScoreBoost();
            Debug.Log("MORE POINTS");
            Destroy(gameObject);
        }
    }
}
