using UnityEngine;

public class ProcedualLevelGenerationController : MonoBehaviour
{
    public GameObject startTile;

    [SerializeField] private GameObject endTile;
    [SerializeField] private  GameObject forwardTile;
    [SerializeField] private  GameObject rightTile;
    [SerializeField] private  GameObject leftTile;
    [SerializeField] private  GameObject leftCornerTile;
    [SerializeField] private  GameObject leftTopCornerTile;
    [SerializeField] private  GameObject rightTopCornerTile;
    [SerializeField] private  GameObject rightCornerTile;
    [SerializeField] private  GameObject plattformUpTile;
    [SerializeField] private  GameObject leftPlattformTile;
    [SerializeField] private  GameObject rightPlattformTile;
    [SerializeField] private  GameObject wallJumpTile;
    [SerializeField] private  WayPoints waypoint;
    private static int _levelSize;
    private string _lastTileName;
    private static bool _levelSizeBool = false;
    private static int _levelHeight;
    private Vector3 _lastTilePosition;
    private Vector3 _newTilePosition;
    private Vector3 _cameraWaypointPosition;
    private static int _offsetCameraWaypointZ = -20;
    private static int _offsetCameraWaypointY = 20;


    void Start()
    {
        _levelSize = 0;
        _levelSizeBool = false;
        _levelHeight = 0;
    }

    public void CreateTile(string tile, string lastTile, Vector3 tilePosition, Quaternion tileRotation)
    {
        _lastTilePosition = tilePosition;
        _lastTileName = lastTile;
        _levelSize++;
        if (_levelSize < 20)
        {
            switch (tile)
            {
                case "ForwardTile":
                    _newTilePosition = new Vector3(tilePosition.x, _levelHeight * 20, tilePosition.z+20);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject forwardTileInstance = Instantiate(forwardTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "WallJumpTile":
                    _newTilePosition = new Vector3(tilePosition.x, _levelHeight * 20, tilePosition.z+20);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject wallJumpTileInstance = Instantiate(wallJumpTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "LeftTopCornerTile":
                    _newTilePosition = new Vector3(tilePosition.x, _levelHeight * 20, tilePosition.z+20);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject leftTopCornerTileInstance = Instantiate(leftTopCornerTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "RightTopCornerTile":
                    _newTilePosition = new Vector3(tilePosition.x, _levelHeight * 20, tilePosition.z+20);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject rightTopCornerInstance = Instantiate(rightTopCornerTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "RightCornerTile":
                    _newTilePosition = new Vector3(tilePosition.x+20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject rightCornerInstance = Instantiate(rightCornerTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "LeftCornerTile":
                    _newTilePosition = new Vector3(tilePosition.x-20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject leftCornerInstance = Instantiate(leftCornerTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "LeftTile":
                    _newTilePosition = new Vector3(tilePosition.x-20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject leftTileInstance = Instantiate(leftTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "LeftPlattformTile":
                    _newTilePosition = new Vector3(tilePosition.x-20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject leftPlattformTileInstance = Instantiate(leftPlattformTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "RightTile":
                    _newTilePosition = new Vector3(tilePosition.x+20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject rightTileInstance = Instantiate(rightTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "RightPlattformTile":
                    _newTilePosition = new Vector3(tilePosition.x+20, _levelHeight * 20, tilePosition.z);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject rightPlattformTileInstance = Instantiate(rightPlattformTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    break;
                case "PlattformUpTile":
                    _newTilePosition = new Vector3(tilePosition.x, _levelHeight * 20, tilePosition.z+20);
                    _cameraWaypointPosition = new Vector3(_newTilePosition.x, _newTilePosition.y + _offsetCameraWaypointY, _newTilePosition.z+_offsetCameraWaypointZ);
                    GameObject plattformUpTileInstance = Instantiate(plattformUpTile, _newTilePosition, tileRotation);
                    waypoint.Create(_levelSize, _cameraWaypointPosition);
                    _levelHeight++;
                    break;
            }
        }
        else
        {
            if (_levelSizeBool == false)
            {
                Vector3 newLastTilePosition = _lastTilePosition;
                Vector3 newLastCameraWaypointPosition = new Vector3(_lastTilePosition.x, _lastTilePosition.y + _offsetCameraWaypointY, _lastTilePosition.z+_offsetCameraWaypointZ);
                switch (_lastTileName)
                {
                    case "RightTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x+20, _lastTilePosition.y, _lastTilePosition.z);
                        break;
                    case "LeftTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x-20, _lastTilePosition.y, _lastTilePosition.z);
                        break;
                    case "RightCornerTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x, _lastTilePosition.y, _lastTilePosition.z+20);
                        break;
                    case "LeftCornerTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x, _lastTilePosition.y, _lastTilePosition.z+20);
                        break;
                    case "RightTopCornerTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x-20, _lastTilePosition.y, _lastTilePosition.z);
                        break;
                    case "LeftTopCornerTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x+20, _lastTilePosition.y, _lastTilePosition.z);
                        break;
                    case "ForwardTile": 
                        newLastTilePosition = new Vector3(_lastTilePosition.x, _lastTilePosition.y, _lastTilePosition.z+20);
                        break;
                }
                
                GameObject endTileInstance = Instantiate(endTile, newLastTilePosition, tileRotation);
                waypoint.Create(_levelSize, newLastCameraWaypointPosition);
                _levelSizeBool = true;
                _levelSize = 0;
            }
        }

    }

}
