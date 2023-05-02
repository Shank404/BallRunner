using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelController : MonoBehaviour
{
    private const string Level1 = "Level 1";
    private const string Level2 = "Level 2";
    private const string Level3 = "Level 3";
    private const string ProcedualLevel = "Prozedualer Levelgenerator";
    private const string TestLevel = "TestLevel";
    private const string MainMenu = "MainMenu";
    private const string HighscoreLadder = "HighscoreLadder";
    
    public void LoadLevel1()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(Level1);
    }
    public void LoadLevel2()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(Level2);
    }
    public void LoadLevel3()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(Level3);
    }
    public void LoadTestLevel()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(TestLevel);
    }
    public void LoadProcedualLevel()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(ProcedualLevel);
    }
    
    public void LoadMainMenu()
    {
        GameManager.Instance.ResetValues();
        SceneManager.LoadScene(MainMenu);
    }
    
    public void LoadHighscoreLadder()
    {
        SceneManager.LoadScene(HighscoreLadder);
    }

}
