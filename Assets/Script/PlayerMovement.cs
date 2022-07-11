using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float speed= 5f;
    private bool turning = false;
    private Rigidbody2D body;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float moving ;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
      
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            direction  = Vector3.up * speed;
            direction.x += moving;
           
            var change = transform.localScale.x;
            if (turning == true)
            { 
                change *=  -1; 
            } if (change > 0.001) {
                    transform.localScale = new Vector3(5, 5, 5);

                    direction.x = +moving;
                    turning = false;
                } else if ( change < -0.001)
                {
                    transform.localScale = new Vector3(-5, 5, 5);
                    direction.x = -moving;
                    turning = false;
                }
        }


    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "wallLeft" || collision.gameObject.tag == "wallRight")
        {   
             turning = true;
            Debug.Log(turning);
        } 
        
    }
 
}
