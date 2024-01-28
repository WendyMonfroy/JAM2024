using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject endScreen;

    private GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        Debug.Log("dans la scene : " + gameManager);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
            Debug.Log("echap pressé");
        }
    }

    public void TogglePause()
    {
        gameManager = GameManager.instance;
        Debug.Log("dans le toggle : " + gameManager);
        if (gameManager !=null)
        {
            Debug.Log("on y est");
            gameManager.TogglePlayPause();
            pauseScreen.SetActive(gameManager.isPaused);
        }
    }
}
