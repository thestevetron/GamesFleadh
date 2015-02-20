using UnityEngine;
using System.Collections;

public class AutoMovementComponent : MonoBehaviour
{
    private WorldSettings settings;
    public bool IsSourceForClone = true;

    void Start()
    {
        var result = GameObject.Find("Controller");

        if (result != null)
        {
            var comp = result.GetComponent<WorldSettings>();

            if (comp != null)
                settings = comp as WorldSettings;
        }
    }

    void Update()
    {
        if (settings != null && !IsSourceForClone)
        {
            if (gameObject.transform.position.z <= settings.KillZ)
                Destroy(gameObject);
            else
                transform.Translate(settings.GlobalMovementDirection * settings.GlobalMovementSpeed, Space.Self);
        }
    }
}
