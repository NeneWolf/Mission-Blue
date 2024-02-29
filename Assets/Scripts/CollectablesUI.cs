using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectablesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI trashType1;
    [SerializeField] TextMeshProUGUI trashType2;
    [SerializeField] TextMeshProUGUI trashType3;

    int currenttrashType1;
    int currenttrashType2;
    int currenttrashType3;

    public void UpdateUICollectables(TrashType trashType)
    {
        switch (trashType)
        {
            case TrashType.Metal:
                currenttrashType1++;
                trashType1.text = currenttrashType1.ToString();
                break;
            case TrashType.Glass:
                currenttrashType2++;
                trashType2.text = currenttrashType2.ToString();
                break;
            case TrashType.General:
                currenttrashType3++;
                trashType3.text = currenttrashType3.ToString();
                break;
            default:
                break;
        }
    }

    public void ResetCollectables()
    {
        currenttrashType1 = 0;
        currenttrashType2 = 0;
        currenttrashType3 = 0;
    }
}
