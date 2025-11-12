using TMPro;
using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(scoreCounter());
    }

    IEnumerator scoreCounter()
    {
        //increase the players score
        yield return new WaitForSeconds(0.1f);

        score++;
        scoreText.text = "Score: " + score.ToString();

        StartCoroutine(scoreCounter());
    }
}
