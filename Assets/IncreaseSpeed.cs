using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{
    public float speed = 0.01f;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        gameObject.transform.Translate(Vector2.right * speed);
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count == 500)
        {
            gameObject.transform.Translate(Vector2.right * (speed / 10));
            speed = (float) (speed * 1.1);
            count = 0;
        }
    }
}
