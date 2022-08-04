using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Spike : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
   
    private bool movingUp;
    [SerializeField] private float movementDistance;
    private float minEdge;
    private float maxEdge;



    private void Awake()
    {
        minEdge = transform.localScale.y;
        maxEdge = transform.localScale.y + movementDistance;

    }

    private void Update()
    {



        if (movingUp)
        {
            if (transform.localScale.y > minEdge )
            {

                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y - speed * Time.deltaTime);

            }
            else
                movingUp = false;
        }
        else
        {
            if (transform.localScale.y < maxEdge)
            {

                transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y + speed * Time.deltaTime);

            }
            else
                movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            collision.GetComponent<Health>().TakeDamage(damage);
    }
  
}
