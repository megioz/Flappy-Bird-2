using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.tag == "player") { 

            collision.GetComponent<Goal>().WinCondition(1);
            gameObject.SetActive(false);
        }
            
        

    }
}
