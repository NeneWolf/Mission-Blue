using UnityEngine;

public class Shark : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 2.0f;
    public Vector3 swimLimits = new Vector3(50, 10, 50);
    private Vector3? targetPosition = null;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the shark GameObject.");
        }
        else
        {
            animator.SetBool("isSwimming", true); 
        }
    }

    void Update()
    {
        if (!targetPosition.HasValue || Vector3.Distance(transform.position, targetPosition.Value) < 2.0f)
        {
            Vector3 centerPoint = transform.parent != null ? transform.parent.position : Vector3.zero; 
            targetPosition = new Vector3(
                Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y/2, swimLimits.y/2),
                Random.Range(-swimLimits.z, swimLimits.z)
            ) + centerPoint;
        }
        MoveTowards(targetPosition.Value);
    }

    void MoveTowards(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
    
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime; 
    }
}

