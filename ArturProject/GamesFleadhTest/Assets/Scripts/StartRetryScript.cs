using UnityEngine;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class StartRetryScript : MonoBehaviour 
{
    private RaycastHit hit = new RaycastHit();
    private Ray ray;
	void Start () 
    {
	
	}
	
	void FixedUpdate ()
    {
        //Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit2 = new RaycastHit();
        //if(Input.GetMouseButtonDown(0))
        //{
        //    if (Physics.Raycast(ray2, out hit2))
        //    {
        //        Application.LoadLevel("TestScene");
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.LoadLevel("TestScene");
        }
        if (Input.touchCount == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Debug.DrawLine(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit))
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
