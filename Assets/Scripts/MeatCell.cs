using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeatCell : MonoBehaviour {

    public float currentHeat;
    public float maxHeat = 100f;
    public float burnHeat = 150f;

    public float heatTransferMultiplier = 0.5f;



    public Gradient colorGradient;
    public LayerMask mask;

    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void AddHeat(float value)
    {
        currentHeat += value;

        float doneness = currentHeat / maxHeat;

        spriteRenderer.color = colorGradient.Evaluate(doneness);

        TransferHeat(value * heatTransferMultiplier);
    }


    private void TransferHeat(float value)
    {

       // Debug.DrawRay(transform.position, Vector2.up, Color.blue);

        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + new Vector2(0f, 0.125f), Vector2.up, 0.4f, mask);

        if(hit.collider != null)
        {

            //Debug.Log(hit.collider.gameObject.name + " was hit by a raycast");

            if (hit.collider.gameObject.tag != "MeatCell")
                return;

            //Debug.Log(hit.collider.gameObject.name + " was hit by a raycast");

            MeatCell cell = hit.collider.GetComponent<MeatCell>();

            cell.AddHeat(value);

        }
    }

}
