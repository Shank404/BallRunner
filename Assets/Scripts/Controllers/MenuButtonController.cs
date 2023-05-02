using UnityEngine;


public class MenuButtonController : MonoBehaviour
{
    public void ContinueGame()
    {
        GameManager.Instance.LoadInGameMenu();
        GameManager.Instance.ResumeGame();
    }
    public void NextLevel()
    {
        GameManager.Instance.CloseNextLevelMenu();
    }
    public void Restart()
    {
        GameManager.Instance.RestartCurrentLevel();
    }
    public void LoadMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
    public void LoadHighscore()
    {
        GameManager.Instance.LoadHighscore();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }


}
