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
    [SerializeField] private PlayerControl _control;
    [SerializeField] private PlayerCollisionHandler _collisionHandler;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _control.HorizontalInputChanged += ControlWalkingAnimation;
        _control.JumpButtonPressed += StartJumpingAnimation;
        _control.AttackButtonPressed += TriggerAttackAnimation;
        _player.HealthChanged += TriggerTakingHitAnimation;
        _collisionHandler.TouchGround += StopJumpingAnimation;
    }

    private void OnDisable()
    {
        _control.HorizontalInputChanged -= ControlWalkingAnimation;
        _control.JumpButtonPressed -= StartJumpingAnimation;
        _control.AttackButtonPressed -= TriggerAttackAnimation;
        _player.HealthChanged -= TriggerTakingHitAnimation;
        _collisionHandler.TouchGround -= StopJumpingAnimation;
    }
    private void ControlWalkingAnimation(float horizontalInput)
    {
        if (Mathf.Abs(horizontalInput) > 0.5)
            _animator.SetBool(WalkingAnimation, true);
        else
            _animator.SetBool(WalkingAnimation, false);
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * Mathf.Sign(horizontalInput), transform.localScale.y, transform.localScale.z);
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

    private void TriggerTakingHitAnimation(float health, float previousValue, float maxhealth)
    {
         _animator.SetTrigger(TakeHitAnimation);
    }
}
