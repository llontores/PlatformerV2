using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    public event UnityAction<float, bool> HorizontalInputChanged;
    public event UnityAction JumpButtonPressed;
    public event UnityAction AttackButtonPressed;
    public event UnityAction JumpingStateChanged;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            HorizontalInputChanged?.Invoke(1, true);

        if (Input.GetKeyDown(KeyCode.A))
            HorizontalInputChanged?.Invoke(-1, true);

        if (Input.GetKeyUp(KeyCode.D))
            HorizontalInputChanged?.Invoke(1, false);

        if (Input.GetKeyUp(KeyCode.A))
            HorizontalInputChanged?.Invoke(-1, false);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButtonPressed?.Invoke();
            JumpingStateChanged?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
            AttackButtonPressed?.Invoke();

    }

}