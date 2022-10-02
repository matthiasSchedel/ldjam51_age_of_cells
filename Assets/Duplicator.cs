using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicator : MonoBehaviour
{
    [SerializeField] int duplicateEveryXSeconds = 10;
    [SerializeField] bool duplicationEnabled = false;
    [SerializeField] Vector3 spawningOffest = new Vector3(0, 1, 0);
    [SerializeField] GameObject virusPrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        if (duplicationEnabled) {
            InvokeRepeating("LaunchProjectile", 2.0f, duplicateEveryXSeconds);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectile()
    {
        GameObject instance = Instantiate(virusPrefab);
        instance.transform.position *= -1.0f;

        // instance.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 5;
    }
}
