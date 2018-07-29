using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityLimiter : MonoBehaviour {

    public Vector2 maxVelocity = new Vector2(50f, 50f);



    private Rigidbody2D body;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        float desiredX = body.velocity.x > maxVelocity.x ? maxVelocity.x : body.velocity.x;
        float desiredY = body.velocity.y > maxVelocity.y ? maxVelocity.y : body.velocity.y;

        body.velocity = new Vector2(desiredX, desiredY);


    }

}
