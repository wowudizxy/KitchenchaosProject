using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    
    // [SerializeField]private ClearCounter targetCounter;

    
    // private void Update() {
    //     if(Input.GetKeyDown(KeyCode.F)){
    //         print("F");
    //         TransferKitchenObject(this,targetCounter);
    //     }
    // }
    public override void Interact(Player player){
        if(GetKitchenObject()== null){
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.kitchenObject,GetHoldPoint().position,GetHoldPoint().rotation,GetHoldPoint())
            .GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }else{
            TransferKitchenObject(this,player);
        }
        

    }
    
   
    

}
