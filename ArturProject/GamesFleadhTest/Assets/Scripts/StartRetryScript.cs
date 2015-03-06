using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class StartRetryScript : MonoBehaviour 
{
    private RaycastHit hit;
    private Ray ray;
	void Start () 
    {
	
	}
	
	void FixedUpdate ()
    {
        if(Input.GetMouseButtonDown(0))
        {

            Application.LoadLevel("TestScene");
        }
        if (Input.touchCount == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Debug.DrawLine(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                if (hit.collider.tag == "StartRetry")
                {
                    Application.LoadLevel("TestScene");
                    Debug.Log(hit.transform.name);//Object you touched

                }

            }
        }
	}
}
