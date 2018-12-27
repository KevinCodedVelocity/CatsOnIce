using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public enum GameState
    {
        WaitingToStart,
        Playing,
        Dead,
        Won
    }
    
    const int TitleTextFadeDelay = 3;
    const float FadeSpeed = 5.0f;

    public GameEndVisualsController gameEndVisuals;
    public GameObject titleVisuals;
    public Button startButton;
    public Text titleText;
    public CatController cat;
    public ChickenContoller chicken;
    public CameraController cameraController;
    public AudioSource cameraAudioSource;
    public Text timerText;

    int currentLevelIndex = 0;
    GameObject[] levels;
    GameObject currentLevel;
    GameState gameState = GameState.WaitingToStart;
    float levelStartTime;
    float levelFinishTime;



    // Use this for initialization
    void Start ()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        
        levels = Resources.LoadAll<GameObject>("Levels/");

        LoadLevel();
    }

    private void LoadLevel()
    {
        int targetLevel = currentLevelIndex;

        targetLevel %= levels.Length;

        if(currentLevel != null)
        {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(levels[targetLevel]);
    }

    // Update is called once per frame
    void Update()
    {

        switch(gameState)
        {
            case GameState.WaitingToStart:
                UpdateWaitingToStartState();
                break;
            case GameState.Playing:
                UpdatePlayingState();
                break;
            case GameState.Dead:
                UpdateDeadState();
                break;
            case GameState.Won:
                UpdateWonState();
                break;
        }
                    }

    #region State machine methods

    private void UpdateWonState()
    {
        gameEndVisuals.SetVisibility(true);
        gameEndVisuals.SetText("You Won!");
        SetTitleVisualsVisibility(false);
        timerText.gameObject.SetActive(true);
    }

    private void UpdateDeadState()
    {
        gameEndVisuals.SetVisibility(true);
        gameEndVisuals.SetText("Game Over!");
        SetTitleVisualsVisibility(false);
        timerText.gameObject.SetActive(false);
    }

    private void UpdatePlayingState()
    {
        gameEndVisuals.SetVisibility(false);
        SetTitleVisualsVisibility(false);
        timerText.gameObject.SetActive(true);
        float timeOnLevel = Time.time - levelStartTime;
        timerText.text = timeOnLevel.ToString("00.00");
    }

    private void UpdateWaitingToStartState()
    {
        cat.enabled = false;
        gameEndVisuals.SetVisibility(false);
        SetTitleVisualsVisibility(true);
        timerText.gameObject.SetActive(false);

        titleText.text = "Cats On Ice!";

        if (Time.time > TitleTextFadeDelay)
        {
            if (titleText.color != Color.clear)
            {
                titleText.color = Color.Lerp(
                    titleText.color,
                    Color.clear,
                    FadeSpeed * Time.deltaTime);
            }
        }
    }
    
    #endregion State machine methods

    public void OnFinishLineReached()
    {
        cameraAudioSource.Play();

        gameState = GameState.Won;
        cat.enabled = false;
        chicken.gameObject.SetActive(true);

    }

    public void OnStartButtonClicked()
    {
        cat.enabled = true;
        gameState = GameState.Playing;
        levelStartTime = Time.time;
    }

    public void RestartGame()
    {
        cat.enabled = false;
        cat.Reset();
        chicken.Reset();
        cameraController.Reset();

        if(gameState == GameState.Won)
        {
            currentLevelIndex++;
            LoadLevel();
        }

        gameState = GameState.WaitingToStart;
    }

    private void SetTitleVisualsVisibility(bool isVisible)
    {
        titleVisuals.SetActive(isVisible);
    }

    public void OnDeath()
    {
        gameState = GameState.Dead;
        cat.enabled = false;
    }
}
