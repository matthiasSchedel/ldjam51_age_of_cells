using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] Transform transformToMoveTo;
    [SerializeField] float movementSpeed = 2.0f;
    [SerializeField] float rotationSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        transformToMoveTo = FindObjectOfType<THelperCell>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        moveTowardsTarget(transformToMoveTo);
        RotateTowardsTo(transformToMoveTo);

    }

    void RotateTowardsTo(Transform target) {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //// Determine which direction to rotate towards
        //Vector3 targetDirection = target.position - transform.position;

        //// The step size is equal to speed times frame time.
        //float singleStep = rotationSpeed * Time.deltaTime;

        //// Rotate the forward vector towards the target direction by one step
        //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

        //// Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);

        //// Calculate a rotation a step closer to the target and applies rotation to this object
        //transform.rotation = Quaternion.LookRotation(newDirection);
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

