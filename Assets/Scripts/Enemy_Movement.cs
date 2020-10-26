using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{

    public float speed;
    public bool MoveRight;

    void Update()
    {
        if (Input.GetKey("escape"))
        {
        Application.Quit();
        }
        if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed , 0,0);
            transform.localScale= new Vector2 (-0.25f,0.25f);
        }

        else
        {
            transform.Translate(-2 * Time.deltaTime * speed , 0,0);
            transform.localScale= new Vector2 (0.25f,0.25f);
        }
        
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
        {
            if(MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

}
