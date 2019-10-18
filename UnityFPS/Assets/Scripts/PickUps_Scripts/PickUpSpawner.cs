using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour {

    public PickUps pickupprefab1;
    public PickUps pickupprefab2;
    public PickUps pickupprefab3;
    public PickUps pickupprefab4;

    private int whospawns;


    // Use this for initialization
    void Start () {
        whospawns = Random.Range(1, 5);

        if(whospawns == 1) {
            Instantiate(pickupprefab1, transform.position, transform.rotation);
        }else if(whospawns == 2){
            Instantiate(pickupprefab2, transform.position, transform.rotation);
        }
        else if (whospawns == 3)
        {
            Instantiate(pickupprefab3, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(pickupprefab4, transform.position, transform.rotation);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
