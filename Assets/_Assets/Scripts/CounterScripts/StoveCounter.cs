using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO fryingRecipeSO;
    [SerializeField] private StoveCounterVisual stoveCounterVisual;
    [SerializeField] private ProgressBarUI progressBarUI;
    private FryingRecipe fryingRecipe;
    public enum FryingState
    {
        Idle,
        Cooking,
        Burning
    }
    private FryingState state = FryingState.Idle;
    private float fryingTimer;
    public override void Interact(Player player)
    {
        if (player.IsHaveKitchenObject())
        {
            if (IsHaveKitchenObject() == false && fryingRecipeSO.TryGetFryingRecipe(player.GetKitchenObject()
            .GetKitchenObjectSO(), out FryingRecipe fryingRecipe))
            {
                TransferKitchenObject(player, this);
                
                StartCooking(fryingRecipe);
            }
            else
            {

            }

        }
        else
        {//玩家没有食材
            if (IsHaveKitchenObject())
            {
                TransferKitchenObject(this, player);
                StartIdle();
            }
            else
            {

            }
        }
    }
    private void Update()
    {
        switch (state)
        {
            case FryingState.Idle:
                break;
            case FryingState.Cooking:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.FryingTime);
                if (fryingTimer >= fryingRecipe.FryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.kitchenObject);
                    if(fryingRecipeSO.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),out FryingRecipe newFryingRecipe))
                    {
                        StartBurning(newFryingRecipe);
                    }else{
                        StartIdle();
                    }
                }
                break;
            case FryingState.Burning:
                fryingTimer += Time.deltaTime;
                progressBarUI.UpdateProgress(fryingTimer / fryingRecipe.FryingTime);
                if (fryingTimer >= fryingRecipe.FryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.kitchenObject);
                    StartIdle();
                }
                break;

            default:
                break;
        }
    }
    public void StartIdle(){
        state = FryingState.Idle;
        stoveCounterVisual.HideStoveSpecialEffect();
        progressBarUI.hide();

    }

    public void StartCooking(FryingRecipe fryingRecipe)
    {
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = FryingState.Cooking;
        stoveCounterVisual.ShowStoveSpecialEffect();
        
    }
    public void StartBurning(FryingRecipe fryingRecipe){
        if(fryingRecipe == null){
            Debug.LogWarning("没有找到对应的recipe");
            state = FryingState.Idle;
            return;
        }
        fryingTimer = 0;
        this.fryingRecipe = fryingRecipe;
        state = FryingState.Burning;
        stoveCounterVisual.ShowStoveSpecialEffect();
        
    }
}
