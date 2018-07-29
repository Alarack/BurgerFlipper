using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFollowMouse : MonoBehaviour {




    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 desiredPos = new Vector2(mousePos.x, mousePos.y);

        transform.localPosition = desiredPos;
    }


}
