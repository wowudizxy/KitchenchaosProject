using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeListSO CuttingkitchenObjectSO;
    private int cuttingCount = 0;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject() == false)
            {
                TransferKitchenObject(player, this);
            }
            else
            {

            }

        }
        else
        {//玩家没有食材
            if (IsHaveKitchenObject())
            {
                TransferKitchenObject(this, player);
                cuttingCount = 0;
            }
            else
            {

            }
        }
    }
    public override void InteractOperate(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject() == false)
            {

            }
            else
            {

            }

        }
        else
        {//玩家没有食材
            if (IsHaveKitchenObject())
            {

                if (CuttingkitchenObjectSO.TryGetCuttingRecipe(GetKitchenObject().GetKitchenObjectSO()
                    , out CuttingRecipe CuttingRecipe))
                {
                    cuttingCount++;
                    if (cuttingCount == CuttingRecipe.cuttingCountMax)
                    {
                        //cuttingCount = 0;
                        DestroyKitchenObject();
                        CreateKitchenObject(CuttingRecipe.output.kitchenObject);
                    }

                }
            }
            else
            {

            }
        }
    }
}
