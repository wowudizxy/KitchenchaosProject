using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if(GetKitchenObject()== null){
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.kitchenObject,GetHoldPoint().position,GetHoldPoint().rotation,GetHoldPoint())
            .GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }else{
            TransferKitchenObject(this,player);
        }
    }
}
