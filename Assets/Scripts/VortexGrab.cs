using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VortexGrab : MonoBehaviour {


    public float grabForce = -100f;
    private PointEffector2D pointEffector;

    private void Awake()
    {
        pointEffector = GetComponent<PointEffector2D>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Grab();
        }

        if (Input.GetMouseButtonUp(0))
            Release();
    }


    private void Grab()
    {
        pointEffector.enabled = true;
    }

    private void Release()
    {
        pointEffector.enabled = false;
    }

}
