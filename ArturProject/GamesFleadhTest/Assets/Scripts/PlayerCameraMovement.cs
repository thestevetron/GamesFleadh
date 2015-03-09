using UnityEngine;
using System.Collections;

public class PlayerCameraMovement : MonoBehaviour 
{
    public GameObject _Camera, _directionSetter, _controller, hamster;
    public static int _playerScore = 0;
    public GUIText _scoreText, HScoreText;
    public GUIText _collectsText, _swipeText;
    public static int _playerFacing;
    int centrePos, _numcols = 0;
    public float turnTime;
    DestroyGround dest;
    bool _turnPressed, _turnArea;

    public float minSwipeDistX;

    private Vector2 startPos;

    

	void Start ()
    {
        _swipeText.enabled = false;
        _playerFacing = 1;
        centrePos = 1;
        InvokeRepeating("UpdateScore", 0f, 1.0f);
        _turnPressed = false;
        _turnArea = false;
        
	}
	
	void Update () 
    {
       
        Debug.Log(_turnArea.ToString());
        Movement();
        //hamster.transform.position = this.gameObject.transform.position;
        this.gameObject.GetComponent<ScoreSystem>().GetHighScore();
        //_playerScore = (int)transform.position.z - (int)transform.position.x;
        //_scoreText.text = "FPS : " + 1.0f / Time.deltaTime;
        _scoreText.text = "Score : " + _playerScore;
        HScoreText.text = "High Score : " + PlayerPrefs.GetInt("HS1");
        _collectsText.text = "Berries : " + _numcols;
        _directionSetter.transform.position = transform.position;
        CameraSettings();
        _controller = GameObject.FindGameObjectWithTag("Controller");
        this.gameObject.GetComponent<ScoreSystem>().GetHighScore();
       // Debug.Log("Vel " + transform.rigidbody.velocity);
	}

    IEnumerator RotateCamera()
    {
        if (_playerFacing == 0)
        {
            while (_Camera.transform.rotation != Quaternion.Euler(0, -90, 0))
            {
                _Camera.transform.rotation = Quaternion.Slerp(_Camera.transform.rotation, Quaternion.Euler(0, -90, 0), .25f);
                yield return new WaitForSeconds(0.02f);
            }
        }
        else if (_playerFacing == 1)
        {
            while (_Camera.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                _Camera.transform.rotation = Quaternion.Slerp(_Camera.transform.rotation, Quaternion.Euler(0, 00, 0), .25f);
                yield return new WaitForSeconds(0.02f);
            }
        }
        CameraSettings();
    }
    void CameraSettings()
    {

        if (_playerFacing == 0)
        {
            //_Camera.transform.localRotation = Quaternion.Euler(new Vector3(0, -90, 0));
            //_Camera.transform.rotation = Quaternion.Slerp(_Camera.transform.rotation, Quaternion.Euler(0, -90, 0), 1000);
            _Camera.transform.position = new Vector3(transform.position.x + 8, 4, transform.position.z);
        }
        else if (_playerFacing == 1)
        {
            //_Camera.transform.rotation = Quaternion.Slerp(_Camera.transform.rotation, Quaternion.Euler(0, 0, 0), 1000);
            //_Camera.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
            _Camera.transform.position = new Vector3(transform.position.x, 4, transform.position.z - 8);
        }
    }
    void UpdateScore()
    {
        if(_playerScore < 50)
            _playerScore += 1;

        else if(_playerScore > 50 && _playerScore < 100)
            _playerScore += 2;

        else if (_playerScore > 100 )
            _playerScore += 5;
    }
    void Movement()
    {
        transform.rigidbody.AddForce(_directionSetter.transform.forward * 8, ForceMode.Acceleration);

        if (_turnArea)
        {
            _swipeText.enabled = true;

            if (Input.touchCount > 0){
			
			    Touch touch = Input.touches[0];			
			
			    switch (touch.phase) 
			    {
			        case TouchPhase.Began:
				        startPos = touch.position;
				        break;
			        case TouchPhase.Ended:
					        float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
					        if (swipeDistHorizontal > minSwipeDistX) 
					        {
						        float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
                                if (_playerFacing == 1)
                                {
                                    if (swipeValue < 0)//right swipe
                                    {
                                        _turnPressed = true;
                                    }
                                }

                                if (_playerFacing == 0)
                                {
                                    if (swipeValue > 0)//left swipe
                                    {
                                        _turnPressed = true;
                                    }
                                }
						
					        }
				    break;
			    }
		}
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _turnPressed = true;
            }
        }

