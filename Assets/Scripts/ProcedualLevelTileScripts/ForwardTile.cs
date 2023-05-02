using UnityEngine;
using Random = UnityEngine.Random;

public class ForwardTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[7];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "ForwardTile";
    void Start()
    {
        _nextTileArray[0] = "ForwardTile";
        _nextTileArray[1] = "LeftTopCornerTile";
        _nextTileArray[2] = "RightTopCornerTile";
        _nextTileArray[3] = "PlattformUpTile";
        _nextTileArray[4] = "WallJumpTile";
        _nextTileArray[5] = "PlattformUpTile";
        _nextTileArray[6] = "WallJumpTile";

        int rand = Random.Range(0, 7);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}

