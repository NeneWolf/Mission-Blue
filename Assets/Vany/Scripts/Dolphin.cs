using UnityEngine;

public class Dolphin : MonoBehaviour
{
    public float speed = 8.0f; 
    public float rotationSpeed = 4.0f; 
    public Vector3 swimLimits = new Vector3(100, 50, 100);
    private Vector3? targetPosition = null;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
       
      
      animator.SetBool("isWalking", true); 
        
    }

    void Update()
    {
       
        if (!targetPosition.HasValue || Vector3.Distance(transform.position, targetPosition.Value) < 2.0f)
        {
            Vector3 centerPoint = transform.parent != null ? transform.parent.position : Vector3.zero;
            
            targetPosition = new Vector3(
                Random.Range(-swimLimits.x, swimLimits.x),
                Random.Range(-swimLimits.y, swimLimits.y / 2), 
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

        float adjustedSpeed = speed;
        if (target.y > transform.position.y)
        {
            adjustedSpeed *= 1.5f; 
        }

        transform.position += transform.forward * adjustedSpeed * Time.deltaTime;
    }
}