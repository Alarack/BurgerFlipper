using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerValidator : MonoBehaviour {

    public List<Ingredient.IngredientType> requiredTypes = new List<Ingredient.IngredientType>();


    private List<Ingredient.IngredientType> currentTypes = new List<Ingredient.IngredientType>();
        





    public bool CheckForCompleteBurger()
    {
        bool result = true;
        int countOfRequired = requiredTypes.Count;

        for (int i = 0; i < countOfRequired; i++)
        {
            if (currentTypes.Contains(requiredTypes[i]) == false)
                return false;
        }

        return result;
    }




    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<IngredientSegment>().ParentIngredient;



            if(ingredient != null)
            {
                Debug.Log(ingredient.IsCooked + " " + ingredient.doneness.AverageHeat +  " is the status of cooked for " + ingredient.gameObject.name);

                if (currentTypes.Contains(ingredient.ingredientType) == false)
                {
                    currentTypes.Add(ingredient.ingredientType);
                }

            }

            if (CheckForCompleteBurger() == true)
                Debug.Log("Complete");
            else
            {
                Debug.Log("Not Yet");
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ingredient")
        {
            Ingredient ingredient = other.GetComponent<IngredientSegment>().ParentIngredient;

            if (ingredient != null)
            {
                if(currentTypes.Contains(ingredient.ingredientType))
                    currentTypes.Remove(ingredient.ingredientType);
            }


        }
    }


}
