using UnityEngine;

public class LeverThree : MonoBehaviour
{
    [SerializeField] private QuizPanel quizPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            quizPanel.Three();
        }
    }
}
