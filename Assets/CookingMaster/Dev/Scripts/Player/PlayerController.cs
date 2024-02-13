using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IInputInterface currentInput;

    private Vector3 movement;

    [SerializeField] private CharacterController m_CharacterController;
    [SerializeField] private float m_MoveSpeed = 5;
    [SerializeField] private Animator m_Animator;

    private float smoothTime = 0.05f;
    private float _currentVelocity;
    private void Awake()
    {
        currentInput = new Player1Input();
    }

    private void Update()
    {
        float Horizontal = currentInput.GetAxisHorizontal();
        float Vertical = currentInput.GetAxisVertical();

        movement = new Vector3(Horizontal, 0, Vertical);
        movement.Normalize();
        if (movement.magnitude > 0)
        {
            Rotate();
        }

        m_Animator.SetFloat("Speed_f", movement.magnitude == 0 ? 0 : 0.5f);
    }

    private void Rotate()
    {
        var targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0.0f);
    }

    private void FixedUpdate()
    {
        m_CharacterController.Move(m_MoveSpeed * Time.fixedDeltaTime * movement);
    }
}

public enum PlayerState
{ 
    Walking,
    Chopping,
}

