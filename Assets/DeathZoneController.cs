using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathZoneController : MonoBehaviour
{

    public Text scoreText;

    private int currentScore;
    private string scoreString;

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);

        scoreString = scoreText.text.ToString();
        Debug.Log("Before: " + scoreString);

        Debug.Log("Length: " + scoreString.Length);

        scoreString = scoreString.Substring(7);

        currentScore = int.Parse(scoreString);
        currentScore++;

        scoreText.text = "Score: " + currentScore;

    }
}
