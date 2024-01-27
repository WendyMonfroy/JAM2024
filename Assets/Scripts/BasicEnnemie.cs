using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class BasicEnnemie : MonoBehaviour
{
    public MemeTemplate meme;
    public int health;

    public Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void takeDamage(int damages)
    {
        health -= damages;
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        //TODO
    }
}
