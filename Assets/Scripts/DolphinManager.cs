using UnityEngine;

public class DolphinManager : MonoBehaviour
{
    public GameObject dolphinPrefab; // Assign your dolphin prefab in the Unity Editor
    public int numDolphins = 20; // Number of dolphins to spawn
    public Vector3 swimLimits = new Vector3(100, 50, 100); // Defines the area dolphins can swim in

    public float minSpeed = 4.0f; // Minimum swimming speed for dolphins
    public float maxSpeed = 8.0f; // Maximum swimming speed for dolphins
    public float rotationSpeed = 4.0f; // How quickly dolphins can change direction

    void Start()
    {
        for (int i = 0; i < numDolphins; i++)
        {
            SpawnDolphin();
        }
    }

    void SpawnDolphin()
    {
        // Smaller range for a tighter group at the start
        Vector3 dolphinPosition = new Vector3(
            Random.Range(-swimLimits.x / 4, swimLimits.x / 4), // Reduced range
            Random.Range(-swimLimits.y / 4, swimLimits.y / 4), // Reduced range
            Random.Range(-swimLimits.z / 4, swimLimits.z / 4) // Reduced range
        ) + transform.position;

        GameObject dolphin = Instantiate(dolphinPrefab, dolphinPosition, Quaternion.identity, transform);
        Dolphin dolphinScript = dolphin.GetComponent<Dolphin>();

        if (dolphinScript != null)
        {
            dolphinScript.speed = Random.Range(minSpeed, maxSpeed);
        }
    }

}
