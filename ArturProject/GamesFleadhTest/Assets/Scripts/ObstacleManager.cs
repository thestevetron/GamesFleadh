using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleManager : MonoBehaviour {

	// Use this for initialization

    public GameObject Obstacle, player;

    List<Object> obstacles = new List<Object>();
    Vector3 _spawnPoint;
    Vector3 direction;
    Vector3 lanepos;
    Vector3 endpoint;
    private float timer = 0;
    public float SpawmTime = 0.05f;
    public int obstCount = 3, distMult = 16;
    int obstCounter = 0;
    int otherObstCounter = 0;
    int lane = 1;

	void Start () {
        direction = new Vector3(0, 0, 1);
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
	}
	
	void Update () {
        //timer += Time.deltaTime;

        for (int i = 0; i < obstacles.Count; i++)
        {
            Object obs = obstacles[i];

            (obs as GameObject).transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);

            if ((obs as GameObject).transform.position.z <= player.rigidbody.position.z - 10)
            {
                removeObstacle(obs);

            }
        }
	}

    public bool isAtTheEnd()
    {
        if (direction.x != 0)
        {
            if ((_spawnPoint + (direction * (otherObstCounter * distMult))).x <= endpoint.x)
                return true;
        }
        else
        {
            if ((_spawnPoint + (direction * (otherObstCounter * distMult))).z >= endpoint.z)
                return true;
        }
        //Debug.Log("deu merda");
        return false;
    }


    public void setObstacles()
    {

        otherObstCounter = 0;
        //Debug.Log("vai ver o end");

        lane = 2;

        while (!isAtTheEnd())
        {
            switch (lane)
            {
                case 0:
                    obstacles.Add(Instantiate(Obstacle, _spawnPoint - (lanepos * 2) + (direction * (otherObstCounter * distMult)), Quaternion.identity));
                    break;
                case 1:
                    obstacles.Add(Instantiate(Obstacle, _spawnPoint + (direction * (otherObstCounter * distMult)), Quaternion.identity));
                    break;
                case 2:
                    obstacles.Add(Instantiate(Obstacle, _spawnPoint + (lanepos * 2) + (direction * (otherObstCounter * distMult)), Quaternion.identity));
                    break;
                default:
                    break;
            }

            for (int i = 0; i < GetComponent<CollectManager>().collects.Count; i++) {
                Object col = GetComponent<CollectManager>().collects[i];

                if ((col as GameObject).transform.position == (obstacles[otherObstCounter] as GameObject).transform.position)
                {
                    Debug.Log("msm lugar"); 
                    GetComponent<CollectManager>().removeCollect(col);
                }
            }

            //timer = 0;
            otherObstCounter++;
            
           lane = Random.Range(0, 3);
           //Debug.Log("instanciando");
        }
    }

    public void SetEndPoint(Vector3 point)
    {
        endpoint = point;
    }

    public void ChangeFacig(int face)
    {

        if (face == 0)
        {
            direction = new Vector3(-1, 0, 0);
        }
        else
        {
            direction = new Vector3(0, 0, 1);
        }
        _spawnPoint = player.transform.position;
        
        lanepos.x = -direction.z;
        lanepos.z = -direction.x;

        //Debug.Log("vai setar");
        setObstacles();
    }

    public void removeObstacle(Object obj)
    {
        obstacles.Remove(obj);
        Destroy(obj);
    }
}
