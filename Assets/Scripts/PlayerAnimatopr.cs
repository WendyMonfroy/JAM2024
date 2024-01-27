using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatopr : MonoBehaviour
{
    public Animator animator;
    PlayerControl _playerControl;
    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        _playerControl = GetComponent<PlayerControl>();
    }

    private void Update()
    {
        Vector2 i = _playerControl.getInputs();
        animator.SetFloat("Forward", i.y);
        animator.SetFloat("Right", i.x);
    }
}
