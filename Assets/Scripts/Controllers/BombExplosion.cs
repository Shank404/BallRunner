using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    private float _detonationRadius = 5f;
    private float _detonationPower = 10f;
    private float _spawnedTime;
    private float _timeToDetonate = 3f;
    private float _elapsedTime;

    private Transform _transform;
    [SerializeField] private GameObject detonateParticles;


    void Start()
    {
        _spawnedTime = GameManager.Instance.GetTime();
        _transform = transform;
    }
    
    void Update()
    {
        _elapsedTime = GameManager.Instance.GetTime() - _spawnedTime;
        if (_elapsedTime > _timeToDetonate)
        {
            Detonate();
        }
    }

    private void Detonate()
    {
        Collider[] affectedObjects = GetAffectedObjects();

        for(int i = 0; i < affectedObjects.Length-1; i++)
        {
            Rigidbody rb = affectedObjects[i].GetComponent<Rigidbody>();
            if (rb != null)
            {
                if (rb.gameObject.CompareTag("Enemy"))
                {
                    Destroy(rb.gameObject);
                }

                MusicController.MusicInstance.PlayClip("BombExplosion",transform.position);
                rb.AddExplosionForce(_detonationPower, _transform.position, _detonationRadius, 2.5f, ForceMode.Impulse);
            }
        }
        GameObject particles = Instantiate(detonateParticles, new Vector3(_transform.position.x,_transform.position.y+3,_transform.position.z), _transform.rotation);
        Destroy(gameObject);
    }

    private Collider[] GetAffectedObjects()
    {
        //Speichert alle Objekte im Radius und gibt sie als Collider-Array zurück
        return Physics.OverlapSphere(_transform.position, _detonationRadius);
    }
}
