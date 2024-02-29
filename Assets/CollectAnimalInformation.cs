using Convai.Scripts.Utils;
using MalbersAnimations.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CollectAnimalInformation : MonoBehaviour
{
    [SerializeField] Aim aim;
    [SerializeField] ConvaiTextInOut convaiTrigger;
    [SerializeField] GameObject ConvaiCanvas;

    Transform target;
    Transform lastAimTarget;

    private void Update()
    {
        if (aim.AimTarget != null)
        {
            target = aim.AimTarget;

            if (target != lastAimTarget)
            {
                OnAimTargetChanged();
            }

            lastAimTarget = target;
        }
        else if(aim.AimTarget == null && ConvaiCanvas.activeInHierarchy == true)
        {
            ConvaiCanvas.SetActive(false);
        }
    }

    private void OnAimTargetChanged()
    {
        ConvaiCanvas.SetActive(true);
        convaiTrigger.TriggerChatKnowledge(aim.AimTarget.name);
    }
}