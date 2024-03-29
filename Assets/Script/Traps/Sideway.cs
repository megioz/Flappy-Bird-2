using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sideway : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private bool goStraight;
    private bool movingUp;
    private float topEdge;
    private float bottomEdge;


    private void Awake()
    {
        topEdge = transform.position.y - movementDistance;
        bottomEdge = transform.position.y + movementDistance;

    }
    private void Update()
    {   if(goStraight== true){ 
            if (movingUp)
            {
                if (transform.position.y > topEdge)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
                }
                else
                movingUp = false;
        }
            else
        {
            if (transform.position.y < bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = true;
        }
        }
        else { 
            if (movingUp)
            {
                if (transform.position.y > topEdge)
                {
                    transform.position = new Vector2(transform.position.x - 1 * Time.deltaTime, transform.position.y - speed * Time.deltaTime);
                }
                else
                movingUp = false;
            }
                else
            {
                if (transform.position.y < bottomEdge)
                {
                    transform.position = new Vector2(transform.position.x + 1 * Time.deltaTime, transform.position.y + speed * Time.deltaTime);
                }
                else
                    movingUp = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}


 