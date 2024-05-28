using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject SizzlingParticles;
    [SerializeField] private GameObject StoveOnVisual;

    public void ShowStoveSpecialEffect(){
        SizzlingParticles.SetActive(true);
        StoveOnVisual.SetActive(true);
    }
    public void HideStoveSpecialEffect(){
        SizzlingParticles.SetActive(false);
        StoveOnVisual.SetActive(false);
    }
}
