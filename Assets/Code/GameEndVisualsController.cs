using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndVisualsController : MonoBehaviour {

    public GameController gameController;

    [SerializeField]
    private Text gameEndText;
    [SerializeField]
    private Button tryAgainButton;

    public void Start()
    {
        tryAgainButton.onClick.AddListener(gameController.RestartGame);
    }

    public void SetText(string text)
    {
        gameEndText.text = text;
    }

    public void SetVisibility(bool isVisible)
    {
        gameEndText.gameObject.SetActive(isVisible);
        tryAgainButton.gameObject.SetActive(isVisible);
    }
}
