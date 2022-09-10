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
    public GameObject cherry;

    [SerializeField] private float speed = 5f;
    private bool turning = false;
    public MapRotation mapRotation;
    private Rigidbody2D body;
    private Vector3 direction;
    private float gravity = -9.8f;
    public float moving;
    public float size;
    private bool isPause;

    private bool isGrounded = false;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }
    private void Start()
    {
        size = 5;
        isPause = true;
       
    }

    private void Update()
    {   if (movingTutorial.activeSelf == true )
        {
            isPause = true;
        }


        if (Mathf.Abs(transform.position.x - 3.5f) <= 1 && directionTutorial != null)
        {
            isPause = true;
            directionTutorial.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                isPause = false;
                if (directionTutorial != null)
                    Destroy(directionTutorial);
            }
        }
        else if (transform.position.x < -1.5f && winTutorial != null && avoidTutorial != null)
        {
            isPause = true;
            winTutorial.SetActive(true);
            avoidTutorial.SetActive(true);
            spike.SetActive(true);
            cherry.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                isPause = false;
                if (winTutorial != null && avoidTutorial != null)
                {
                    Destroy(winTutorial);
                    Destroy(avoidTutorial);
                }

            }
        }

        Debug.Log(Time.timeScale);
        if (isPause)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;

        direction.y += gravity * Time.deltaTime;



        if (!isGrounded)
            transform.position += direction * Time.deltaTime;

      
        if (Input.GetMouseButtonDown(0))
        {

            movingTutorial.SetActive(false);

            this.isPause = false;
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

        }
        else if (change < -0.00001)
        {
            transform.localScale = new Vector3(-size, size, size);
            direction.x = -moving;
            turning = false;
        }


        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wallLeft" || collision.gameObject.tag == "wallRight")
        {
            turning = true;

        }

        if (collision.gameObject.tag == "wallBottom")
        {
            isGrounded = true;
        }

    }

}
