using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField]private GameObject selectedCounter;
    public void Interect(){
        print(transform.name+" is interected");
    }
    public void SelectedCounter(){
        selectedCounter.SetActive(true);
    }
    public void UnSelectedCounter(){
        selectedCounter.SetActive(false);
    }

}
