using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CollectManager : MonoBehaviour
{

    //private WorldSettings settings;

    public GameObject Collectible, player;
    public List<Object> collects = new List<Object>();
    //int index = 0;
    Vector3 _spawnPoint;
    Vector3 direction;
    Vector3 lanepos;
    Vector3 endpoint;
    private float timer = 0;
    public float SpawmTime = 0.05f;
    public int colCount = 3;
    int colCounter = 0;
    int otherColCounter = 0;
    int lane = 1;

    void Start()
    {
        direction = new Vector3(0, 0, 1);
        //_spawnPoint = player.transform.position;
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        //endpoint = GameObject.FindGameObjectWithTag("CurvedRight 1(Clone)");
        //if(endpoint == null)
        //    endpoint = GameObject.FindGameObjectWithTag("CurvedLeft 1(Clone)");
        /*var result = GameObject.Find("Controller");
		
        if (result != null)
        {
            var comp = result.GetComponent<WorldSettings>();
			
            if (comp != null)
                settings = comp as WorldSettings;
        }*/
    }

    void Update()
    {

        //timer += Time.deltaTime;

        //if (settings != null)
        //{

        for (int i = 0; i < collects.Count; i++)
        {
            Object col = collects[i];

            (col as GameObject).transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

            if ((col as GameObject).transform.position.z <= player.rigidbody.position.z - 10)
            {
                //cubes.Remove(cube);
                // Destroy(cube);	
                removeCollect(col);
                //print ("removeu antes!!!");
            }
            else
            {
                //(cube as GameObject).transform.Translate( new Vector3(0,0,-1)  , Space.Self);
            }
        }
        //}	

    }

    public bool isAtTheEnd() {
        if (direction.x != 0)
        {
            if ((_spawnPoint + (direction * (otherColCounter * 8))).x <= endpoint.x)
                return true;
        }
        else {
            if ((_spawnPoint + (direction * (otherColCounter * 8))).z >= endpoint.z)
                return true;
        }
        return false;
    }


    public void setCollects(){
        
        otherColCounter = 0;

        while (!isAtTheEnd() /*otherColCounter < 10*/)
        {
            switch (lane)
            {
                case 0:
                    collects.Add(Instantiate(Collectible, _spawnPoint - (lanepos * 2) + (direction * (otherColCounter * 8)), Quaternion.identity));
                    break;
                case 1:
                    collects.Add(Instantiate(Collectible, _spawnPoint + (direction * (otherColCounter * 8)), Quaternion.identity));
                    break;
                case 2:
                    collects.Add(Instantiate(Collectible, _spawnPoint + (lanepos * 2) + (direction * (otherColCounter * 8)), Quaternion.identity));
                    break;
                default:
                    break;
            }

            //Debug.Log(timer + " Instanciou \n");
            //timer = 0;
            colCounter++;
            otherColCounter++;
            //Debug.Log(cubeCounter + " \n");

            if (colCounter >= colCount)
            {
                lane = Random.Range(0, 3);
                //Debug.Log(lane + " \n");
                colCounter = 0;
            }
        }
    }

    public void SetEndPoint(Vector3 point) {
        endpoint = point;
    }

    public void ChangeFacig(int face) {        
        
        if (face == 0)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else {
            direction = new Vector3(0, 0, 1);
        }
        _spawnPoint = player.transform.position;
        //_spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        //endpoint = GameObject.FindGameObjectWithTag("SpawnPoint");

        lanepos.x = -direction.z;
        lanepos.z = -direction.x;

        setCollects();
    }

    public void removeCollect(Object obj)
    {
        collects.Remove(obj);
        Destroy(obj);
    }
}
