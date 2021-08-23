using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offSet;
    [Range(1,10)]
    public float smoothFactor;


    private void FixedUpdate()
    {
        Follow();
    }

    void Follow() 
    {
        Vector3 targetPosition = target.position + offSet;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
