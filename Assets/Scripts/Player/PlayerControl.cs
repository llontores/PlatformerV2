using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Player _player;

    public event UnityAction<float> HorizontalInputChanged;
    public event UnityAction JumpButtonPressed;
    public event UnityAction AttackButtonPressed;

    private Rigidbody2D _rigidbody2D;

    private float _horizontalInput;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(_horizontalInput) > 0.01)
        {
            HorizontalInputChanged?.Invoke(_horizontalInput);
        }

        _rigidbody2D.velocity = new Vector2(_speed * _horizontalInput, _rigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && _player.IsGrounded == true)
        {
            JumpButtonPressed?.Invoke();
            _rigidbody2D.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            AttackButtonPressed?.Invoke();
        }
    }
}
