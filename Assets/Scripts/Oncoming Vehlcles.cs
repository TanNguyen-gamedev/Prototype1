using UnityEngine;

public class OncomingVehicles : MonoBehaviour
{
    [SerializeField] private float _speed = 10; 
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
