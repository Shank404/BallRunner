using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private float _highscore1 = 0f;
    private float _highscore2 = 0f;
    private float _highscore3 = 0f;
    private float[] _highscores = new float[3];

    public void SaveData()
    {
        PlayerPrefs.SetFloat("highscore1", _highscores[0]);
        PlayerPrefs.SetFloat("highscore2", _highscores[1]);
        PlayerPrefs.SetFloat("highscore3", _highscores[2]);
    }

    public void LoadData()
    {
        _highscore1 = PlayerPrefs.GetFloat("highscore1");
        _highscores[0] = _highscore1;
        _highscore2 = PlayerPrefs.GetFloat("highscore2");
        _highscores[1] = _highscore2;
        _highscore3 = PlayerPrefs.GetFloat("highscore3");
        _highscores[2] = _highscore3;
    }

    public void SetHighscores(float value)
    {
        bool isSet = false;
        for (int i = 0; i < _highscores.Length && !isSet; i++)
        {
            if (_highscores[i] < value)
            {
                for (int j = _highscores.Length - 1; j > i; j--)
                {
                    _highscores[j] = _highscores[j - 1];
                }

                _highscores[i] = value;
                isSet = true;
            }
        }
    }

    public float[] GetHighscores()
    {
        return _highscores;
    }
    

    public void ClearHighscores()
    {
        PlayerPrefs.SetFloat("highscore1", 0f);
        PlayerPrefs.SetFloat("highscore2", 0f);
        PlayerPrefs.SetFloat("highscore3", 0f);
    }
}
