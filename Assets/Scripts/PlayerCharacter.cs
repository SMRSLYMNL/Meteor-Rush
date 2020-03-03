using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// A character
/// </summary>
public class PlayerCharacter : MonoBehaviour
{
    // saved for efficiency
    float colliderHalfWidth;
    float colliderHalfHeight;

    public float speed = 0.01f;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite alive;
    public Sprite dead;

    public GameObject spawner;
    public GameObject player;

    public AudioClip gameOver;
    public AudioClip death;

    private AudioSource audioSource;

    private bool left = true;
    private bool right = false;

    private bool collapsedLeft = false;
    private bool collapsedRight = false;

    private Vector3 dirLeft;
    private Vector3 dirRight;

    private Rigidbody2D rb;

    private GameObject[] enemies;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // save for efficiency
        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
        colliderHalfWidth = collider.bounds.size.x / 2;
        colliderHalfHeight = collider.bounds.size.y / 2;

        dirLeft = Quaternion.AngleAxis(180, Vector3.forward) * Vector3.right;
        dirRight = Quaternion.AngleAxis(0, Vector3.forward) * Vector3.right;

        left = true;
        right = false;

        collapsedLeft = false;
        collapsedRight = false;

        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(dirLeft * speed);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //rb = gameObject.GetComponent<Rigidbody2D>();
            //rb.AddForce(transform.right * 2 * speed);

            Debug.Log("OKKKKKK     " + transform.eulerAngles.z);

            if (transform.eulerAngles.z >= 10 && transform.eulerAngles.z <= 40 && !collapsedRight)
            {
                Debug.Log("OK1");
                gameObject.transform.Rotate(0, 0, -8, Space.Self);
            }
            if(transform.eulerAngles.z < 10 && transform.eulerAngles.z >= 0 && !collapsedRight)
            {
                Debug.Log("OK2");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (((transform.eulerAngles.z >= 342 && transform.eulerAngles.z <= 360) || transform.eulerAngles.z == 0) && !collapsedRight)
            {
                Debug.Log("OK3");
                gameObject.transform.Rotate(0, 0, -2, Space.Self);
            }
            if(transform.eulerAngles.z < 342 && transform.eulerAngles.z > 340 && !collapsedRight)
            {
                Debug.Log("OK4");
                transform.eulerAngles = new Vector3(0, 0, 340);
            }
            
            if(!right)
            {
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(dirRight * 2 * speed);

                right = true;
                left = false;
            }
        }
        else
        {
            //rb = gameObject.GetComponent<Rigidbody2D>();
            //rb.AddForce(transform.right * (-2) * speed);


            if ((transform.eulerAngles.z >= 320 && transform.eulerAngles.z <= 350 && !collapsedLeft))
            {
                Debug.Log("OKK1");
                gameObject.transform.Rotate(0, 0, 8, Space.Self);
            }
            if ((transform.eulerAngles.z > 350 && transform.eulerAngles.z <= 360 && !collapsedLeft))
            {
                Debug.Log("OKK2");
                transform.eulerAngles = new Vector3(0, 0, 0);
            }


            if(transform.eulerAngles.z >= 0 && transform.eulerAngles.z <= 18 && !collapsedLeft)
            {
                Debug.Log("OKK3");
                gameObject.transform.Rotate(0, 0, 2, Space.Self);
            }
            if (transform.eulerAngles.z > 18 && transform.eulerAngles.z < 20 && !collapsedLeft)
            {
                Debug.Log("OKK4");
                transform.eulerAngles = new Vector3(0, 0, 20);
            }

            if (!left)
            {
                rb = gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(dirLeft * 2 * speed);
                left = true;
                right = false;
            }
        }

