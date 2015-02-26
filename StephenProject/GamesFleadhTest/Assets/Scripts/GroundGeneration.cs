using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundGeneration : MonoBehaviour
{
    public GameObject _player, _ground;
    public List<GameObject> _groundPieces;
    bool _readyToSpawn = false;
    float _timeSinceLastSpawn = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        CreateGround();
        MoveGround();

        if (_readyToSpawn == false)
        {
            _timeSinceLastSpawn += Time.deltaTime;
        }
        if (_timeSinceLastSpawn >= Random.Range(.5f, 1.5f))
        {
            _readyToSpawn = true;
            _timeSinceLastSpawn = 0;
        }
    }

    void CreateGround()
    {
        if (_readyToSpawn)
        {
            if (_groundPieces.Count < 11)
            {
                for (int x = 0; x < 5; x++)
                {
                    _groundPieces.Add(_ground);
                    Instantiate(_ground, new Vector3(0, 0, (_player.transform.position.z + (x * 8))), Quaternion.identity);
                    _readyToSpawn = false;
                }
            }
        }
    }

    void MoveGround()
    {
        
    }

}

    

