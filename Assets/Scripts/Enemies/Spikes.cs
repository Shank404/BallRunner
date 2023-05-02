using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject spikes;
    private Rigidbody ballRigidbody;
    private float _speed = 3f;
    private float _force = 7f;
    private bool _spikesUp = true;

    private float _spikesTopLimit = 0.9f;
    private float _spikesBottomLimit = -1f;

    private void Awake()
    {
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_spikesUp)
        {
            MoveSpikesUp();
        }
        else if (!_spikesUp)
        {
            MoveSpikesDown();
        }
    }

    private void MoveSpikesDown()
    {
        spikes.transform.position = new Vector3(spikes.transform.position.x,
            spikes.transform.position.y - (_speed * Time.deltaTime), spikes.transform.position.z);
        if (spikes.transform.position.y < _spikesBottomLimit)
        {
            _spikesUp = true;
            _speed = 5f;
        }
    }

    private void MoveSpikesUp()
    {
        spikes.transform.position = new Vector3(spikes.transform.position.x,
            spikes.transform.position.y + (_speed * Time.deltaTime), spikes.transform.position.z);
        if (spikes.transform.position.y > _spikesTopLimit)
        {
            _spikesUp = false;
            _speed = 0.5f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (_spikesUp)
            {
                ballRigidbody.GetComponent<Rigidbody>().AddForce(Vector3.up * _force, ForceMode.Impulse);
                GameManager.Instance.SubtractHealth(20);
                MusicController.MusicInstance.PlayClip("Damage", transform.position);
            }
        }
    }
}
