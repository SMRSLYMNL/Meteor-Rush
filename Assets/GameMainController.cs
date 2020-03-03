using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainController : MonoBehaviour
{

    public float speed = 0.1f;
    private GameObject[] enemies;
    private static GameObject heart1;
    private static GameObject heart2;
    private static GameObject heart3;
    private static int numberOfDeath = 0;
    private static int score = 0;
    private GameObject player;
    private GameObject scoreGameObject;
    private GameObject spawner;
    private Text scoreText;

    public Sprite aliveHeart = null;
    public Sprite deadHeart = null;

    private void Awake()
    {
        heart1 = GameObject.FindGameObjectWithTag("Heart1");
        heart2 = GameObject.FindGameObjectWithTag("Heart2");
        heart3 = GameObject.FindGameObjectWithTag("Heart3");
        spawner = GameObject.FindGameObjectWithTag("Respawn");
        scoreGameObject = GameObject.FindGameObjectWithTag("ScoreText");
        scoreText = scoreGameObject.GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfDeath = 0;
        score = 0;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("YES");

        if (col.collider.tag.Equals("Player"))
        {
            Debug.Log(col.otherCollider.tag);
            Debug.Log("YESS");
            numberOfDeath++;

            if (numberOfDeath == 1)
            {
                heart1.GetComponent<Image>().sprite = deadHeart;
            }
            if (numberOfDeath == 2)
            {
                heart2.GetComponent<Image>().sprite = deadHeart;
            }
            if (numberOfDeath == 3)
            {
                heart3.GetComponent<Image>().sprite = deadHeart;
            }

            if (numberOfDeath >= 3)
            {

                Destroy(col.otherCollider); // destroy the grenade
                Destroy(col.collider);
                Destroy(spawner);

                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }
            }

            else
            {
                enemies = GameObject.FindGameObjectsWithTag("Enemy");

                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }

                GameObject player1 = Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.identity);

                Destroy(player);
                Destroy(col.otherCollider);

                player = player1;
            }
        }

        else if (col.collider.tag.Equals("DeathZone"))
        {
            Debug.Log(col.otherCollider.tag);
            Debug.Log("YESSS");

            Destroy(col.otherCollider);

            score++;
            scoreText.text = "Score: " + score;
        }

    }

}
