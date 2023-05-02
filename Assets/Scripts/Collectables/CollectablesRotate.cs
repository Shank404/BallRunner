using UnityEngine;

public class CollectablesRotate : MonoBehaviour
{
    private Transform _transform;
    private const float RotationSpeed = 100f;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        Rotate();
    }


    private void Rotate()
    {
        _transform.Rotate(0,RotationSpeed*Time.deltaTime, 0, Space.World);   
    }
}
