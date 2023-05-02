using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPoint : MonoBehaviour
{
    public WayPoints waypoint;

    [SerializeField] private GameObject player;
    private Vector3 _startPoint;
    private Vector3 _playerPosition;
    
    void Awake()
    {
        _startPoint = transform.position;
    }

    private void Start()
    {
        SetPlayerPositionOnStartPoint();
        
        if (SceneManager.GetActiveScene().name == "Prozedualer Levelgenerator")
        {
            waypoint.Create(0, new Vector3(_startPoint.x,_startPoint.y+10,_startPoint.z-10));
        }
    }

    private void SetPlayerPositionOnStartPoint()
    {
        player.transform.position = new Vector3(_startPoint.x, _startPoint.y + 1, _startPoint.z);
    }
}
