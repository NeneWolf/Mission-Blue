using MalbersAnimations;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class WaterCheck : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] MalbersInput playerInput;
    [SerializeField] Transform respawnPoint;

    [SerializeField] GameObject UIOxygen;
    [SerializeField] Image oxygenSlider;

    string waterTag = "Water";

    public float currentOxygen;
    float MaxOxygen;

    float rate = 1f;

    bool isInSurface;

    private void Start()
    {
        MaxOxygen = 100;
        currentOxygen = MaxOxygen;
    }

    private void Update()
    {
        if(currentOxygen < MaxOxygen)
            UIOxygen.gameObject.SetActive(true);
        else
            UIOxygen.gameObject.SetActive(false);

        oxygenSlider.fillAmount = currentOxygen /100;


        if(currentOxygen <= 0)
        {
            playerInput.SetEnable(false);
            player.transform.position = respawnPoint.position;
            playerInput.SetEnable(true);
        }      
    }

    void RegenerateOxygen()
    {
        currentOxygen += rate;
        currentOxygen = Mathf.Clamp(currentOxygen, 0.0f, MaxOxygen);
    }

    void DepleedOxygen()
    {
        currentOxygen -= rate;
        currentOxygen = Mathf.Clamp(currentOxygen, 0.0f, MaxOxygen);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(waterTag))
        {
            isInSurface = false;
            CancelInvoke("RegenerateOxygen");
            InvokeRepeating("DepleedOxygen", 1.0f, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(waterTag))
        {
            isInSurface = true;
            CancelInvoke("DepleedOxygen");
            InvokeRepeating("RegenerateOxygen", 1.0f, 1.0f); // Call RegenerateOxygen every second
        }
    }

}
