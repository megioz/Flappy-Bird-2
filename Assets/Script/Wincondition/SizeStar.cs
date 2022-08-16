using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeStar : MonoBehaviour
{
    public PlayerMovement playerMovement;
    [SerializeField] private float size;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            playerMovement.Size = size;

            collision.GetComponent<Goal>().WinCondition(1);
            gameObject.SetActive(false);
        }

    }
}
