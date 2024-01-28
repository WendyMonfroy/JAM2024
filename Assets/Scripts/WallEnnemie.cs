using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnnemie : MonoBehaviour
{
    public bool isOnScreen;
    public float timeToKill;

    public float visibleTime;
    PlayerControl PlayerControl;

    public float chanceOfBeing = 0.1f;

    /*
    private void OnBecameVisible()
    {
        if(!isOnScreen)
            visibleTime = Time.time;
        isOnScreen = true;
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnBecameInvisible()
    {
        isOnScreen = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    */
    private void Start()
    {
        PlayerControl = FindObjectOfType<PlayerControl>();
        if(Random.value > chanceOfBeing)
        {
            Destroy(gameObject);
        }
        gameObject.name += (int)Random.Range(0, 1000);
    }

    private bool IsVisible(Camera c)
    {
        bool a = GetComponent<SpriteRenderer>().isVisible;
        bool b = !Physics.Raycast(c.transform.position, transform.position - c.transform.position, Vector3.Distance(c.transform.position, transform.position));

        return a && b;
    }

    private void Update()
    {
        if(IsVisible(Camera.main))
        {
            if(!isOnScreen)
            {
                visibleTime = Time.time;
                GetComponent<SpriteRenderer>().color = Color.red;
                isOnScreen = true;
            }
        }
        else
        {
            isOnScreen = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (isOnScreen)
        {
            if((Time.time - visibleTime) > timeToKill)
            {
                PlayerControl.GetComponent<HeathManager>().Die();
                print(gameObject.name);
                timeToKill = float.PositiveInfinity;
                visibleTime = Time.time;
            }
        }
    }
}
