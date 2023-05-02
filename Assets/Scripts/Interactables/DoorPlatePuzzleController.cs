using UnityEngine;

public class DoorPlatePuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject doorOpenPosition;
    [SerializeField] private GameObject doorClosedPosition;
    [SerializeField] private Material openTexture;
    [SerializeField] private Material closedTexture;
    private Vector3 _currentDoor;
    private Vector3 _current;
    private Vector3 _doorOpenDirection;
    private Vector3 _doorClosedDirection;
    private MeshRenderer _mesh;

    private bool _isOpening = false;
    private float _doorOpenSpeed = 1f;

    public void Start()
    {
        _current = transform.position;
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
        transform.position = new Vector3(_current.x, _current.y - 0.1f, _current.z);
        _mesh.material = closedTexture;

        Quaternion rotation = Quaternion.LookRotation(_doorClosedDirection);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, rotation, _doorOpenSpeed * Time.deltaTime);
    }

    private void OpenDoor()
    {
        transform.position = new Vector3(_current.x, _current.y - 0.1f, _current.z);
        _mesh.material = openTexture;

        Quaternion rotation = Quaternion.LookRotation(_doorOpenDirection);
        door.transform.rotation = Quaternion.Lerp(door.transform.rotation, rotation, _doorOpenSpeed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("KeyCube"))
        {
            MusicController.MusicInstance.PlayClip("Switch", transform.position);
            _isOpening = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("KeyCube"))
        {
            MusicController.MusicInstance.PlayClip("Switch", transform.position);
            _isOpening = false;
        }
    }
}