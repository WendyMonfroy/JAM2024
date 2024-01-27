using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HeathManager : MonoBehaviour
{ 
    public float maxHP = 100;
    public float HP = 100;

    public UnityEvent onDie, onTakeDamage;

    public void TakeDamage(float damages)
    {
        HP -= damages;
        onTakeDamage.Invoke();
        if (HP <= 0)
            Die();
    }

    public void Die()
    {
        onDie.Invoke();
    }
    
}
