using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : KitchenObjectHolder
{
    [SerializeField]private GameObject selectedCounter;
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    
    [SerializeField]private ClearCounter targetCounter;

    
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            print("F");
            TransferKitchenObject(this,targetCounter);
        }
    }
    public void Interact(){
        if(GetKitchenObject()== null){
            KitchenObject kitchenObject = Instantiate(kitchenObjectSO.kitchenObject,GetHoldPoint().position,GetHoldPoint().rotation,GetHoldPoint())
            .GetComponent<KitchenObject>();
            SetKitchenObject(kitchenObject);
        }else{
            Debug.LogWarning(gameObject+"有食材");
        }
        

    }
    
    public void SelectedCounter(){
        selectedCounter.SetActive(true);
    }
    public void UnSelectedCounter(){
        selectedCounter.SetActive(false);
    }
    

}
