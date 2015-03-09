using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour 
{
    Rect _retryButon, _exitButton, _leaderboard;
    public GUIText _scoreText;
    GUIStyle style = new GUIStyle();
    void Start()
    {
        style.fontSize = 100;
        style.fixedHeight = 150;
        style.fixedWidth = 1000;
        style.fontStyle = FontStyle.Bold;
        _retryButon = new Rect(Screen.width / (float)4.8, Screen.height / (float)1.3, Screen.width / 10, Screen.height / 10);
        _exitButton = new Rect(Screen.width / (float)1.7, Screen.height / (float)1.3, Screen.width / 10, Screen.height / 10);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        if (GUI.Button(_retryButon, "Retry", style))
        {
            Application.LoadLevel("MainGame");
        }
        GUI.contentColor = Color.white;

        if (GUI.Button(_exitButton, "Exit", style))
        {
            Application.Quit();
        }

        if (GUI.Button(_exitButton, "LeaderBoard", style))
        {
        }
    }
}
