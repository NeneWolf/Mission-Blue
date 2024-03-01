using UnityEngine;
using System.Collections;

public class JellyfishIdle : MonoBehaviour
{
    private Animator animator;

    public float minHeight = -0.5f; 
    public float maxHeight = 0.5f;  
    public float moveSpeed = 0.2f;  

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);

        
        StartCoroutine(MoveUpAndDownRandomly());
    }

    IEnumerator MoveUpAndDownRandomly()
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = startPosition;

        while (true) 
        {
           
            if (transform.position == targetPosition)
            {
                float randomHeight = Random.Range(minHeight, maxHeight);
                targetPosition = new Vector3(startPosition.x, startPosition.y + randomHeight, startPosition.z);
            }

            
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            yield return null; 
        }
    }
}