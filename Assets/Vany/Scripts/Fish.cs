using UnityEngine;

public class Fish : MonoBehaviour
{
	public FlockManager manager;
	float speed;
	bool turning = false;
	Animator animator;

	void Start()
	{
        animator = GetComponent<Animator>();
        animator.SetBool("isSwimming", true);
        speed = Random.Range(manager.minSpeed, manager.maxSpeed);
	}

	void Update()
	{
		Bounds b = new Bounds(manager.transform.position, manager.swimLimits * 2);
		RaycastHit hit = new RaycastHit();
		Vector3 direction = Vector3.zero;

		if (!b.Contains(transform.position))
		{
			turning = true;
			direction = manager.transform.position - transform.position;
		}
		else if (Physics.Raycast(transform.position, this.transform.forward * 50, out hit))
		{
			turning = true;
			direction = Vector3.Reflect(this.transform.forward, hit.normal);
		}
		else
			turning = false;

		if (turning)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation,
												  Quaternion.LookRotation(direction),
												  manager.rotationSpeed * Time.deltaTime);
		}
		else
		{
			if (Random.Range(0, 100) < 10)
				speed = Random.Range(manager.minSpeed, manager.maxSpeed);
			if (Random.Range(0, 100) < 20)
				ApplyRules();
		}
		transform.Translate(0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = manager.allFish;

		Vector3 vcentre = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.01f;
		float nDistance;
		int groupSize = 0;

		foreach (GameObject go in gos)
		{
			if (go != this.gameObject)
			{
				nDistance = Vector3.Distance(go.transform.position, this.transform.position);
				if (nDistance <= manager.neighbourDistance)
				{
					vcentre += go.transform.position;
					groupSize++;

					if (nDistance < 1.0f)
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}

					Fish anotherFish = go.GetComponent<Fish>();
					gSpeed = gSpeed + anotherFish.speed;
				}
			}
		}

		if (groupSize > 0)
		{
			vcentre = vcentre / groupSize + (manager.goalPos - this.transform.position);
			speed = gSpeed / groupSize;

			Vector3 direction = (vcentre + vavoid) - transform.position;
			if (direction != Vector3.zero)
				transform.rotation = Quaternion.Slerp(transform.rotation,
													  Quaternion.LookRotation(direction),
													  manager.rotationSpeed * Time.deltaTime);
		}
	}
}
