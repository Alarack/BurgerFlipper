using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSource : MonoBehaviour {


    public Vector2 minSizzleForce;
    public Vector2 maxSizzleForce;

    public float heatAmount = 0.2f;




    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name + " is Staying within " + gameObject.name);

        if (other.gameObject.tag == "Ingredient")
        {
            float yForce = Random.Range(minSizzleForce.y, maxSizzleForce.y);
            float xForce = Random.Range(minSizzleForce.x, maxSizzleForce.x);

            other.GetComponent<Rigidbody2D>().AddForce(new Vector2(xForce, yForce));
        }




        if (other.gameObject.tag != "MeatCell")
            return;

        MeatCell cell = other.gameObject.GetComponent<MeatCell>();

        cell.AddHeat(heatAmount);
    }




}
