using System.Collections;

using System.Collections.Generic;

using UnityEngine;
public class Bullet : MonoBehaviour 
{
    [SerializeField] public float speed = 20;
    private bool shoot = false;
    [SerializeField] public float damage = 10f;
    public Vector3 target;
    [SerializeField] float delay = 30f;

    private void Start()
    {
        Invoke("destroy", delay);
    }
    void Update() 
    {
        if (this.shoot) {
        transform.Translate((this.target * speed * Time.deltaTime));
        }
    }   

    public void StartShoot() {
        // this.target = target;
         var worldMousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        var direction = worldMousePosition - this.transform.position;
        direction.Normalize();
        this.target = direction;
        this.shoot = true;
    }

    public void destroy()
    {
        Debug.Log("bullet destroy");
        Destroy(this.gameObject);
    }
}