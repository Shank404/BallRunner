using UnityEngine;

public class Sniper : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform tube;
    private Transform _transform;
    private float _shootForce = 1000;
    private float _range = 6f;
    private float _rotationSpeed = 3f;
    private float _shotTime;
    private float _cooldownTime = 1f;
    private float _lastShotTime;
    private bool _canShoot = true;
    

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        CalculateCooldownTimeShoot();
        if (IsPlayerInRange())
        {
            RotateToPlayer();
            Shoot();
        }
    }

    private void CalculateCooldownTimeShoot()
    {
        _lastShotTime = GameManager.Instance.GetTime() - _shotTime;
        if (_lastShotTime > _cooldownTime)
        {
            _canShoot = true;
            _shotTime = 0;
        }
    }

    private bool IsPlayerInRange()
    {
        float distanceToPlayer = Vector3.Distance(target.position, _transform.position);
        return distanceToPlayer < _range;
    }

    private void RotateToPlayer()
    {
        Vector3 direction = target.position - _transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, _rotationSpeed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (_canShoot)
        {
            GameObject bulletInstance = Instantiate(bullet, tube.transform.position, _transform.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * _shootForce);
            MusicController.MusicInstance.PlayClip("Shoot", transform.position);
            Destroy(bulletInstance, 3f);
            _canShoot = false;
            _shotTime = GameManager.Instance.GetTime();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
