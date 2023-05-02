using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    [SerializeField] private Text textAttempts;
    [SerializeField] private Text textHealth;
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textBombs;
    [SerializeField] private Text textTime;
    [SerializeField] private Text textLevel;
    void Start()
    {
        AddFieldsListener();
    }

    private void AddFieldsListener()
    {
        GameManager.Instance.attemptsChanged.AddListener(UpdateTextAttempts);
        
        GameManager.Instance.healthChanged.AddListener(UpdateTextHealth);

        GameManager.Instance.timeChanged.AddListener(UpdateTextTime);

        GameManager.Instance.levelChanged.AddListener(UpdateTextLevel);
        
        GameManager.Instance.coinsChanged.AddListener(UpdateTextCoins);
        
        GameManager.Instance.bombsChanged.AddListener(UpdateTextBombs);
    }

    private void UpdateTextAttempts(int value)
    {
        textAttempts.text = value.ToString();
    }
    private void UpdateTextHealth(int value)
    {
        textHealth.text = value.ToString();
    }
    private void UpdateTextTime(int value)
    {
        textTime.text = value.ToString();
    }

    private void UpdateTextLevel(int value)
    {
        textLevel.text = value.ToString();
    }
    
    private void UpdateTextCoins(int value)
    {
        textCoins.text = value.ToString();
    }
    
    private void UpdateTextBombs(int value)
    {
        textBombs.text = value.ToString();
    }
}
