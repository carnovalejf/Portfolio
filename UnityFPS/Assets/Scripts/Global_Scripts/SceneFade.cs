using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    float fadeAmount;

    public Image image;

    Score score;
    Timer timer;

    public Text timerText;
    public Text scoreText;

    public GameObject overlay;

    float time;
    private float alpha;
    // Use this for initialization
    void Start()
    {
        fadeAmount = 0.5f;
        alpha = 1.0f;
        overlay.SetActive(false);
        score = GameObject.FindWithTag("Score").GetComponent<Score>();
        timer = GameObject.FindWithTag("Timer").GetComponent<Timer>();
        time = timer.time;
    }

    // Update is called once per frame
    void Update()
    {
        Color imgColor = image.color;
        float alphaDiff = Mathf.Abs(imgColor.a - alpha);
        if (alphaDiff > 0.0f)
        {
            imgColor.a = Mathf.Lerp(imgColor.a, alpha, fadeAmount * Time.deltaTime);
            image.color = imgColor;
        }

        if (alphaDiff <= 0.01f)
        {
            overlay.SetActive(true);
            string minutes = ((int)time / 60).ToString();
            string seconds = (time % 60).ToString("f2");

            timerText.text = "You lasted: " + minutes + ":" + seconds;
            scoreText.text = "Your score was: " + score.GetScore().ToString();
        }

    }
}