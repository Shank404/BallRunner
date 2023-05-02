using UnityEngine;

public class RightTopCornerTile : MonoBehaviour
{
    private string[] _nextTileArray = new string[2];
    [SerializeField] private  ProcedualLevelGenerationController generator;
    private string _tileName = "RightTopCornerTile";
    void Start()
    {
        _nextTileArray[0] = "LeftTile";
        _nextTileArray[1] = "LeftCornerTile";

        int rand = Random.Range(0, 2);
        generator.CreateTile(_nextTileArray[rand],_tileName,transform.position, transform.rotation);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this);
    }
}
