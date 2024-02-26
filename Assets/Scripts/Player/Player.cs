using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : AliveObject
{
    [SerializeField] private PlayerCollisionHandler _collisionHandler;
    [SerializeField] private PlayerControl _control;

    private bool _isGrounded;
    public bool IsGrounded => _isGrounded;
    private void OnEnable()
    {
        HealPotion.Collected += ApplyAidKit;
        _collisionHandler.TouchGround += Land;
        _control.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        HealPotion.Collected -= ApplyAidKit;
        _collisionHandler.TouchGround -= Land;
        _control.JumpButtonPressed -= Jump;
    }

    private void Start()
    {
        _isGrounded = true;
    }

    private void Land()
    {
        _isGrounded = true;
    }

    private void Jump()
    {
        _isGrounded = false;
    }

}
