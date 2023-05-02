using UnityEngine;

public class SniperStatic : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Transform _transform;
    private float _shootForce = 1000;
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
        if (_canShoot) 
        { 
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

    private void Shoot()
    {
        GameObject bulletInstance = Instantiate(bullet, _transform.position, _transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(_transform.forward * _shootForce);
        Destroy(bulletInstance, 3f);
        _canShoot = false;
        _shotTime = GameManager.Instance.GetTime();
    }
}
