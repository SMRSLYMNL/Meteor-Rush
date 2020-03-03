using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject gameOverCanvas;
    public AudioClip gameOver;
    private AudioSource m_MyAudioSource;
    public AudioClip background;

    public Text currentScore;

    public Image heart3;
    public Sprite dead;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        m_MyAudioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        m_MyAudioSource.clip = background;
        m_MyAudioSource.Play();
    }

    void Update()
    {
        if(heart3.sprite == dead)
        {
            GameObject spawner = GameObject.FindGameObjectWithTag("Respawn");
            Destroy(spawner);
            
            m_MyAudioSource.Stop();
            //m_MyAudioSource.clip = gameOver;
            //m_MyAudioSource.Play();
            gameOverCanvas.SetActive(true);
            mainCanvas.SetActive(false);
            gameOverCanvas.GetComponentsInChildren<Text>()[0].text = currentScore.text;

        }
    }
}
