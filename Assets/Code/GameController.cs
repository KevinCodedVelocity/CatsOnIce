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

    public GameEndVisualsController gameEndVisuals;
    public GameObject titleVisuals;
    public Button startButton;
    public Text titleText;
    public CatController cat;

    GameState gameState = GameState.WaitingToStart;
    const int TitleTextFadeDelay = 3;
    const float FadeSpeed = 5.0f;


	// Use this for initialization
	void Start ()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);

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
    }

    private void UpdateDeadState()
    {
        gameEndVisuals.SetVisibility(true);
        gameEndVisuals.SetText("Game Over!");
        SetTitleVisualsVisibility(false);
    }

    private void UpdatePlayingState()
    {
        gameEndVisuals.SetVisibility(false);
        SetTitleVisualsVisibility(false);
    }

    private void UpdateWaitingToStartState()
    {
        cat.enabled = false;
        gameEndVisuals.SetVisibility(false);
        SetTitleVisualsVisibility(true);
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
        gameState = GameState.Won;
        cat.enabled = false;
    }

    public void OnStartButtonClicked()
    {
        cat.enabled = true;
        gameState = GameState.Playing;
    }

    public void RestartGame()
    {
        cat.enabled = false;
        cat.Reset();
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
