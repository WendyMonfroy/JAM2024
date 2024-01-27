using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject startScreen;
    public GameObject pauseScreen;

    public bool isGameActive = false;
    public bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            TogglePlayPause();
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        SceneManager.LoadScene("MazeScene");
    }

    private void TogglePlayPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    private void GameOver(bool win)
    {
        isGameActive = false;
        endScreen.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
