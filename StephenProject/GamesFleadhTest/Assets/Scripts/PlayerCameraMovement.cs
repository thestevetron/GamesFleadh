using UnityEngine;
using System.Collections;

public class PlayerCameraMovement : MonoBehaviour 
{
    public GameObject _Camera;
    public static int _playerScore = 0;
    public GUIText _scoreText;
	void Start ()
    {
	
	}
	
	void Update () 
    {
        Movement();
        _Camera.transform.position = new Vector3(0, 4, transform.position.z - 8);
        //transform.Rotate(3,0,0);
        //_playerScore = 1 + (int)Time.time;
        _playerScore = (int)transform.position.z;
        _scoreText.text = "Score : " + _playerScore;
	}

    void Movement()
    {
        transform.rigidbody.AddForce(new Vector3(0, 0, 7));
        //transform.position += new Vector3(0, 0, .5f);
        if (transform.position.x > 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(0, .755f, transform.position.z);
            }
        }
        else if (transform.position.x < 0)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(0, .755f, transform.position.z);
            }
        }
        else if (transform.position.x == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = new Vector3(-2, .755f, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = new Vector3(2, .755f, transform.position.z);
            }
        }




    }
}
