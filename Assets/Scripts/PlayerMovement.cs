using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;
    private InputSystem _playerInput;

    [Header("Move")]
    [SerializeField] private float _speed;
    [Space]
    [Header("Jump")]
    [SerializeField] private float _maxJumpTime = 0.5f;
    [SerializeField] private float _maxJumpHeight = 1f;
    [SerializeField] private float _jumpVelocity;

    [SerializeField] private float _gravity = -9.8f;
    //[SerializeField] private float _groundGravity = -.05f;

    [SerializeField] bool _isJumping = false;
    bool _isJumpPressed = false;
  
    private Vector2 _moveInput;
    private Vector3 _moveVector;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        _playerInput = new InputSystem();

        setupJampVariabls();

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

    private void setupJampVariabls()
    {
        float timeToApex = _maxJumpTime / 2;
        _gravity = (-2 * _maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        _jumpVelocity = (2 * _maxJumpHeight) / timeToApex;
    }
    private void handleJump()
    {
        
        if (_isJumpPressed && _isJumping && characterController.isGrounded)
        {
            _isJumping = false;
        }

    }
    private void OnJump(InputAction.CallbackContext context)
    {
        _isJumpPressed = context.ReadValueAsButton();
        Debug.Log(_isJumpPressed);
        if (!_isJumping && characterController.isGrounded && _isJumpPressed)
        {
            _isJumping = true;
            _moveVector.y = _jumpVelocity;
        }
    }


    void Update()
    {
        
        Move ();
        handleGravity();
        handleJump();
    }
    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            _moveVector.y = _gravity;
        }
        else
        {
            _moveVector.y += _gravity * Time.deltaTime;
        }
    }
    private void Move()
    {
        characterController.Move(_moveVector * Time.deltaTime);
    }

}
