using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarHaz : Hazard {

	public override void Effect(GameObject other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().speed = 1.5f;
            Debug.Log("ill slow you");
        }
    }
}
