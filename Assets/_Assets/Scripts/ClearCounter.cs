using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]private GameObject selectedCounter;
    [SerializeField]private KitchenObjectSO kitchenObjectSO;
    [SerializeField]private Transform topPoint;
    public void Interect(){
        GameObject go = GameObject.Instantiate(kitchenObjectSO.kitchenObject, topPoint.position, topPoint.rotation);
        go.transform.SetParent(topPoint);
    }
    public void SelectedCounter(){
        selectedCounter.SetActive(true);
    }
    public void UnSelectedCounter(){
        selectedCounter.SetActive(false);
    }

}
