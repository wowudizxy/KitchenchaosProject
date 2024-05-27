using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO fryingRecipeSO;
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
                state = FryingState.Idle;
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
                if (fryingTimer >= fryingRecipe.FryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.kitchenObject);
                    if(fryingRecipeSO.TryGetFryingRecipe(GetKitchenObject().GetKitchenObjectSO(),out FryingRecipe newFryingRecipe))
                    {
                        StartBurning(newFryingRecipe);
                        
                    }
                }
                break;
            case FryingState.Burning:
                fryingTimer += Time.deltaTime;
                if (fryingTimer >= fryingRecipe.FryingTime)
                {
                    DestroyKitchenObject();
                    CreateKitchenObject(fryingRecipe.output.kitchenObject);
                    state = FryingState.Idle;
                }
                break;

            default:
                break;
        }
    }
    public void StartCooking(FryingRecipe fryingRecipe)
    {
        this.fryingRecipe = fryingRecipe;
        state = FryingState.Cooking;
        fryingTimer = 0;
    }
    public void StartBurning(FryingRecipe fryingRecipe){
        this.fryingRecipe = fryingRecipe;
        state = FryingState.Burning;
        fryingTimer = 0;
    }
}
