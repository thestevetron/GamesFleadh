using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundGeneration : MonoBehaviour
{
    public GameObject _player, _ground, _curvedGroundLeft, _curvedGroundRight, _curved;
    GameObject _spawnPoint;
    public List<GameObject> _groundPieces;
    bool _readyToSpawn = true;
    float _timeSinceLastSpawn = 0.0f;
    public int _nextGroundPosition = 1;
    int _numberSpawned;

    void Start()
    {
        _nextGroundPosition = 1;
        CreateGroundStraight(Random.Range(10, 20));
        _numberSpawned = 0;
       // _ground.transform.rotation = Quaternion.Euler(new Vector3(0,90,0));

    }

    void Update()
    {
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        if(Input.GetKeyDown(KeyCode.Q))
        {
            CreateGroundStraight(Random.Range(10, 50));
        }
    }

    public void CreateGroundStraight(int amount)
    {
        print("Ground : " + amount);
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        _readyToSpawn = true;
        if (_nextGroundPosition == 1)
        {
            if (_readyToSpawn)
            {
                for (int i = 0; i < amount; i++)
                {
                    _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
                    Instantiate(_ground, _spawnPoint.transform.position +  (_spawnPoint.transform.forward * (8 * i)), Quaternion.Euler(new Vector3(90,0,0)));
                    _numberSpawned++;
                }
                Instantiate(_curvedGroundLeft, _spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned*8)), Quaternion.identity);

                GetComponent<CollectManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                GetComponent<ObstacleManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                GetComponent<ObjectsManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                

                _nextGroundPosition = 0;
                _readyToSpawn = false;
                _numberSpawned = 0;
            }
        }
        else if(_nextGroundPosition == 0)
        {
            print("RTS : "  +_readyToSpawn.ToString());
            if (_readyToSpawn)
            {
                for (int i = 0; i < amount; i++)
                {
                    _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
                    Instantiate(_ground, _spawnPoint.transform.position + (_spawnPoint.transform.forward * (8 * i)), Quaternion.Euler(new Vector3(90, 0, 0)));
                    _numberSpawned++;
                }
                Instantiate(_curvedGroundRight, _spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned*8)), Quaternion.Euler(new Vector3(0,-90,0)));

                GetComponent<CollectManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                GetComponent<ObstacleManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                GetComponent<ObjectsManager>().SetEndPoint(_spawnPoint.transform.position + (_spawnPoint.transform.forward * (_numberSpawned * 8)));
                

                _nextGroundPosition = 1;
                _readyToSpawn = false;
                _numberSpawned = 0;                
            }
        }

        //#region SpawnLeft
        //if (_nextGroundPosition == 1)
        //{
            
        //        Instantiate(_ground, spawnPoint, Quaternion.identity);
        //        _nextGroundPosition = 0;
            
        //        print("NTS : " + DestroyGround.numbertimesspawned);
        //        _groundPieces.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        //        Instantiate(_curvedGroundLeft, spawnPoint, Quaternion.identity);

        //        DestroyGround.numbertimesspawned = 0;
            
        //}
        //#endregion
        //#region SpawnRight
        //else if (_nextGroundPosition == 0)
        //{
        //        Instantiate(_ground, spawnPoint, Quaternion.identity);
        //        _nextGroundPosition = 1;
            
        //        _groundPieces.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        //        Instantiate(_curvedGroundLeft, spawnPoint, Quaternion.identity);
                
        //        DestroyGround.numbertimesspawned = 0;
            
        //}
        //#endregion
    }
}

    

