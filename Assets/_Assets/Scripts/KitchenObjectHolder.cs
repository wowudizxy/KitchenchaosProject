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
    public bool IsHaveKitchenObject(){
        return kitchenObject!=null;
    }
    
    public void TransferKitchenObject(KitchenObjectHolder sourceHolder,KitchenObjectHolder targetHolder){
        if(sourceHolder.GetKitchenObject() == null){
            Debug.LogWarning("原始持有者是空的,无法转移食材");
            return;
        }
        if(targetHolder.GetKitchenObject() != null){
            Debug.LogWarning("目标持有者有食材,无法转移食材");
            return;
        }
        targetHolder.AddKitchenObject(sourceHolder.GetKitchenObject());
        sourceHolder.ClearKitchenObject();
    }
    public void ClearKitchenObject(){
        this.kitchenObject = null;
    }
    public void AddKitchenObject(KitchenObject kitchenObject){
        kitchenObject.transform.SetParent(holdPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }
    public void CreateKitchenObject(GameObject KitchenObject){
        KitchenObject kitchenObject = Instantiate(KitchenObject,GetHoldPoint().position,GetHoldPoint().rotation,GetHoldPoint())
        .GetComponent<KitchenObject>();
        SetKitchenObject(kitchenObject);
    }
    public void DestroyKitchenObject(){
        Destroy(kitchenObject.gameObject);
        ClearKitchenObject();
    }
}
