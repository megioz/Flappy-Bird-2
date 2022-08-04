using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wintutorial : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] public float currentHealth { get; private set; }
    private bool dead;
    public WinLose winlooseScript;

    [Header("Win")]
    [SerializeField] private float winStar;
    [SerializeField] public float currentWinstar { get; private set; }

    public GameObject winTutorial;
    public GameObject avoidTutorial;

    private void Awake()
    {
        currentWinstar = winStar;
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth == 0)
        {
            Time.timeScale = 0;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            winlooseScript.LooseLevel();
            Destroy(winTutorial);
            Destroy(avoidTutorial);

        }
    }


    private void Start()
    {
        Time.timeScale = 1;
    }
    

   
   
    public void WinCondition(float condition)
    {
        currentWinstar = Mathf.Clamp(currentWinstar - condition, 0, winStar);
        if (currentWinstar == 0)
        {
            winlooseScript.Winlevel();
            gameObject.SetActive(false);
            Destroy(winTutorial);
            Destroy(avoidTutorial);
        }


    }
}
