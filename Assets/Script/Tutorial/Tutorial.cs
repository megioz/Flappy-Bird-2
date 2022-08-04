using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public GameObject movingTutorial;
    public GameObject directionTutorial;
    public GameObject winTutorial;
    public GameObject avoidTutorial;
    public GameObject spike;

    [SerializeField] private float speed = 5f;
    private bool turning = false;
    public MapRotation mapRotation;
    private Rigidbody2D body;
    private Vector3 direction;
    private float gravity = -9.8f;
    public float moving;
    public float size;


    private bool isGrounded = false;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        size = 5;
    }

    private void Update()
    {

      
        direction.y += gravity * Time.deltaTime;



        if (!isGrounded)
            transform.position += direction * Time.deltaTime;
        if (transform.position.x > 3.5f && directionTutorial != null)
        {
            directionTutorial.SetActive(true);

        }
        else if (transform.position.x < 1.5f && winTutorial!= null && avoidTutorial!=null)
        {
         winTutorial.SetActive(true);
            avoidTutorial.SetActive(true);
            spike.SetActive(true);

            if (directionTutorial != null)
            {
                Destroy(directionTutorial);
               
            }
        }
          
        if (Input.GetMouseButtonDown(0))
        {
            movingTutorial.SetActive(false);
            Jump();
        }


    }

    private void Jump()
    {
        direction = Vector3.up * speed;
        direction.x += moving;

        var change = transform.localScale.x;
        if (turning == true)
        {
            change *= -1;
        }
        if (change > 0.0000001)
        {
            transform.localScale = new Vector3(size, size, size);

            direction.x = +moving;
            turning = false;
            if(direction.x == 4)
            {   
                directionTutorial.SetActive(true);
            }
        }
        else if (change < -0.00001)
        {
            transform.localScale = new Vector3(-size, size, size);
            direction.x = -moving;
            turning = false;
        }

        Debug.Log("clicking " + direction);

        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wallLeft" || collision.gameObject.tag == "wallRight")
        {
            turning = true;
            Debug.Log(turning);

            mapRotation.rotate = true;
        }

        if (collision.gameObject.tag == "wallBottom")
        {
            isGrounded = true;

        }



    }

}
