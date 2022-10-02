using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour
{
    [SerializeField] float MaxHitPoints = 100;
    [SerializeField] float currentHitPoints;
    float starterHealthbarScale;
    Transform healthBarTransform;


    // Start is called before the first frame update
    void Start()
    {
        healthBarTransform = this.transform.Find("health_bar");
        currentHitPoints = MaxHitPoints;
        starterHealthbarScale = healthBarTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hit by bullet - collision" + col.gameObject.tag);
        if (this.GetComponent<THelperCell>() && col.gameObject.tag == "Enemy")
        {

            float damage = col.gameObject.GetComponent<Enemy>().damage;
            GetHit(damage);
        }
    }

    void GetHit(float damage) {
        Debug.Log("Damage " + this.gameObject.tag);
        currentHitPoints -= damage;
        currentHitPoints = Mathf.Max(currentHitPoints, 0);
        if (currentHitPoints <= 0)
        {
            if (this.GetComponent<VirusEnemy>())
            {
                this.GetComponent<VirusEnemy>().SendMessage("die");
            }
            else if (this.GetComponent<THelperCell>())
            {
                this.GetComponent<THelperCell>().SendMessage("die");
            }
            else
            {
                Debug.Log("die not implemented");
            }
        }
        UpdateHealthBar();
        }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (this.gameObject.tag == "Player" && col.gameObject.tag == "Enemy")
        {

            float damage = col.GetComponent<Enemy>().damage;
            GetHit(damage);
            // It is object tagged with TagB
            //  Debug.Log("hit by bullet hit by bullet - trigger");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Debug.Log("hit by bullet " + this.gameObject.tag);
        Debug.Log("hit by bullet " + col.gameObject.tag + " in " + this.gameObject.tag);
        if (!this.GetComponent<THelperCell>() && col.GetComponent<Collider2D>().tag == "Bullet")
        {
            float damage = col.GetComponent<Bullet>().damage;
            GetHit(damage);
            // It is object tagged with TagB
            //  Debug.Log("hit by bullet hit by bullet - trigger");
            col.GetComponent<Bullet>().destroy();
        } else if (this.gameObject.tag == "Player" && col.gameObject.tag == "Enemy") {
            
            float damage = col.GetComponent<Enemy>().damage;
            GetHit(damage);
            // It is object tagged with TagB
            //  Debug.Log("hit by bullet hit by bullet - trigger");
        }
       

    }

    void UpdateHealthBar() {
        healthBarTransform.localScale = new Vector3((currentHitPoints / MaxHitPoints) * starterHealthbarScale, .4f, 1);

    }
}
