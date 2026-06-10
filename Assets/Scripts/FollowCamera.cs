using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerInput _playerInput;
    private InputAction _switchCameraAction;
    
    [SerializeField] private Vector3[] _offsets;

    private int _currentIndex =0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _switchCameraAction = _playerInput.actions["SwitchCamera"];
    }

 	private void OnEnable()
  	{
    	_switchCameraAction.performed += OnSwitchCamera;
  	}

  	private void OnDisable()
  	{
		_switchCameraAction.performed -= OnSwitchCamera;
  	}

  	public void OnSwitchCamera(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            _currentIndex++;

			// Safely loop back to 0 if the index reaches or exceeds the array length
			if (_currentIndex >= _offsets.Length)
			{
				_currentIndex = 0;
			}
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.transform.position + _offsets[_currentIndex];
    }
}
