using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Transform _transform;
    private const float RotationSpeed = 100f;

    private void Awake()
    {
        _transform = transform;
    }
    
    private void Update()
    {
        RotateCoin();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
            MusicController.MusicInstance.PlayClip("Coin", transform.position);
            GameManager.Instance.AddCoin();
            Destroy(gameObject);
    }

    private void RotateCoin()
    {
        _transform.Rotate(0,RotationSpeed*Time.deltaTime, 0, Space.World);   
    }
}
