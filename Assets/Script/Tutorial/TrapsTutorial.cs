using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsTutorial : MonoBehaviour
{   [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
                                                    
        if (collision.tag == "player")
            collision.GetComponent<Wintutorial>().TakeDamage(damage);
    }
}
