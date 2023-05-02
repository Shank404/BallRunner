using UnityEngine;

public class LeverFour : MonoBehaviour
{
    [SerializeField] private QuizPanel quizPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.Four();
        }
    }
}
