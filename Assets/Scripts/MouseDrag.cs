using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDrag : MonoBehaviour
{

    private Rigidbody2D body;

    private Vector2 lastMousePos;
    private Vector2 mouseDelta;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        mouseDelta = (Vector2)Input.mousePosition - lastMousePos;

        lastMousePos = Input.mousePosition;
    }


    private void OnMouseUp()
    {

        if (body != null && body.bodyType != RigidbodyType2D.Kinematic)
        {
           body.velocity += mouseDelta * 1.1f;

           // body.AddRelativeForce(mouseDelta);
        }
    }


    private void OnMouseDrag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (body != null)
        {
            body.MovePosition(new Vector3(mousePos.x, mousePos.y, -5f));
            Debug.Log("Draging RigidBody");
        }
        else
        {
            transform.position = new Vector3(mousePos.x, mousePos.y, -5f);
            Debug.Log("Draging Transform");
        }
    }
}
