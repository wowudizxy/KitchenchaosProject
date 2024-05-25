using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if(player.IsHaveKitchenObject()) return;
        CreateKitchenObject(kitchenObjectSO.kitchenObject);
        TransferKitchenObject(this,player);
    }
    void CreateKitchenObject(GameObject KitchenObject){
        KitchenObject kitchenObject = Instantiate(KitchenObject,GetHoldPoint().position,GetHoldPoint().rotation,GetHoldPoint())
        .GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
}
