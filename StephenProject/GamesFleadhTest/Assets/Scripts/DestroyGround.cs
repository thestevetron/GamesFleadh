using UnityEngine;
using System.Collections;

public class DestroyGround : MonoBehaviour 
{
    GameObject _player, _controller;

	void Start () 
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _controller = GameObject.FindGameObjectWithTag("Controller");
	}
	

	void Update () 
    {
        if(transform.position.z < (_player.transform.position.z  - 10))
        {
            //_controller.GetComponent<GroundGeneration>()._groundPieces.RemoveAt(1);
            //_controller.GetComponent<GroundGeneration>()._groundPieces.Clear();
            Destroy(this.gameObject);
        }
	}
}
