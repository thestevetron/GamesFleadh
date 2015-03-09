using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectsManager : MonoBehaviour {

    // Use this for initialization

    public GameObject Object_, player;

    List<Object> objects = new List<Object>();
    Vector3 _spawnPoint;
    Vector3 direction;
    Vector3 lanepos, posoffset;
    Vector3 endpoint;
    private float timer = 0;
    public float SpawmTime = 0.05f;
    public int objsCount = 3, distMult = 16;
    int objCounter = 0;
    int otherObjCounter = 0;
    int lane = 1, textHeight;
    public float posOffset = 2; 

    void Start()
    {
        direction = new Vector3(0, 0, 1);
        _spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        //textHeight = gameObject.renderer.material.GetTexture(0).height;
    }

    void Update()
    {
        //timer += Time.deltaTime;

        for (int i = 0; i < objects.Count; i++)
        {
            Object obs = objects[i];

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
            if ((_spawnPoint + (direction * (otherObjCounter * distMult))).x <= endpoint.x)
                return true;
        }
        else
        {
            if ((_spawnPoint + (direction * (otherObjCounter * distMult))).z >= endpoint.z)
                return true;
        }
        //Debug.Log("deu merda");
        return false;
    }


    public void setObstacles()
    {

        otherObjCounter = 0;
        //Debug.Log("vai ver o end");

        lane = 2;

        while (!isAtTheEnd())
        {
            switch (lane)
            {
                case 0:
                    objects.Add(Instantiate(Object_, _spawnPoint - (lanepos * 4) + (direction * (otherObjCounter * distMult)) + posoffset, Quaternion.identity));
                    break;
                //case 1:
                //    objects.Add(Instantiate(Object_, _spawnPoint + (direction * (otherObjCounter * distMult)), Quaternion.identity));
                //    break;
                case 1:
                    objects.Add(Instantiate(Object_, _spawnPoint + (lanepos * 4) + (direction * (otherObjCounter * distMult) + posoffset), Quaternion.identity));
                    break;
                default:
                    break;
            }

            //for (int i = 0; i < GetComponent<CollectManager>().collects.Count; i++)
            //{
            //    Object col = GetComponent<CollectManager>().collects[i];

            //    if ((col as GameObject).transform.position == (objects[otherObjCounter] as GameObject).transform.position)
            //    {
            //        Debug.Log("msm lugar");
            //        GetComponent<CollectManager>().removeCollect(col);
            //    }
            //}

            //timer = 0;
            otherObjCounter++;

            lane = Random.Range(0, 2);
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
            posoffset = new Vector3(-posOffset, 1.5f , 0);
        }
        else
        {
            direction = new Vector3(0, 0, 1);
            posoffset = new Vector3(0, 1.5f, posOffset);
        }
        _spawnPoint = player.transform.position;

        lanepos.x = -direction.z;
        lanepos.z = -direction.x;

        //Debug.Log("vai setar");
        setObstacles();
    }

    public void removeObstacle(Object obj)
    {
        objects.Remove(obj);
        Destroy(obj);
    }
}