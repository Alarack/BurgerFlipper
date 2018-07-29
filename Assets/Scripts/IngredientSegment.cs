using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientSegment : MonoBehaviour
{
    //X is frequency, Y is DampingForce
    public Vector2 rawFlexibility;
    public Vector2 maxFlexibility;
    public float averageHeat = 0;

    private FoodCell[] checkCells;
    private FixedJoint2D fixedJoint;
    public Ingredient ParentIngredient { get; private set; }

    private ParticleSystem burnParticles;

    private void Awake()
    {
        fixedJoint = GetComponent<FixedJoint2D>();
        checkCells = GetComponentsInChildren<FoodCell>();
        burnParticles = GetComponentInChildren<ParticleSystem>();
    }

    public void Initalize(Ingredient parent)
    {
        ParentIngredient = parent;

        //Debug.Log(checkCells.Length + "Cells found in " + gameObject.name);

        int count = checkCells.Length;
        for (int i = 0; i < count; i++)
        {
            checkCells[i].Initialize(this);
        }
    }

    private void Update()
    {
        CheckAverageHeat();
    }

    private void CheckAverageHeat()
    {
        List<float> heatValues = new List<float>();

        float totalHeat = 0;

        int countOfCells = checkCells.Length;
        
        for (int i = 0; i < countOfCells; i++)
        {
            heatValues.Add(checkCells[i].currentHeat);
            totalHeat += checkCells[i].currentHeat;
        }

        averageHeat = totalHeat / heatValues.Count;

        if(fixedJoint != null)
            UpdateFlexibility();

        if (averageHeat > ParentIngredient.burnThreshold && burnParticles != null)
            burnParticles.Play();

    }

    private void UpdateFlexibility()
    {
        float modifer = averageHeat;

        if(averageHeat >= 0 || averageHeat <= 100)
        {
            modifer *= 0.01f;

            if (fixedJoint.frequency < maxFlexibility.x)
                fixedJoint.frequency = ((maxFlexibility.x - rawFlexibility.x) * modifer) + rawFlexibility.x;

            if(fixedJoint.dampingRatio < maxFlexibility.y)
                fixedJoint.dampingRatio = ((maxFlexibility.y - rawFlexibility.y) * modifer) + rawFlexibility.y;
        }
    }

}
