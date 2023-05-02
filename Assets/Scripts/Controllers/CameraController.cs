using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject wayPoints;
    private Transform _transform;
    private Transform _ballTransform;
    private Rigidbody _rbBall;
    private Vector3 _offsetStatic;
    private Vector3 _offsetCameraRelative;
    private Vector3 _offsetStaticInitValues;
    private Quaternion _offsetRotationCameraStatic;
    private Vector3 _scroll;
    private Camera _camera;
    private const float MinFieldOfView = 35f;
    private const float MaxFieldOfView = 45f;
    private int _count = 1;
    private float _cameraRotationSpeed = 200f;
    
    void Start()
    {
        _camera = Camera.main;
        _rbBall = ball.GetComponent<Rigidbody>();
        _transform = transform;
        _ballTransform = ball.transform;
        _offsetCameraRelative = _transform.position - ball.transform.position;
        _offsetStatic = _transform.position - _ballTransform.position;
        _offsetRotationCameraStatic = _transform.rotation;
        if (GameManager.Instance.CurrentLevel > 2)
        {
            if (wayPoints != null)
            {
                _transform.position = wayPoints.transform.GetChild(0).position;
            }
        }
        _transform.LookAt(ball.transform.position);
        _offsetStaticInitValues = _offsetStatic;
    }
    
    void Update()
    {

        if (GameManager.Instance.GetGameStarted())
        {
            if (GameManager.Instance.GetCameraChanged())
            {
                StaticCamera();
                HandleMouseScrollZoom();
            }
            else
            {
                RelativeCamera();
            }
            
            HandleCameraZoom();
            
        }
        else
        {
            // Camera moves along waypoints
            if (_count < wayPoints.transform.childCount && GameManager.Instance.CurrentLevel > 1)
            {
                MoveToWayPoint(wayPoints.transform.GetChild(_count));    
            } 
            else
            {
                GameManager.Instance.SetIsTimeOn(true);
                GameManager.Instance.SetGameStarted(true);
            }
            
        }

    }

    private void HandleCameraZoom()
    {
        if (_rbBall.velocity.magnitude > 5 && _camera.fieldOfView > MinFieldOfView)
        {
            _camera.fieldOfView -= 0.01f;
        }
        else if (_rbBall.velocity.magnitude < 5 && _camera.fieldOfView <= MaxFieldOfView)
        {
            _camera.fieldOfView += 0.01f;
        }
    }


    private void HandleMouseScrollZoom()
    {
        // Mouse Scroll
        if (Mouse.current.scroll.y.ReadValue() > 0)
        {
            _scroll -= _transform.forward;
        }
        else if (Mouse.current.scroll.y.ReadValue() < 0)
        {
            _scroll += _transform.forward;
        }
    }

    private void RelativeCamera()
    {
        _transform.position = ball.transform.position + _offsetCameraRelative;
        _transform.LookAt(_ballTransform.position);

        if (Keyboard.current.dKey.isPressed)
        {
            _offsetCameraRelative = Quaternion.AngleAxis(_cameraRotationSpeed * Time.deltaTime, Vector3.up) * _offsetCameraRelative;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            _offsetCameraRelative = Quaternion.AngleAxis(-_cameraRotationSpeed * Time.deltaTime, Vector3.up) * _offsetCameraRelative;
        }
    }

    private void StaticCamera()
    {
        _transform.rotation = _offsetRotationCameraStatic;
        _transform.position = ball.transform.position + _offsetStatic - _scroll;
        if(Keyboard.current.shiftKey.isPressed)
        {
            if (Keyboard.current.leftArrowKey.isPressed)
            { 
                Quaternion rotateOffset = Quaternion.AngleAxis(_cameraRotationSpeed * Time.deltaTime, Vector3.up);
                _offsetStatic = rotateOffset * _offsetStatic;
            }
            
            if (Keyboard.current.rightArrowKey.isPressed)
            {
                Quaternion rotateOffset = Quaternion.AngleAxis(-_cameraRotationSpeed * Time.deltaTime, Vector3.up);
                _offsetStatic = rotateOffset * _offsetStatic;
            }
            if (Keyboard.current.upArrowKey.isPressed)
            {
                Quaternion rotateOffset = Quaternion.AngleAxis(_cameraRotationSpeed * Time.deltaTime, Vector3.right);
                _offsetStatic = rotateOffset * _offsetStatic;
            }
            
            if (Keyboard.current.downArrowKey.isPressed)
            {
                Quaternion rotateOffset = Quaternion.AngleAxis(-_cameraRotationSpeed * Time.deltaTime, Vector3.right);
                _offsetStatic = rotateOffset * _offsetStatic;
            }
            _transform.LookAt(ball.transform.position);
        }

        if (Keyboard.current.shiftKey.wasReleasedThisFrame)
        {
            _offsetStatic = _offsetStaticInitValues;
        }
    }

    private void MoveToWayPoint(Transform wayPoint)
    {
        _transform.position = Vector3.MoveTowards(_transform.position, wayPoint.transform.position, Time.deltaTime * 20f);
        if (_transform.position == wayPoint.transform.position)
        {
            _count++;
        }
    }


}
