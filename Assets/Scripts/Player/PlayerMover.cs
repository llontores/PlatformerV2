using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody2D;
    private PlayerInput _input;
    private Coroutine _moveJob;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _input.HorizontalInputChanged += MovingCoroutineWork;
    }

    private void OnDisable()
    {
        _input.HorizontalInputChanged -= MovingCoroutineWork;
    }

    private void Jump(bool isGrounded)
    {
        if (isGrounded)
            _rigidbody2D.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);

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
            StartMovingCoroutineWork(sign);
        else
            StopMovingCoroutineWork(sign);
    }

    private void StartMovingCoroutineWork(float sign)
    {
        if (_moveJob == null)
            _moveJob = StartCoroutine(Move(sign));
    }

    private void StopMovingCoroutineWork(float sign)
    {
        if (_moveJob != null)
            StopCoroutine(_moveJob);
    }
}
