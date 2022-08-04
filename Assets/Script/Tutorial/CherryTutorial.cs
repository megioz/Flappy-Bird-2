using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryTutorial : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {

            collision.GetComponent<Wintutorial>().WinCondition(1);
            gameObject.SetActive(false);
        }



    }
}
