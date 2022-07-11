using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float winStar;
    [SerializeField] public float currentWinstar { get; private set; }
    private bool dead;
    public WinLose winlooseScript;

    private void Awake()
    {
        currentWinstar = winStar;
    }
    public void WinCondition(float condition)
    {
        currentWinstar = Mathf.Clamp(currentWinstar - condition, 0, winStar);
        if (currentWinstar == 0)
        {
            winlooseScript.Winlevel();
        }
        

    }
}
