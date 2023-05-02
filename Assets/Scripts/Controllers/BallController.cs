using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private InputAction move;
    [SerializeField] private GameObject bomb;
    [SerializeField] private GameObject fireworks;

    private bool _isJumped = false;
    private bool _wallJump = false;


    private float _speed = 400F;
    private float _speedWhileJump = 200f;
    private float _jumpForce = 0;
    private const float JumpForceLimit = 350;

    
    
    private bool _isMudded = false;
    private float _leftMud;
    private float _mudCooldown = 2;
    private bool _mudImmunity = false;

    private Transform _cameraMainTransform;
    private Transform _transform;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        GameManager.Instance.SetHealth(100);
        _transform = transform;
        if (Camera.main != null)
        {
            _cameraMainTransform = Camera.main.transform;
        }

    }

    private void Update()
    {
        if (GameManager.Instance.GetGameStarted())
        {
            Vector2 movement = move.ReadValue<Vector2>();
            
            HandleJump();
            HandleWallJump();
            
            // VELOCITY LIMIT
            if (!_isMudded && GameManager.Instance.GetTime() - _leftMud > _mudCooldown)
            {
                _speed = _rigidbody.velocity.magnitude > 30 ? 0 : 400;
                ResetSpeed();
            }

            // MOVEMENT
            if (GameManager.Instance.GetCameraChanged())
            {
                StaticCameraMovement(movement);
            }
            else
            {
                RelativeCameraMovement();
            }
            

        }
        
        if (Keyboard.current.bKey.wasReleasedThisFrame)
        {
            SpawnBomb();
        }
        
        if (transform.position.y < -10)
        {
            GameManager.Instance.SubtractHealth(100);
        }
        
    }

    private void HandleJump()
    {
        if (Keyboard.current.spaceKey.isPressed && _isJumped == false)
        {
            if (_jumpForce < JumpForceLimit)
            {
                _jumpForce += 2;
            }
        }

        // JUMP-RELEASE
        if (Keyboard.current.spaceKey.wasReleasedThisFrame)
        {
            if (_isJumped == false)
            {
                _rigidbody.AddForce(Vector3.up * _jumpForce);
                _jumpForce = 0;
                _isJumped = true;
            }
        }
    }

    private void HandleWallJump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Keyboard.current.aKey.isPressed && _wallJump)
        {
            _rigidbody.AddForce(400, 200, 0);
            _wallJump = false;
        }
        else if (Keyboard.current.spaceKey.wasPressedThisFrame && Keyboard.current.dKey.isPressed && _wallJump)
        {
            _rigidbody.AddForce(-400, 200, 0);
            _wallJump = false;
        }
    }

    private void StaticCameraMovement(Vector2 movement)
    {
        if (!_isJumped)
        {
            _rigidbody.AddForce(movement.x * _speed * Time.deltaTime, 0, movement.y * _speed * Time.deltaTime); // Movement der Sphere
        }
        else
        {
            _rigidbody.AddForce(movement.x * _speedWhileJump * Time.deltaTime, 0, movement.y * _speed * Time.deltaTime); // Movement der Sphere
        }
    }

    private void RelativeCameraMovement()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            _rigidbody.AddForce(_cameraMainTransform.forward * _speed * Time.deltaTime);
        }

        if (Keyboard.current.sKey.isPressed)
        {
            _rigidbody.AddForce(_cameraMainTransform.forward * -_speed * Time.deltaTime);
        }

        if (Keyboard.current.aKey.isPressed)
        {
            _rigidbody.AddForce(_cameraMainTransform.right * -_speed * Time.deltaTime);
        }

        if (Keyboard.current.dKey.isPressed)
        {
            _rigidbody.AddForce(_cameraMainTransform.right * _speed * Time.deltaTime);
        }
    }

    private void SpawnBomb()
    {
        if (GameManager.Instance.GetBombs() > 0)
        {
            Vector3 spawnPoint = new Vector3(_transform.position.x, _transform.position.y, _transform.position.z+1);
            GameObject bombInstance = Instantiate(bomb, spawnPoint, _transform.rotation);
            GameManager.Instance.SetBombs(GameManager.Instance.GetBombs() - 1);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            MusicController.MusicInstance.PlayClip("Landing", transform.position);
            _isJumped = false;
        }

        if (collision.gameObject.CompareTag("WallJump"))
        {
            _wallJump = true;
        }
        
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            GameManager.Instance.SubtractHealth(20);
            MusicController.MusicInstance.PlayClip("Damage", transform.position);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("WallJump"))
        {
            _wallJump = false;
        }
    }
    


    private void ResetSpeed()
    {
        _speed = 400f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_mudImmunity)
        {
            if (other.gameObject.CompareTag("Mud") && !_isMudded)
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }
        
        if (other.gameObject.CompareTag("EndPoint"))
        {
            GameObject firework = Instantiate(fireworks, _transform.position, _transform.rotation);
            GameManager.Instance.OpenNextLevelMenu();
            GameManager.Instance.SetNextLevelCanvasFields();
        }
        
        switch (other.gameObject.name)
        {
            case "Portal1Sphere":
            {
                Vector3 portal = GameObject.Find("Portal2Sphere").transform.position;
                _rigidbody.transform.position = new Vector3(portal.x, portal.y, portal.z+1);
                MusicController.MusicInstance.PlayClip("Teleport", transform.position);
                break;
            }
            case "Portal2Sphere":
            {
                Vector3 portal = GameObject.Find("Portal1Sphere").transform.position;
                _rigidbody.transform.position = new Vector3(portal.x, portal.y, portal.z-1);
                MusicController.MusicInstance.PlayClip("Teleport", transform.position);
                break;
            }
            case "MudImmunityCube":
            {
                _mudImmunity = true;
                MusicController.MusicInstance.PlayClip("PowerUp", transform.position);
                Destroy(other.gameObject);
                break;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_mudImmunity)
        {
            if (other.gameObject.CompareTag("Mud"))
            {
                _isMudded = true;
                _speed = 20f;
            }
        }

        if (other.gameObject.CompareTag("HealPlane"))
        {
            GameManager.Instance.AddHealth(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_mudImmunity)
        {
            if (other.gameObject.CompareTag("Mud"))
            {
                _isMudded = false;
                _leftMud = GameManager.Instance.GetTime();
            }
        }
    }

    private void OnEnable()
    {
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }
}