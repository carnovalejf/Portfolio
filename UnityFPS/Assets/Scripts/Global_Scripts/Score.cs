using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int score;
    public bool boosted;
	// Use this for initialization
	void Start () {
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void IncreaseScore(int score_)
    {
        if (boosted)
        {
            score += score_ * 2;
        }
        else
        {
            score += score_;
        }
    }
    public int GetScore()
    {
        return score;
    }

    public void EndGameBonus(float time_)
    {
        score += (int)time_ * 10;
    }
}
