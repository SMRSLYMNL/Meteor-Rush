using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : MonoBehaviour
{

    public Text score;
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite alive;

    private void OnLevelWasLoaded(int level)
    {
        score.text = "Score: 0";

        heart1.sprite = alive;
        heart2.sprite = alive;
        heart3.sprite = alive;
    }

}
