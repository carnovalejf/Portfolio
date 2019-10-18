using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float startTime;
    public float time;
    public bool stop = false;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            time = Time.time - startTime;
        }
    }
}
