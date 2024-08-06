using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    [Header("MoveController")]
    [SerializeField] private Rigidbody _rigidbody;
    //[Space]
    //[SerializeField] 
 // [SerializeField] private Rigidbody _rb;
 // [SerializeField] private float _gravity = -9.8f; // Прискорення вільного падіння, типове значення для Землі
 // public Vector2 _velocity;
 // [SerializeField] private float _jumpVelocity = 5f; // Швидкість стрибка
 // [SerializeField] private float _groundHeight; // Висота землі
 // public bool _isGrounded = false;
 //
 // private InputSystem _inputActions; // Новий клас для обробки вводу
 //
 // void Awake()
 // {
 //     _inputActions = new InputSystem(); // Ініціалізуємо нові ввідні дії
 // }
 //
 // void OnEnable()
 // {
 //     _inputActions.Enable(); // Увімкнення ввідних дій
 // }
 //
 // void OnDisable()
 // {
 //     _inputActions.Disable(); // Вимкнення ввідних дій
 // }
 //
 // void Start()
 // {
 //      
 // }
 //
 // void Update()
 // {
 //     if (_isGrounded)
 //     {
 //         if (_inputActions.Player.Jump.triggered) // Перевірка на натискання клавіші стрибка
 //         {
 //             _isGrounded = false;
 //             _velocity.y = _jumpVelocity;
 //         }
 //     }
 // }
 //
 // private void FixedUpdate()
 // {
 //     Vector2 pos = transform.position;
 //
 //     // Завжди змінюємо позицію об'єкта з урахуванням швидкості
 //     pos.y += _velocity.y * Time.fixedDeltaTime;
 //
 //     // Завжди змінюємо швидкість з урахуванням гравітації
 //     _velocity.y += _gravity * Time.fixedDeltaTime;
 //
 //     if(Physics.Raycast(_rb.transform.position, Vector3.down, _groundHeight))
 //     {
 //         pos.y = _groundHeight;
 //         _isGrounded = true;
 //         _velocity.y = 0f;
 //     }
 //
 //     transform.position = pos;
 // }
 //private void OnCollisionEnter(Collision collision)
 //{
 //    if (collision.gameObject.CompareTag("Ground"))
 //    {
 //        _isGrounded = true;
 //        _velocity.y = 0f;
 //    }
 //    else
 //    {
 //        _isGrounded = false;
 //    }
 //}
}
