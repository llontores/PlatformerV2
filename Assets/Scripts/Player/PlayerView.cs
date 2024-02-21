using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private const string WalkingAnimation = "IsWalking";
    private const string AttackingAnimation = "Attack";
    private const string TakeHitAnimation = "TakeHit";
    private const string JumpingAnimation = "IsJumping";

    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _input.HorizontalInputChanged += ControlWalkingAnimation;
        _input.JumpButtonPressed += StartJumpingAnimation;
        _input.AttackButtonPressed += TriggerAttackAnimation;
        _player.TakingHit += TriggerTakingHitAnimation;
        _collisionHandler.TouchGround += StopJumpingAnimation;
    }

    private void OnDisable()
    {
        _input.HorizontalInputChanged -= ControlWalkingAnimation;
        _input.JumpButtonPressed -= StartJumpingAnimation;
        _input.AttackButtonPressed -= TriggerAttackAnimation;
        _player.TakingHit -= TriggerTakingHitAnimation;
        _collisionHandler.TouchGround -= StopJumpingAnimation;
    }
    private void ControlWalkingAnimation(float sign, bool isWalking)
    {
        if (isWalking)
            _animator.SetBool(WalkingAnimation, true);
        else
            _animator.SetBool(WalkingAnimation, false);
    }

    private void StartJumpingAnimation()
    {
        _animator.SetBool(JumpingAnimation, true);
    }

    private void StopJumpingAnimation()
    {
        _animator.SetBool(JumpingAnimation, false);
    }

    private void TriggerAttackAnimation()
    {
        _animator.SetTrigger(AttackingAnimation);
    }

    private void TriggerTakingHitAnimation()
    {
        _animator.SetTrigger(TakeHitAnimation);
    }
}
