using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour {
    Score score;
    Timer timer;

    public Text healthText;
    public Text timerText;
    public Text scoreText;

    public Image barFill;
    public Image speedBoost;
    public Image damageBoost;
    public Image scoreBoost;

    float time;

    private bool speedBoosted;
    private bool damageBoosted;
    private bool scoreBoosted;

    public bool dead;

    public void Start()
    {
        
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
    }

    public void Update()
    {
        if (speedBoosted)
        {
            speedBoost.fillAmount = 1;
        }
        else
        {
            speedBoost.fillAmount = 0;
        }

        if (damageBoosted)
        {
            damageBoost.fillAmount = 1;
        }
        else
        {
            damageBoost.fillAmount = 0;
        }

        if (scoreBoosted)
        {
            scoreBoost.fillAmount = 1;
        }
        else
        {
            scoreBoost.fillAmount = 0;
        }

        
        if (!dead)
        {
            time = timer.time;
        }
        
        string minutes = ((int)time / 60).ToString();
        string seconds = (time % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
        scoreText.text = score.GetScore().ToString();
    }

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        float damageTaken = maxHealth - currentHealth;
        barFill.fillAmount = (maxHealth - damageTaken) / 100;
        healthText.text = currentHealth.ToString();

    }

    public void UpdateBuff(bool active, string buff)
    {
        if (active)
        {
            if(buff == "speed")
            {
                speedBoosted = true;
            }else if(buff == "damage")
            {
                damageBoosted = true;

            }
            else if(buff == "score")
            {
                scoreBoosted = true;
            }
        }
        else
        {
            if (buff == "speed")
            {
                speedBoosted = false;
            }
            else if (buff == "damage")
            {
                damageBoosted = false;

            }
            else if (buff == "score")
            {
                scoreBoosted = false;
            }
        }
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
