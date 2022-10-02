using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THelperCell : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die() {
        Debug.Log("t helper dies");
        FindObjectOfType<LevelManager>().GameOver();
        // Destroy(this.gameObject);
    }
}
