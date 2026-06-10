using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Vector3 _offset;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _player.transform.position + _offset;
    }
}
