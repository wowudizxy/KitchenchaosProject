using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]private GameObject selectedCounter;
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    [SerializeField]private Transform topPoint;
    [SerializeField]private ClearCounter targetCounter;

    private KitchenObject kitchenObject;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.F)){
            print("F");
            TransferKitchenObject(this,targetCounter);
        }
    }
    public void Interact(){
        if(GetKitchenObject()== null){
            kitchenObject = Instantiate(kitchenObjectSO.kitchenObject,topPoint.position,topPoint.rotation,topPoint)
            .GetComponent<KitchenObject>();
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
    public KitchenObject GetKitchenObject(){
        return kitchenObject;
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
        kitchenObject.transform.SetParent(topPoint);
        kitchenObject.transform.localPosition = Vector3.zero;
        this.kitchenObject = kitchenObject;
    }

}
