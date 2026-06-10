using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    public InputAction moveAction;

    private Vector2 _moveInput;

    [SerializeField] private GameObject _propeller;

    // Start is called before the first frame update
    void Start()
    {
        moveAction.Enable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _moveInput = moveAction.ReadValue<Vector2>();
        // get the user's vertical input
        verticalInput = _moveInput.y;

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // move the plan up/down

        transform.Translate(Vector3.up * _moveInput.y * speed *Time.deltaTime); 
        
        // tilt the plane up/down based on w/s arrow keys
        transform.Rotate(new Vector3(_moveInput.y,0,0) * rotationSpeed * Time.deltaTime);

        
        // tilt the plan right/left base on a/d keys
        transform.Rotate(new Vector3(0,0,-_moveInput.x) * rotationSpeed * Time.deltaTime);

        _propeller.transform.Rotate(0,0, rotationSpeed * Time.deltaTime * 20f);
    }
}
