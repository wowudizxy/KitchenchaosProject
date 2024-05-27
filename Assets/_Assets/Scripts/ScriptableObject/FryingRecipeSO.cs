using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public List<FryingRecipe> fryingRecipesList;

    public bool TryGetFryingRecipe(KitchenObjectSO input,out FryingRecipe fryingRecipe){
        foreach (FryingRecipe recipe in fryingRecipesList)
        {
            if(input == recipe.input){
                fryingRecipe = recipe;
                return true;
            }
        }
        fryingRecipe = null;
        return false;
    }
}
[Serializable]
public class FryingRecipe{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float FryingTime;
}
