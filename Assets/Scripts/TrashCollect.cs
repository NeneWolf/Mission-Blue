using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCollect : MonoBehaviour
{
    [SerializeField] TrashType TrashType;
    [SerializeField] GameObject trashObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectablesUI collectablesUI = FindObjectOfType<CollectablesUI>();
            if (collectablesUI != null)
            {
                collectablesUI.UpdateUICollectables(TrashType);
            }

            // Optionally, destroy the collected trash object
            Destroy(trashObject);
        }
    }
}


public enum TrashType
{
    Metal,
    Glass,
    General
}
