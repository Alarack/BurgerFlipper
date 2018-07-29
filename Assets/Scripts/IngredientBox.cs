using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : MonoBehaviour {


    public GameObject ingredientPrefab;
    public int countToSpawn;
    public Transform spawnPoint;





    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Spawn();
        }
    }




    public void Spawn()
    {
        for (int i = 0; i < countToSpawn; i++)
        {
            Instantiate(ingredientPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

}
