using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab = null;
    [SerializeField] private AudioClip m_shoot;
    [SerializeField] private AudioClip m_hit;
    [SerializeField] private AudioClip m_die;
    private AudioSource m_audioSource;

    [SerializeField] private bool canShoot = true;

    [SerializeField] public Transform bulletParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayerSoundShoot() {
        m_audioSource.clip = m_shoot;
        m_audioSource.Play();
    }

    public void PlayerSoundHit()
    {
        m_audioSource.clip = m_hit;
        m_audioSource.Play();
    }

    public void PlayerSoundDie()
    {
        m_audioSource.clip = m_die;
        m_audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
     // on right mouse click call function shoot   
        if(canShoot && Input.GetMouseButtonDown(1))
        {
            Shoot();
            PlayerSoundShoot();
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
