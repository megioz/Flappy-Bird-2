using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{

    public WinLose winlooseScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        Destroy(this.gameObject);
        winlooseScript.Winlevel();
    }

}
