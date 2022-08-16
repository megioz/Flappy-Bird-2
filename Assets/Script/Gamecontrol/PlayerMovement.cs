using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float speed= 5f;
    private bool isTurning = false;
    public MapRotation mapRotation;
    private Rigidbody2D body;
    private Vector3 direction;
    private float gravity = -9.8f;
    public float moving ;
    private float size;


    private bool isGrounded = false;
    private float horizontal = 0f;

    public float Size { get => size; set
        {
            size = value;

            //Resize the scale
            transform.localScale = new Vector3( Mathf.Sign(transform.localScale.x) * size, size, size);
        }
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Size = 5;
    }

    private void Update()
    {
        direction.y += gravity * Time.deltaTime;

        if (!isGrounded)
            transform.position += direction * Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        if (!isTurning)
            direction = Vector3.up * speed;
        OnTurning(WallType.None);

        //Debug.Log("clicking " + direction);

        isGrounded = false;
    }

    private void OnTurning(WallType wallType)
    {
        horizontal = transform.localScale.x;
        if (isTurning == true)
        {
            //horizontal *= -1;
            switch (wallType)
            {
                case (WallType.Right):
                    horizontal = -Mathf.Abs(horizontal);    //Make it negative
                    break;
                case (WallType.Left):
                    horizontal = Mathf.Abs(horizontal);     //Make it positive
                    break;
                default:
                    break;
            }
        }
        if (horizontal > 0.0000001)
        {
            transform.localScale = new Vector3(Size, Size, Size);

            direction.x = +moving;
            isTurning = false;
        }
        else if (horizontal < -0.00001)
        {
            transform.localScale = new Vector3(-Size, Size, Size);
            direction.x = -moving;
            isTurning = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Wall wall;
        bool doesTouchWall = collision.gameObject.TryGetComponent(out wall);

        if (!doesTouchWall)
            return;

        //if (collision.gameObject.tag == "wallLeft" || collision.gameObject.tag == "wallRight")
        if (wall.WallType == WallType.Left || wall.WallType == WallType.Right)
        {   
            isTurning = true;
            //Debug.Log(isTurning);

            mapRotation.Rotate();

            OnTurning(wall.WallType);
        }

        //if (collision.gameObject.tag == "wallBottom")
        else if (wall.WallType == WallType.Bottom)
        {
            isGrounded = true;

            if (mapRotation.IsRotating)
                Jump();
        }   
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
