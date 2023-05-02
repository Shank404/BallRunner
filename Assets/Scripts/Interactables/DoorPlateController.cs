using System;
using UnityEngine;

public class DoorPlateController : MonoBehaviour
{

    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorOpenPosition;
    [SerializeField] private GameObject doorClosedPosition;
    [SerializeField] private Material openTexture;
    [SerializeField] private Material closedTexture;
    private MeshRenderer _mesh;
    private Vector3 _doorOpenDirection;
    private Vector3 _currentPlatePosition;
    private Vector3 _doorClosedDirection;
    private bool _isOpening = false;
    private float _doorOpenSpeed = 1f;
    
    public void Start()
    {
        _currentPlatePosition = transform.position;
        _doorOpenDirection = doorClosedPosition.transform.position - door.transform.position;
        _doorClosedDirection = door.transform.position - doorOpenPosition.transform.position;
        _mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (_isOpening)
        {
            OpenDoor();
        } else
        {
            CloseDoor();
        }
    }

    private void CloseDoor()
    {
        transform.position = new Vector3(_currentPlatePosition.x, _currentPlatePosition.y - 0.1f, _currentPlatePosition.z);
        _mesh.material = closedTexture;

        Quaternion rotation = Quaternion.LookRotation(_doorClosedDirection);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, rotation, _doorOpenSpeed * Time.deltaTime);
    }

    private void OpenDoor()
    {
        transform.position = new Vector3(_currentPlatePosition.x, _currentPlatePosition.y - 0.1f, _currentPlatePosition.z);
        _mesh.material = openTexture;

        Quaternion rotation = Quaternion.LookRotation(_doorOpenDirection);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, rotation, _doorOpenSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        _isOpening = !_isOpening;
        MusicController.MusicInstance.PlayClip("Switch", transform.position);
    }

}