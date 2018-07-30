using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotate : MonoBehaviour {


    public float timeToComplete = 10f;


	void Update () {
        transform.Rotate(Vector3.forward, -(200f * Time.deltaTime) / timeToComplete, Space.Self);
	}
}
