using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transiton;
    public GameObject gamePlay;
    public void selfDisable()
    {
        transiton.SetActive(false);

        gamePlay.SetActive(true);

        
    }
}