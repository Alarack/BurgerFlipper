using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlicerKillZone : MonoBehaviour {


    public Transform spawnPoint;

    private Slicer slicer;


    public void Initialize(Slicer slicer)
    {
        this.slicer = slicer;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "WholeIngredient")
            return;

        WholeIngredient target = other.GetComponent<WholeIngredient>();

        if(target == null)
        {
            Debug.LogError("You tried to slice something that wasn't a whole ingredient");
            return;
        }

        target.Slice(spawnPoint);
        slicer.ResetGates();
    }


}
