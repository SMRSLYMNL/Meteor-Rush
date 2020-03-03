using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticMoveTarget : MonoBehaviour
{
    public float speed = 0.001f;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count == 2)
        {
            if (Input.GetMouseButton(0))
            {
                gameObject.transform.Translate(Vector3.up * speed);
            }
            else
                gameObject.transform.Translate(Vector3.up * (-1) * speed);

            count = 0;
        }

        
    }
}
