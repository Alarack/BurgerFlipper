using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerLever : MonoBehaviour {

    //public bool switched;
    public float angle;

    private HingeJoint2D hinge;

    public bool topHit;
    public bool bottomHit;

    private Slicer slicer;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
    }


    public void Initialize(Slicer slicer)
    {
        this.slicer = slicer;
    }

    private void Update()
    {
        angle = hinge.jointAngle;
        ActivateSwitches();

    }


    private void ActivateSwitches()
    {
        if (angle <= -55f)
            topHit = true;

        if (angle >= 55f)
            bottomHit = true;

        if (topHit && bottomHit)
        {
            slicer.OpenGate();
            topHit = false;
            bottomHit = false;

        }

    }




}