        ClampInScreen();
        
    }


    /// <summary>
    /// Clamps the character in the screen
    /// </summary>
    void ClampInScreen()
    {
        EdgeCollider2D collider = GetComponent<EdgeCollider2D>();
        // clamp position as necessary
        Vector3 position = transform.position;
        if (position.x - collider.bounds.size.x / 2 < ScreenUtils.ScreenLeft)
        {
            position.x = ScreenUtils.ScreenLeft + collider.bounds.size.x / 2;

            Debug.Log(transform.eulerAngles.z + "   ddds");

            //if (transform.eulerAngles.z < 0)
            //    transform.eulerAngles = new Vector3(0, 0, 0);

            if (transform.eulerAngles.z > 270 && transform.eulerAngles.z < 350)
            {
                transform.Rotate(0, 0, 5, Space.Self);
            }
            if (transform.eulerAngles.z >= 350 && transform.eulerAngles.z < 359)
            {
                transform.Rotate(0, 0, 1, Space.Self);
            }

            if (transform.eulerAngles.z < 90 && transform.eulerAngles.z > 10)
            {
                transform.Rotate(0, 0, -5, Space.Self);
            }

            if (transform.eulerAngles.z <= 10 && transform.eulerAngles.z > 1)
            {
                transform.Rotate(0, 0, -1, Space.Self);
            }

            if ((transform.eulerAngles.z <= 1 && transform.eulerAngles.z > 0) || (transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 359))
            {
                //transform.Rotate(0, 0, 0 - transform.eulerAngles.z, Space.Self);
                transform.eulerAngles = new Vector3(0, 0, 0);

                Debug.Log("TRUEEE");
            }

            collapsedLeft = true;
            collapsedRight = false;
        }
        else if (position.x + collider.bounds.size.x / 2 > ScreenUtils.ScreenRight)
        {
            position.x = ScreenUtils.ScreenRight - collider.bounds.size.x / 2;

            Debug.Log(transform.eulerAngles.z + "   eees");

            //if (transform.eulerAngles.z < 0)
            //    transform.eulerAngles = new Vector3(0, 0, 0);

            float currentAngleFloat = transform.eulerAngles.z;
            int currentAngle = (int) Mathf.Round(currentAngleFloat);

            if (transform.eulerAngles.z > 270 && transform.eulerAngles.z < 350)
            {
                transform.Rotate(0, 0, 5, Space.Self);
            }
            if (transform.eulerAngles.z >= 350 && transform.eulerAngles.z < 359)
            {
                transform.Rotate(0, 0, 1, Space.Self);
            }

            if (transform.eulerAngles.z < 90 && transform.eulerAngles.z > 10)
            {
                transform.Rotate(0, 0, -5, Space.Self);
            }

            if (transform.eulerAngles.z <= 10 && transform.eulerAngles.z > 1)
            {
                transform.Rotate(0, 0, -1, Space.Self);
            }

            if ((transform.eulerAngles.z <= 1 && transform.eulerAngles.z > 0) || (transform.eulerAngles.z < 360 && transform.eulerAngles.z >= 359))
            {
                //transform.Rotate(0, 0, 0 - transform.eulerAngles.z, Space.Self);
                transform.eulerAngles = new Vector3(0, 0, 0);

                Debug.Log("TRUEEE");
            }

            collapsedRight = true;
            collapsedLeft = false;
        }
        else
        {
            collapsedLeft = false;
            collapsedRight = false;
        }
        
        transform.position = position;
    }


    void OnCollisionEnter2D(Collision2D col)
    {

        Debug.Log("YES");

        if (col.collider.tag.Equals("Enemy"))
        {
            Debug.Log("YEEEES");
            if (heart1.sprite == alive)
            {
                heart1.GetComponent<Image>().sprite = dead;
            }
            else if (heart2.sprite == alive)
            {
                heart2.GetComponent<Image>().sprite = dead;
            }
            else if (heart3.sprite == alive)
            {
                heart3.GetComponent<Image>().sprite = dead;
            }

            if(heart3.sprite == dead)
            {
                Destroy(gameObject);
                spawner = null;

                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }
            }

            else
            {
                audioSource.pitch = 0.5f;
                audioSource.PlayOneShot(death, 1.5f);

                enemies = GameObject.FindGameObjectsWithTag("Enemy");

                for (int i = 0; i < enemies.Length; i++)
                {
                    Destroy(enemies[i]);
                }

                Instantiate(player, new Vector3(0, -2.5f, 0), Quaternion.identity);

                Destroy(gameObject);

                GameObject.FindGameObjectWithTag("IncreaseSpeed").transform.position = new Vector3(0.03f, 0, 0);

                audioSource.pitch = 1;

            }
        }
    }
    

}
 
 