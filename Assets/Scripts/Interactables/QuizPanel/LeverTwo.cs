using UnityEngine;

public class LeverTwo : MonoBehaviour
{
    [SerializeField] private QuizPanel quizPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.Two();
        }
    }
}
