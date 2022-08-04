using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class WinLose : MonoBehaviour
{
    public bool gameEnded;
    public string nextLevelName;
    public GameObject winPanel;
    public GameObject loosePanel;
    public void Winlevel()
    {
        if (!gameEnded)
        {  
            
            winPanel.SetActive(true);
            gameEnded = true;
        }
    }

    public void LoadNextLevel()
    {
        if (nextLevelName != "")
        {
            winPanel.SetActive(true);
            SceneManager.LoadScene(nextLevelName);
        }
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
