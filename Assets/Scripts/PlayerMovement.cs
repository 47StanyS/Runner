using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // InputSystem _palayerInput;
    // [SerializeField] private float _speed;
    // [SerializeField] private float _jumpSpeed;
    // private Rigidbody _rigidbody;
    //
    // private Vector3 _playerVector;
    //
    // void Awake()
    // {
    //     _rigidbody = GetComponent<Rigidbody>();
    //     _palayerInput = new InputSystem();
    // }
    //
    // private void OnEnable()
    // {
    //     _palayerInput.Move.Jump.performed += OnJump();
    //     move = _palayerInput.Move.Movement;
    //     _palayerInput.Enable();
    // }
    //
    // private void OnDisable()
    // {
    //     _palayerInput.Move.Jump.performed -= OnJump();
    //     move = _palayerInput.Move.Movement;
    //     _palayerInput.Disable();
    // }
    //
    // private void OnJump(InputAction.CallbackContext context)
    // {
    //     _rigidbody.AddForce(_playerVector * _jumpSpeed, ForceMode.Impulse);
    // }
    //
    // void Update()
    // {
    //     
    // }

    private InputSystem _playerInput;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpSpeed;
    private Rigidbody _rigidbody;
    private Vector2 _moveInput;
    private Vector3 _moveVector;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = new InputSystem();
    }

    private void OnEnable()
    {
        _playerInput.Player.Jump.performed += OnJump;
        _playerInput.Player.Movement.performed += OnMove;
        _playerInput.Player.Movement.canceled += OnMove;
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Player.Jump.performed -= OnJump;
        _playerInput.Player.Movement.performed -= OnMove;
        _playerInput.Player.Movement.canceled -= OnMove;
        _playerInput.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _moveInput = context.ReadValue<Vector2>();
        _moveVector = new Vector3(_moveInput.x, 0, _moveInput.y) * _speed;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (IsGrounded())
        {
            _rigidbody.AddForce(Vector3.up * _jumpSpeed, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector3(_moveVector.x, _rigidbody.velocity.y, _moveVector.z);
    }
}
