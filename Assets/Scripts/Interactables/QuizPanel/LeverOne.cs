using UnityEngine;

public class LeverOne : MonoBehaviour
{
    [SerializeField] private QuizPanel quizPanel;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.One();
        }
    }
}
