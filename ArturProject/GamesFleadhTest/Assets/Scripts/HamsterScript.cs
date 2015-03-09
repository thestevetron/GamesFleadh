using UnityEngine;
using System.Collections;

public class HamsterScript : MonoBehaviour {

    public GameObject player;
	void Start () {
        transform.position = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        //transform.position += new Vector3(0,2,0);
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

	}
}
