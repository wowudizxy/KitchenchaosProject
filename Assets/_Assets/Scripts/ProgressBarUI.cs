using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private Image progressImage;
    private void Start() {
        
    }
    public void show(){
        gameObject.SetActive(true);
    }
    public void hide(){
        
        gameObject.SetActive(false);
    }
    public void UpdateProgress(float progress)
    {
        show();
        progressImage.fillAmount = progress;
    }
}
