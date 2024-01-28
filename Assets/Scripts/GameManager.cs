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
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
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
