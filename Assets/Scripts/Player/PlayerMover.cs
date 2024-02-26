using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;

    private Rigidbody2D _rigidbody2D;
    private Coroutine _moveJob;

    private void Start()
    {
        //_input = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.HorizontalInputChanged += MovingCoroutineWork;
        _input.JumpButtonPressed += Jump;
    }

    private void OnDisable()
    {
        _input.HorizontalInputChanged -= MovingCoroutineWork;
        _input.JumpButtonPressed -= Jump;

    }

    private IEnumerator Move(float sign)
    {
        while (true)
        {
            _rigidbody2D.velocity = new Vector2(_speed * sign, _rigidbody2D.velocity.y);

            yield return null;
        }
    }

    private void MovingCoroutineWork(float sign, bool isWorking)
    {
        if (isWorking)
        {
            StartMovingCoroutineWork(sign);
        }
        else
            StopMovingCoroutineWork(sign);
    }

    private void StartMovingCoroutineWork(float sign)
    {
        _moveJob = StartCoroutine(Move(sign));
    }

    private void StopMovingCoroutineWork(float sign)
    {
        StopCoroutine(_moveJob);
    }

    private void Jump()
    {
        if (_player.IsGrounded)
        {
            print("юхууу чача-чача");
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}