using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //public Canvas PauseMenu;

    [SerializeField]
    TMPro.TextMeshProUGUI highscoreText;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if(highscoreText != null)
        {
            displayHighScore();
        }
    }

    void displayHighScore()
    {
        highscoreText.text = string.Format("High Score: {0}", ScoreSystem.instance.GetHighScore());
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame() 
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ClearHighScore()
    {
        ScoreSystem.instance.ResetHighScore();
    }


    

}
