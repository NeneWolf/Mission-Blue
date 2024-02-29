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

    Transform target;
    Transform lastAimTarget;

    private void Update()
    {
        if(aim.AimTarget != null)
        {
            target = aim.AimTarget;
            
            if(target != lastAimTarget )
            {
                OnAimTargetChanged();
            }

            lastAimTarget = target;
        }
    }

    private void OnAimTargetChanged()
    {
        convaiTrigger.TriggerChatKnowledge(aim.AimTarget.name);
    }
}
