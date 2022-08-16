using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MapRotation : MonoBehaviour
{

    public float Speed = 20f;
    public bool rotate ;

    private bool isRotating = false;
    Quaternion targetRotation = Quaternion.Euler(0, 0, -180f);

    public bool IsRotating { get => isRotating; private set => isRotating = value; }

    void Update()  
    {   
        if (rotate == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Speed * Time.deltaTime);

            //Detect if it is rotating, base on the angle between the current rotation and the target rotation
            if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.1f)   //Close enough
                IsRotating = false;
            else IsRotating = true;
        }
        else IsRotating=false;
    }

    public void Rotate()
    {
        rotate = true;
    }

}


   

