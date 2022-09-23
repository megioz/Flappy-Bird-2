using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject transiton;
    public GameObject gamePlay;
    public WinLose winLose;
    public GameObject winPanel;

   
    public void selfDisable()
    {   
        transiton.SetActive(false);




    }
    public void gameplayDisable()
    {
        transiton.SetActive(true);
        gamePlay.SetActive(false);
        winPanel.SetActive(false);
    }

}