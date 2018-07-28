using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : MonoBehaviour {

    

    private HingeJoint2D hinge;
    private Rigidbody2D mybody;


    private void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        mybody = GetComponent<Rigidbody2D>();
    }


    //private void OnMouseDown()
    //{
    //    if(mybody != null && mybody.bodyType != RigidbodyType2D.Kinematic)
    //    {
    //        mybody.constraints = RigidbodyConstraints2D.FreezeRotation;
    //    }
    //}

    //private void OnMouseUp()
    //{
    //    if (mybody != null && mybody.bodyType != RigidbodyType2D.Kinematic)
    //    {
    //        mybody.constraints = RigidbodyConstraints2D.None;
    //    }
    //}



    private void Update()
    {

        if (hinge == null)
            return;

        if (Input.GetMouseButtonDown(1))
        {
            hinge.useMotor = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            hinge.useMotor = false;
        }
    }

}
