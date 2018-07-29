using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WholeIngredient : MonoBehaviour {

    public Ingredient.IngredientType ingredientType;

    public GameObject slicePrefab;
    public int numberOfSlices;




    public void Slice(Transform spawnPoint)
    {
        for (int i = 0; i < numberOfSlices; i++)
        {
            Instantiate(slicePrefab, spawnPoint.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

}
