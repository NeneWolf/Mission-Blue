using UnityEngine;

public class FlockManager : MonoBehaviour
{
	public GameObject fishPrefab;
	public int numFish = 20;
	public GameObject[] allFish;
	public Vector3 swimLimits = new Vector3(5, 5, 5);
	public Vector3 goalPos;

	[Header("Fish Settings")]
	public float minSpeed = 0.5f;
	public float maxSpeed = 2.0f;
	public float neighbourDistance = 3.0f;
	public float rotationSpeed = 4.0f;

	void Start()
	{
		allFish = new GameObject[numFish];
		for (int i = 0; i < numFish; i++)
		{
			Vector3 pos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
																 Random.Range(-swimLimits.y, swimLimits.y),
																 Random.Range(-swimLimits.z, swimLimits.z));
			allFish[i] = (GameObject)Instantiate(fishPrefab, pos, Quaternion.identity);
			allFish[i].GetComponent<Fish>().manager = this;
		}
		goalPos = this.transform.position;
	}

	void Update()
	{
		if (Random.Range(0, 100) < 10)
		{
			goalPos = this.transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x),
															 Random.Range(-swimLimits.y, swimLimits.y),
															 Random.Range(-swimLimits.z, swimLimits.z));
		}
	}
}
