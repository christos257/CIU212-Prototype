using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollider : MonoBehaviour
{

    private PlatformEffector2D effector;
    private bool doubleTap;
    public float doubleTapTime;
    private bool reset;

    private void Start()
    {
        doubleTap = false;
        reset = false;
        effector = GetComponent<PlatformEffector2D>();
    }

    private void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.S) && doubleTap)
        {
            if (Time.time - doubleTapTime < 0.2f)
            {
                Debug.Log("Double-tapped");
                doubleTapTime = 0f;
                effector.rotationalOffset = 180f;
            }
            doubleTap = false;
        }
        if (reset)
        {
            doubleTap = false;
            reset = false;
        }
        if (Input.GetKeyDown(KeyCode.S) && !doubleTap)
        {
            doubleTap = true;
            doubleTapTime = Time.time;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            effector.rotationalOffset = 0;
        }
    }
}
