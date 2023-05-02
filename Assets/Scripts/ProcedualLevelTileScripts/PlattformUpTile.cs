using UnityEngine;
using Random = UnityEngine.Random;

public class PlattformUpTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[3];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "PlattformUpTile";
    void Start()
    {
        _nextTileArray[0] = "ForwardTile";
        _nextTileArray[1] = "LeftTopCornerTile";
        _nextTileArray[2] = "RightTopCornerTile";
        int rand = Random.Range(0, 3);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}