using UnityEngine;

public class LeftTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[3];
    [SerializeField] private ProcedualLevelGenerationController generator;
    private string _tileName = "LeftTile";
    void Start()
    {
        _nextTileArray[0] = "LeftCornerTile";
        _nextTileArray[1] = "LeftPlattformTile";
        _nextTileArray[2] = "LeftTile";
        int rand = Random.Range(0, 3);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
