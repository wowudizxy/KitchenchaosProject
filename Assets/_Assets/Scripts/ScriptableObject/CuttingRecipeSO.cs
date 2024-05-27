using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class CuttingRecipe
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public int cuttingCountMax;
}
[CreateAssetMenu]
public class CuttingRecipeListSO : ScriptableObject
{
    public List<CuttingRecipe> cuttingRecipeSOList;
    public KitchenObjectSO GetOutput(KitchenObjectSO input){
        foreach (CuttingRecipe kitchenObjectSO in cuttingRecipeSOList)
        {
            if(input == kitchenObjectSO.input){
                return kitchenObjectSO.output;
            }
        }
        return null;
    }
    public bool TryGetCuttingRecipe(KitchenObjectSO input,out CuttingRecipe cuttingRecipe){
        foreach (CuttingRecipe recipe in cuttingRecipeSOList)
        {
            if(input == recipe.input){
                cuttingRecipe = recipe;
                return true;
            }
        }
        cuttingRecipe = null;
        return false;
    }
}

