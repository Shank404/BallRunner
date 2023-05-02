using UnityEngine;

public class LeftTopCornerTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[2];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "LeftTopCornerTile";
    void Start()
    {
        _nextTileArray[0] = "RightTile";
        _nextTileArray[1] = "RightCornerTile";
        int rand = Random.Range(0, 2);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
