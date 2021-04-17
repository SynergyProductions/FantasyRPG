using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosiition = new Vector3(target.position.x, target.position.y, transform.position.z);
            targetPosiition.x = Mathf.Clamp(targetPosiition.x, minPosition.x, maxPosition.x);
            targetPosiition.y = Mathf.Clamp(targetPosiition.y, minPosition.y, maxPosition.y);

            transform.position = Vector3.Lerp(transform.position, targetPosiition, smoothing);

        }
    }
}
