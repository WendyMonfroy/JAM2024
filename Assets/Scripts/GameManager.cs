using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // store a unique instance
    public static GameManager instance;

    public GameObject endScreen;
    public GameObject startScreen;
    public GameObject pauseScreen;

    public bool isGameActive = false;
    public bool isWin = false;
    public bool isPaused = false;

    public SceneChanger changer;

    private void Awake()
    {
        // ensure the singleton
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        isGameActive = true;
        isPaused = false;
        changer.FadeOut();
        //StartCoroutine(LoadGame());
        //SceneManager.LoadScene("MazeScene");
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(0.8f);
        SceneManager.LoadScene("MazeScene");
    }

    public void TogglePlayPause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void GameOver(bool win)
    {
        isGameActive = false;
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
