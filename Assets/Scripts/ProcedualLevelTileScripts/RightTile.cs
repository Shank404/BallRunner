using UnityEngine;

public class RightTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[3];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "RightTile";
    void Start()
    {
        _nextTileArray[0] = "RightCornerTile";
        _nextTileArray[1] = "RightPlattformTile";
        _nextTileArray[2] = "RightTile";
        int rand = Random.Range(0, 3);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
