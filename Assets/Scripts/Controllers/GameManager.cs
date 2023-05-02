using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public class ValueChangedEvent : UnityEvent<int> { };

    public static GameManager Instance = null;
    
    [SerializeField] private GameObject restartLevelMenu;
    [SerializeField] private GameObject inGameMenu;
    [SerializeField] private GameObject nextLevelMenu;
    [SerializeField] private GameObject hud;
    [SerializeField] private SaveSystem saveSystem;
    [SerializeField] private LoadLevelController loadLevelController;
    
    private Text _attemptsText;
    private Text _timeLevelText;
    private Text _scoreText;

    public ValueChangedEvent timeChanged = new ValueChangedEvent();
    public ValueChangedEvent attemptsChanged = new ValueChangedEvent();
    public ValueChangedEvent healthChanged = new ValueChangedEvent();
    public ValueChangedEvent levelChanged = new ValueChangedEvent();
    public ValueChangedEvent bombsChanged = new ValueChangedEvent();
    public ValueChangedEvent coinsChanged = new ValueChangedEvent();

    private float _time;
    private int _timeInt;
    private int _attempts;
    private int _health = 100;
    private int _coins;
    private int _bombs;
    private bool _isTimeOn = false;
    private bool _inGameMenuActive = false;
    private int _score = 0;
    private static int _nextScene;
    private static bool _gameStarted = false;
    private bool _cameraChanged = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        _nextScene = SceneManager.GetActiveScene().buildIndex;
        
        loadLevelController.LoadMainMenu();
    }

    private void Update()
    {
        if (_isTimeOn)
        {
            Timer();
        }

        if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            _cameraChanged = !_cameraChanged;
        }
        
        if (Keyboard.current.escapeKey.wasReleasedThisFrame && CurrentLevel > 0)
        {
            LoadInGameMenu();
        }

        if (_health < 1)
        {
            LoadRestartLevelMenu();
        }

        if (CurrentLevel > 2)
        {
            hud.SetActive(true);
        }
        LevelChanged();
    }

    //==================== Menus and Levels ====================//
    public int CurrentLevel => SceneManager.GetActiveScene().buildIndex - 2;

    public void LoadInGameMenu()
    {
        if (_inGameMenuActive)
        {
            inGameMenu.SetActive(false);
            ResumeGame();
        }
        else
        {
            inGameMenu.SetActive(true);
            PauseGame();
        }

        _inGameMenuActive = !_inGameMenuActive;
    }

    private void LoadRestartLevelMenu()
    {
        PauseGame();
        restartLevelMenu.SetActive(true);
    }
    public void StartGame()
    {
        loadLevelController.LoadLevel1();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadHighscore()
    {
        loadLevelController.LoadHighscoreLadder();
    }

    public void LoadMainMenu()
    {
        inGameMenu.SetActive(false);
        loadLevelController.LoadMainMenu();
    }
    public void RestartCurrentLevel()
    {
        _time = 0;
        AddAttempt();
        ResumeGame();
        SetHealth(100);
        restartLevelMenu.SetActive(false);
        GameObject.Find("Ball").transform.position = GameObject.Find("StartPoint").transform.position;
        GameObject.Find("Ball").GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void OpenNextLevelMenu()
    {
        nextLevelMenu.SetActive(true);
    }
    public void CloseNextLevelMenu()
    {
        nextLevelMenu.SetActive(false);
        LoadNextLevel();
    }

    private void LoadNextLevel()
    {
        
        _attempts = 0;
        LevelChanged();
        var nextSceneNumber = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneNumber == 6)
        {
            SaveHighscore();
            LoadHighscore();
        }
        else if (nextSceneNumber == 7 || nextSceneNumber == 8)
        {
            LoadMainMenu();
        } 
        else
        {
            SceneManager.LoadScene(nextSceneNumber);
        }
        SetTime(0);
    }
    public static void PreloaderLoad()
    {
        _nextScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }
    public void SetNextLevelCanvasFields()
    {
        _attemptsText = GameObject.Find("AttemptFieldText").GetComponent<Text>();
        _attemptsText.text = _attempts.ToString();
        
        _timeLevelText = GameObject.Find("TimeFieldText").GetComponent<Text>();
        _timeLevelText.text = _timeInt.ToString();
        
        _score += CalculateScore();
        _scoreText = GameObject.Find("ScoreFieldText").GetComponent<Text>();
        _scoreText.text = _score.ToString();
    }
    
    //==================== Timer and Time ====================//
    private void Timer()
    {
        _time += Time.deltaTime;
        _timeInt = Mathf.RoundToInt(_time);
        timeChanged.Invoke(_timeInt);
    }
    
    public void SetTime(float value)
    {
        _time = value;
    }
    public float GetTime()
    {
        return _time;
    }
    
    public void SetIsTimeOn(bool value)
    {
        _isTimeOn = value;
    }

    private void PauseGame()
    {
        _isTimeOn = false;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _isTimeOn = true;
        Time.timeScale = 1;
    }
    
    //==================== Score Highscore ====================//
    public float[] GetHighscores()
    {
        saveSystem.LoadData();
        return saveSystem.GetHighscores();
    }
    private void SaveHighscore()
    {
        saveSystem.SetHighscores(_score);
        saveSystem.SaveData();
    }
    private int CalculateScore()
    {
        return 1000 + (_score + (_coins * 100) - (_attempts*100));
    }
    
    //==================== Health ====================//
    public void SetHealth(int value)
    {
        _health = value;
        healthChanged.Invoke(_health);
    }
    public void AddHealth(int value)
    {
        if (_health < 100)
        {
            _health += value;
            healthChanged.Invoke(_health);
        }

    }

    public void SubtractHealth(int value)
    {
        if (_health > 1)
        {
            _health -= value;
            healthChanged.Invoke(_health);
        }
        else
        {
            _health = 0;
            healthChanged.Invoke(_health);
        }
    }
    //==================== Values ====================//
    private void AddAttempt()
    {
        _attempts++;
        attemptsChanged.Invoke(_attempts);
    }
    private void LevelChanged()
    {
        levelChanged.Invoke(CurrentLevel);
    }

    public void AddCoin()
    {
        _coins++;
        coinsChanged.Invoke(_coins);
    }

    public void SetBombs(int value)
    {
        _bombs = value;
        bombsChanged.Invoke(_bombs);
    }
    public int GetBombs()
    {
        return _bombs;
    }
    public void ResetValues()
    {
        _time = 0;
        _attempts = 0;
        _health = 100;
        _coins = 0;
        _bombs = 0;
        _score = 0;
        SetGameStarted(false);
        ResumeGame();
    }
    public bool GetCameraChanged()
    {
        return _cameraChanged;
    }
    public bool GetGameStarted()
    {
        return _gameStarted;
    }

    public void SetGameStarted(bool value)
    {
        _gameStarted = value;
    }

}