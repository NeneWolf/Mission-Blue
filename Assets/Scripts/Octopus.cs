using UnityEngine;
using System.Collections;

public class Octopus : MonoBehaviour
{
    public float moveSpeed = 1f; 
    public Vector2 moveArea = new Vector2(10f, 10f); 
    public float directionChangeInterval = 5f; 
    private Vector3 nextPosition;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ChangePositionRoutine());
    }

    void Update()
    {
        MoveSquid();

   
        bool isMoving = Vector3.Distance(transform.position, nextPosition) > 0.1f;
        animator.SetBool("isWalking", isMoving);
    }

    IEnumerator ChangePositionRoutine()
    {
        while (true)
        {
            SetNextPosition();

          
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }

    void MoveSquid()
    {
       
        Vector3 directionToNextPosition = (nextPosition - transform.position).normalized;
        if (directionToNextPosition != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(directionToNextPosition);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
        }

       
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
    }

    void SetNextPosition()
    {
       
        float xPosition = Random.Range(-moveArea.x / 2, moveArea.x / 2);
        float zPosition = Random.Range(-moveArea.y / 2, moveArea.y / 2);
        nextPosition = new Vector3(xPosition, transform.position.y, zPosition);
    }
}
