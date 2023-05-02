using UnityEngine;

public class StartTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[3];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "StartTile";
    void Start()
    {
        _nextTileArray[0] = "ForwardTile";
        _nextTileArray[1] = "LeftTopCornerTile";
        _nextTileArray[2] = "RightTopCornerTile";
        int rand = Random.Range(0, 3);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }

}
