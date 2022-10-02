using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] Transform transformToMoveTo;
    [SerializeField] float movementSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        transformToMoveTo = FindObjectOfType<THelperCell>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsTarget(transformToMoveTo);
    }

    void moveTowardsTarget(Transform target) {
        // Move our position a step closer to the target.
        var step = movementSpeed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the cylinder.
            // target.position *= -1.0f;
        }
    }
}

