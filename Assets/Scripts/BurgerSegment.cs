using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BurgerSegment : MonoBehaviour
{
    //X is frequency, Y is DampingForce
    public Vector2 rawFlexibility;
    public Vector2 maxFlexibility;
    public float averageHeat = 0;
    public float modifier;

    private List<MeatCell> checkCells = new List<MeatCell>();

    public void Start()
    {
        checkCells.AddRange(GetComponentsInChildren<MeatCell>());
        if (GetComponent<FixedJoint2D>() != null)
        {
            checkCells.AddRange(GetComponent<FixedJoint2D>().attachedRigidbody.gameObject.GetComponentsInChildren<MeatCell>());
        }
    }

    public void Update()
    {
        if(GetComponent<FixedJoint2D>() != null)
        {
            List<float> heatValues = new List<float>();

            foreach (MeatCell cell in checkCells)
            {
                heatValues.Add(cell.currentHeat);
            }
            foreach (float value in heatValues)
            {
                averageHeat += value;
            }
            averageHeat = averageHeat / heatValues.Count;
            UpdateFlexibility(averageHeat);
        }
    }


    public void UpdateFlexibility(float value)
    {
        if(value >= 0 || value <= 100)
        {
            value *= 0.01f;
            if(GetComponent<FixedJoint2D>().frequency < maxFlexibility.x)
            {
                GetComponent<FixedJoint2D>().frequency = ((maxFlexibility.x - rawFlexibility.x) * value) + rawFlexibility.x;
            }
            if (GetComponent<FixedJoint2D>().dampingRatio < maxFlexibility.y)
            {
                GetComponent<FixedJoint2D>().dampingRatio = ((maxFlexibility.y - rawFlexibility.y) * value) + rawFlexibility.y;
            }
        }
    }


}
