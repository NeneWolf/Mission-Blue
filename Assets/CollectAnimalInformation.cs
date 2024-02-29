using Convai.Scripts.Utils;
using MalbersAnimations.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAnimalInformation : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] ConvaiTextInOut convaiTrigger;
    private Transform lastAimTarget;

    private void Start()
    {
        // Subscribe to the AimTargetChanged event to be notified when the AimTarget changes.
        aim.OnSetTarget.AddListener(OnAimTargetChanged);
    }

    private void OnAimTargetChanged(Transform newAimTarget)
    {
        // Collect data or perform actions based on the new AimTarget.
        //Debug.Log($"AimTarget changed to: {newAimTarget}");

        convaiTrigger.TriggerChatKnowledge(newAimTarget.name);

        //// Example: Check if the AimTarget is different from the last one.
        //if (newAimTarget != lastAimTarget)
        //{
        //    // Collect additional data or perform specific actions.
        //    Debug.Log("AimTarget has changed.");
        //}

        //// Update the lastAimTarget for future comparisons.
        //lastAimTarget = newAimTarget;
    }
}
