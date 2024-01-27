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
        animator.SetFloat("Speed", _playerControl.inputs.magnitude);
        animator.SetFloat("Forward", _playerControl.inputs.x);
        animator.SetFloat("Right", _playerControl.inputs.y);
    }
}
