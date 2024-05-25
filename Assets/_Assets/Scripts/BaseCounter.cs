using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : KitchenObjectHolder
{
    
    [SerializeField]private GameObject selectedCounter;
    public virtual void Interact(Player player){

    }
    public void SelectedCounter(){
        selectedCounter.SetActive(true);
    }
    public void UnSelectedCounter(){
        selectedCounter.SetActive(false);
    }
}
