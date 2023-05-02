using UnityEngine;

public class BombPackage : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private BallController _ballController;
    private float _rotationSpeed = 100f;
    private Transform _transform;


    void Awake()
    {
        _ballController = player.GetComponent<BallController>();
        _transform = transform;
    }
    private void Update()
    {
        RotateBombPackage();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.SetBombs(GameManager.Instance.GetBombs()+3);
            MusicController.MusicInstance.PlayClip("PowerUp",transform.position);
            Destroy(gameObject);
        }
    }

    private void RotateBombPackage() => _transform.Rotate(0,_rotationSpeed*Time.deltaTime, 0, Space.World);

}
