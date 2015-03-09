using UnityEngine;
using System.Collections;

public class QuitScript : MonoBehaviour 
{
    private RaycastHit hit = new RaycastHit();
    private Ray ray;
	void Start () 
    {
	
	}
	
	void Update ()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Application.Quit();
        //}

        if (Input.touchCount == 1)
        {
            ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Debug.DrawLine(ray.origin, ray.direction * 10);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Quit")
                {
                    Application.Quit();

                }

            }
        }
	}
}
