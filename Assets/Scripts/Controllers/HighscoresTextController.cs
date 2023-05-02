using TMPro;
using UnityEngine;

public class HighscoresTextController : MonoBehaviour
{
    private TextMeshProUGUI _highscore1;
    private TextMeshProUGUI _highscore2;
    private TextMeshProUGUI _highscore3;

    private float[] _highscores;

    void Start()
    {
        LoadHighscores();
        SetHighscoreTextReferences();
        SetHighscoreTextValues();
    }

    private void LoadHighscores()
    {
        _highscores = GameManager.Instance.GetHighscores();
    }

    private void SetHighscoreTextValues()
    {
        _highscore1.SetText(_highscores[0].ToString());
        _highscore2.SetText(_highscores[1].ToString());
        _highscore3.SetText(_highscores[2].ToString());
    }

    private void SetHighscoreTextReferences()
    {
        _highscore1 = GameObject.Find("Highscore1").GetComponent<TextMeshProUGUI>();
        _highscore2 = GameObject.Find("Highscore2").GetComponent<TextMeshProUGUI>();
        _highscore3 = GameObject.Find("Highscore3").GetComponent<TextMeshProUGUI>();
    }
}
