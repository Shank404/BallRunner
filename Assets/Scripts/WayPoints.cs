using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] private GameObject wayPoint;

    public void Create(int id, Vector3 vec)
    {
        GameObject way = Instantiate(wayPoint, vec, transform.rotation);
        way.name = "WayPoint" + id;
        way.transform.parent = GameObject.Find("WayPoints").transform;
    }
}
