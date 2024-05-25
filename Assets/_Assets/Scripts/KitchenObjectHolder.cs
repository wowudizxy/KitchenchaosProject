using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObjectHolder : MonoBehaviour
{
    [SerializeField]private Transform holdPoint;
    private KitchenObject kitchenObject;
    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }
    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }
    public Transform GetHoldPoint(){
        return holdPoint;
    }
    
    public void TransferKitchenObject(ClearCounter sourceCounter,ClearCounter targetCounter){
        if(sourceCounter.GetKitchenObject() == null){
            Debug.LogWarning("原始柜台是空的,无法转移食材");
            return;
        }
        if(targetCounter.GetKitchenObject() != null){
            Debug.LogWarning("目标柜台上有食材,无法转移食材");
            return;
        }
        targetCounter.AddKitchenObject(sourceCounter.GetKitchenObject());
        sourceCounter.ClearKitchenObject();
    }
    public void ClearKitchenObject(){
        this.kitchenObject = null;
    }
    public void AddKitchenObject(KitchenObject kitchenObject){
        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
}
