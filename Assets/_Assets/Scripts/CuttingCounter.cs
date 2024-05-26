using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSO CuttingkitchenObjectSO;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject()==false)
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
            if (IsHaveKitchenObject()==false)
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
                DestroyKitchenObject();
                CreateKitchenObject(CuttingkitchenObjectSO.kitchenObject);
                
            }
            else
            {
                
            }
        }
    }
}
