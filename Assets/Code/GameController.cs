using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject gameWinVisuals;
    public Text titleText;
    const int TitleTextFadeDelay = 3;
    const float FadeSpeed = 5.0f;

	// Use this for initialization
	void Start ()
    {	
	}

    // Update is called once per frame
    void Update()
    {
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

    public void OnFinishLineReached()
    {
        gameWinVisuals.SetActive(true);
    }
}
