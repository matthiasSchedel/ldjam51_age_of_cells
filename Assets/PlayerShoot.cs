using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab = null;

    [SerializeField] private bool canShoot = true;

    [SerializeField] public Transform bulletParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     // on right mouse click call function shoot   
        if(canShoot && Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // instantiate bullet prefab
        // set bullet position to player position
        // set bullet rotation to player rotation
        // add this variable to your Script, this is where you drag your prefab in the inspector
        
       
 

        // Put this in your shoot function
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation, transform);
        bullet.transform.SetParent(bulletParent);
        // bullet.GetComponent<Bullet>().target = mousePosition
        bullet.SendMessage("StartShoot");
    }   
}
