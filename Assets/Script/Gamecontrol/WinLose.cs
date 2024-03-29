using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class WinLose : MonoBehaviour
{
    public Animator transition;
    public bool gameEnded;
    public string nextLevelName;
    public GameObject winPanel;
    public GameObject loosePanel;
    public GameObject gamePlay;
    public GameObject backgroundAnimation;

    
    public void Winlevel()
    {
        if (!gameEnded)
        {

            
            winPanel.SetActive(true);
            backgroundAnimation.SetActive(true);
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            gameEnded = true;
        }
    }


    IEnumerator LoadLevel(int levelIndex)
    { 
        transition.SetTrigger("Start");



        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
public void RestartLevel()
    {
        loosePanel.SetActive(true);
        if (Time.timeScale  != 0)
        {   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

            
        }      
    }

    public void LooseLevel()
    {
        if (!gameEnded)
        {   
            Debug.Log("You Loose");
            
            RestartLevel();
            Time.timeScale = 1f;
            gameEnded = true;
        }
    }
}
