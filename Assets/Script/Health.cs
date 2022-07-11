using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] private float startingHealth;
    [SerializeField] public float currentHealth { get; private set; }
    private bool dead;
    public WinLose winlooseScript;


    private void Awake()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        
        if (currentHealth == 0 )
         {   Time.timeScale = 0;
            gameObject.SetActive(false);
            Destroy(this.gameObject);
            winlooseScript.LooseLevel();
        }
       

    }
}
