using UnityEngine;

public class PreloaderController : MonoBehaviour
{
    private void Awake()
    {
        if (GameObject.Find("Game Manager") == null)
        {
            GameManager.PreloaderLoad();
        }
    }
}