        ///Jump
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    transform.position += new Vector3(0, 2, 0);
        //}
        if (_playerFacing == 1)
        {
            if (centrePos == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position = new Vector3(transform.position.x-2, transform.position.y, transform.position.z);
                    centrePos = 1;
                }
            }
            else if (centrePos == 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                    centrePos = 1;
                }
            }
            else if (centrePos == 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.position = new Vector3(transform.position.x - 2, transform.position.y, transform.position.z);
                    centrePos = 0;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.position = new Vector3(transform.position.x + 2, transform.position.y, transform.position.z);
                    centrePos = 2;
                }
            }
        }

        else if (_playerFacing == 0)
        {
            if (centrePos == 2)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {

                    //Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 2), 50);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                    centrePos = 1;
                }
            }
            else if (centrePos == 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //Vector3.Lerp(transform.position, new Vector3(transform.position.x, .755f, transform.position.z + 2), 50);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                    centrePos = 1;
                }
            }
            else if (centrePos == 1)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    //Vector3.Lerp(transform.position, new Vector3(transform.position.x, .755f, transform.position.z - 2), 50);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 2);
                    centrePos = 0;
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    //Vector3.Lerp(transform.position, new Vector3(transform.position.x, .755f, transform.position.z + 2), 50);
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
                    centrePos = 2;
                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "GetReady")
        {
            _turnArea = true;
        }
        if (_turnArea && _turnPressed)
        {
            #region Turn
            if (col.gameObject.tag == "GCC")
            {
                
                if (_playerFacing == 1)
                {
                    _playerFacing = 0;
                    ///Camera Rotation
                    CameraSettings();
                    StartCoroutine("RotateCamera");
                    Quaternion target = Quaternion.Euler(0, -90, 0);
                    transform.localRotation = target;
                    centrePos = 1;
                    transform.rigidbody.freezeRotation = true;
                    rigidbody.velocity = new Vector3(-rigidbody.velocity.z, 0, 0);
                    _directionSetter.transform.localRotation = target;
                    _controller.GetComponent<GroundGeneration>().CreateGroundStraight(Random.Range(10, 50));

                    
                    Debug.Log("CORNER" + _playerFacing);

                    _controller.GetComponent<CollectManager>().ChangeFacig(0);
                    _controller.GetComponent<ObstacleManager>().ChangeFacig(0);
                    _controller.GetComponent<ObjectsManager>().ChangeFacig(0);
                }
                else if (_playerFacing == 0)
                {

                    _playerFacing = 1;
                    ///Camera Rotation
                    CameraSettings();
                    StartCoroutine("RotateCamera");
                    Quaternion target = Quaternion.Euler(0, 0, 0);
                    transform.rigidbody.freezeRotation = true;
                    transform.localRotation = target;
                    centrePos = 1;
                    rigidbody.velocity = new Vector3(0, 0, -rigidbody.velocity.x);
                    _directionSetter.transform.localRotation = target;
                    _controller.GetComponent<GroundGeneration>().CreateGroundStraight(Random.Range(10, 50));
                    Debug.Log("CORNER" + _playerFacing);

                    _controller.GetComponent<CollectManager>().ChangeFacig(1);
                    _controller.GetComponent<ObstacleManager>().ChangeFacig(1);
                    _controller.GetComponent<ObjectsManager>().ChangeFacig(1);
                }
            }
            #endregion
        }
        if (col.gameObject.tag == "Curved")
        {
            print("HSDFHSDFJSDFJKSDFKSD");
        }

        if(col.gameObject.tag == "Collectible"){
            _playerScore += 10;
            _numcols++;
            _controller.GetComponent<CollectManager>().removeCollect(col.gameObject);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "GCC")
        {
            _turnArea = false;
            _turnPressed = false;
            _swipeText.enabled = false;
            Destroy(col.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            this.rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }

    }

    void OnCollisionExit()
    {
        this.rigidbody.constraints = RigidbodyConstraints.None;
    }
}
