using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour 
{
    public int _highScore;
    public int _currentScore;
    public GameObject _text1, _text2, _text3;
    int s1, s2, s3;

	void Start () 
    {
        if (s1 == null)
            s1 = 0;

        if (s2 == null)
            s2 = 0;

        if (s3 == null)
            s3 = 0;
       
	}
	
	void Update ()
    {
        if (Application.loadedLevelName == "Menu")
        {
            _text1.GetComponent<TextMesh>().text = "1. " + PlayerPrefs.GetInt("HS1");
            _text2.GetComponent<TextMesh>().text = "2. " + PlayerPrefs.GetInt("HS2");
            _text3.GetComponent<TextMesh>().text = "3. " + PlayerPrefs.GetInt("HS3");
        }
        _currentScore = PlayerCameraMovement._playerScore;
	}

    public void GetHighScore()
    {
        if(_currentScore > s1)
        {
            print("SDfsdfs");
            s3 = s2;
            s2 = s1;
            s1 = _currentScore;
            PlayerPrefs.SetInt("HS1", s1);
            PlayerPrefs.SetInt("HS2", s2);
            PlayerPrefs.SetInt("HS3", s3);
        }
        else if(_currentScore > s2 && _currentScore < s1)
        {
            s3 = s2;
            s2 = _currentScore;
            PlayerPrefs.SetInt("HS2", s2);
            PlayerPrefs.SetInt("HS3", s3);
        }
        else if(_currentScore > s3 && _currentScore < s2)
        {
            s3 = _currentScore;
            PlayerPrefs.SetInt("HS3", s3);
        }
        if (_highScore < _currentScore)
        {
            _highScore = _currentScore;
            PlayerPrefs.SetInt("HScore", _highScore);
            PlayerPrefs.Save();
        }
    }
}
