using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCharacter : MonoBehaviour
{

    private float speed;
    private Rigidbody2D rb;

    private int speedIncrease = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.FindGameObjectWithTag("IncreaseSpeed").transform.position.x;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * (-1) * speed);

        Debug.Log(speed + "    speed");
    }
}
