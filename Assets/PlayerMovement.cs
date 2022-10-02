
using UnityEngine;
using System.Collections;
 
public class PlayerMovement : MonoBehaviour {
   
    public Vector2 targetPosition;

    // Update is called once per frame

    private void Start()
    {
        this.targetPosition = transform.position;
    }

    void Update () {
 
        if(Input.GetKeyDown(KeyCode.Mouse0))
           {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
 
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 5);
    }
}
 