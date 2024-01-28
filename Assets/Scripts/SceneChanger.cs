using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public Animator animator;
    public string levelToLoad;


    public void FadeOut()
    {
        animator.SetTrigger("fadeout");
    }


    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadeReset()
    {
        
    }
}
