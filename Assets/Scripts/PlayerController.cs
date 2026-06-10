using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Speed of the car")]
    [SerializeField] private float _speed =20;
    [Tooltip("TurnRate")]
    [SerializeField] private float _turnSpeed;

    // Player Input component which holds the input binding
    [SerializeField] private PlayerInput _playerInput;

    // Vector 2 store amount of horizontal and vertical of the player input
    private Vector2 _moveInput;

    private Rigidbody _rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get all the needed component
        _rb = GetComponent<Rigidbody>();
        _playerInput = GetComponent<PlayerInput>();

        // Avoid the Rigidbody to behave/flip over when move
        _rb.freezeRotation = true;
    }

	// Public method for the Player Input calls
    public void OnMove(InputValue inputValue)
    {
        // Store the changed value when move input hit
        _moveInput = inputValue.Get<Vector2>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        // Move player forward or backward
        MovePlayer();
        // Rotate player left or right
        RotatePlayer(Time.fixedDeltaTime);        
    }

    private void MovePlayer()
    {
        // Calculate move diretion base on move input
        Vector3 moveDirection = (transform.forward * _moveInput.y).normalized;

        // Calculate target velocity 
        Vector3 velocity = moveDirection * _speed;
		// Preserve the existing gravity/Y velocity
        velocity.y = _rb.linearVelocity.y;

        // Move the Rigidbody
        _rb.linearVelocity = velocity;
    }

    private void RotatePlayer(float fixedDeltaTime)
    {
        // Calculate the ammount of turn angle 
		float turnAmount = _moveInput.x * _turnSpeed * Time.fixedDeltaTime;
        // Rotate the Rigidbody
		_rb.MoveRotation(_rb.rotation * Quaternion.Euler(0,turnAmount,0));
    }
}
