using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour {

    public enum IngredientType {
        Burger,
        Onion,
        Pickle,
        Tomato,
        Bun,
        Cheese
    }

    public bool IsCooked { get { return doneness.IsCooked(); } }

    public IngredientType ingredientType;
    public Gradient colorGradient;
    public float burnThreshold = 80f;

    [Header("Doneness Checker")]
    public DonenessChecker doneness;

    private IngredientSegment[] segments;


    private void Awake()
    {
        segments = GetComponentsInChildren<IngredientSegment>();
        doneness.SetSegments(segments);
    }

    private void Start()
    {
        int count = segments.Length;
        for (int i = 0; i < count; i++)
        {
            segments[i].Initalize(this);
        }
    }


    [System.Serializable]
    public class DonenessChecker {
        public float AverageHeat { get { return TotalHeat / segments.Length; } }
        public float TotalHeat { get { return GetTotalHeat(); } }

        public float minHeat = 45f;
        public float maxHeat = 85f;

        private IngredientSegment[] segments;

        public void SetSegments(IngredientSegment[] segments)
        {
            this.segments = segments;
        }
        
        public bool IsCooked()
        {
            return AverageHeat > minHeat && AverageHeat < maxHeat;
        }

        public float GetTotalHeat()
        {
            float result = 0f;

            int count = segments.Length;
            for (int i = 0; i < count; i++)
            {
                result += segments[i].averageHeat;
            }

            return result;
        }
    }


}
