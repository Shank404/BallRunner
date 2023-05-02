using UnityEngine;

public class PlattformController : MonoBehaviour
{
    public Transform startPosition, endPosition;
    private GameObject _player;
    private float _speed = 2.5f;
    private bool _movingDirection = false;

    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        Move(gameObject, _movingDirection);
        
        if (transform.position == startPosition.position) {
            _movingDirection = false;
        }
        if (transform.position == endPosition.position) {
            _movingDirection = true;
        }
    }
    
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Move(_player, _movingDirection);
        }
    }
    
    void Move(GameObject go,bool direction)
    {
        float stepSize = _speed * Time.deltaTime;

        if (direction) {
            go.transform.position = Vector3.MoveTowards(go.transform.position, startPosition.position, stepSize);
        } else {
            go.transform.position = Vector3.MoveTowards(go.transform.position, endPosition.position, stepSize);
        }
    }
}