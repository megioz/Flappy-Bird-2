using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class MapRotation : MonoBehaviour
{

    public float Speed = 20f;
    public bool rotate ;

    
    void Update()  
    {   if (rotate == true)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -180f), Speed * Time.deltaTime);
        }     
     }
    }

   

