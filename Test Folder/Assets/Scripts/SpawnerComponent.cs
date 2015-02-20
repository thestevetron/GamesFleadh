using UnityEngine;
using System.Collections;

public class SpawnerComponent : MonoBehaviour
{
    private float timer = 0;
    public float SpawmTime = 10;
    public string ObjectToSpawnName;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= SpawmTime)
        {
            SpawnObject(gameObject.transform.position);
            timer = 0;
        }
    }

    private void SpawnObject(Vector3 position)
    {
        if (!string.IsNullOrEmpty(ObjectToSpawnName))
        {
            var startingSource = GameObject.Find(ObjectToSpawnName);

            if (startingSource != null)
            {
               var result = Instantiate(startingSource, position, Quaternion.identity);

                if(result != null)
                {
                    if(result is GameObject)
                    {
                        var moveComp = (result as GameObject).GetComponent<AutoMovementComponent>();
                        moveComp.IsSourceForClone = false;
                        (result as GameObject).transform.Rotate(new Vector3(90, 0, 0));
                    }
                }
            }
        }
    }
}
