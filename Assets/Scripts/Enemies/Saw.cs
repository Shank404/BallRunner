using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private Transform borderLeft;
    [SerializeField] private Transform borderRight;
    private Transform _transform;
    private bool _moveToLeftBorder;
    private bool _moveToRightBorder;
    private float _speed = 10f;
    private float _rotationSpeed = 300f;
    

    private void Awake()
    {
        _transform = transform;
        
    }
    void Start()
    {
        SetStartPosition(borderLeft);
    }

    private void Update()
    {
        HandleBorderDirection();
        MoveToBorder();
    }
    private void SetStartPosition(Transform border)
    {
        _transform.position = border.position;
    }

    private void MoveToBorder()
    {
        //MusicController.musicInstance.PlayClip("Saw",transform.position);
        if (_moveToLeftBorder)
        {
            MoveToLeftBorder();
        }

        if (_moveToRightBorder)
        {
            MoveToRightBorder();
        }
    }

    private void HandleBorderDirection()
    {
        if (_transform.position == borderLeft.position)
        {
            _moveToLeftBorder = false;
            _moveToRightBorder = true;
        }
        else if (_transform.position == borderRight.position)
        {
            _moveToLeftBorder = true;
            _moveToRightBorder = false;
        }
    }

    private void MoveToRightBorder()
    {
        _transform.Rotate(0,0, -_rotationSpeed*Time.deltaTime, Space.World);
        _transform.position = Vector3.MoveTowards(_transform.position, borderRight.position, _speed*Time.deltaTime);
    }

    private void MoveToLeftBorder()
    {
        _transform.Rotate(0,0, _rotationSpeed*Time.deltaTime, Space.World);
        _transform.position = Vector3.MoveTowards(_transform.position, borderLeft.position, _speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SubtractHealth(20);
        }
    }
}
