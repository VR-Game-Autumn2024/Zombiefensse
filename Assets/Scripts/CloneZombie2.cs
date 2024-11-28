using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneZombie2 : MonoBehaviour

   
{ 
    public GameObject zombieClone;
    public float delayTime = 5f;




    // Start is called before the first frame update
    void Start()
    {
        Vector3 endroit1 = new Vector3(Random.Range(321, 330), 0.12f, Random.Range(605, 614));
    
    }
    void Update()
    {
        delayTime -= Time.deltaTime;
        if (delayTime <= 0)
        {
            Vector3 endroit1 = new Vector3(Random.Range(321, 330), 0.12f, Random.Range(605, 614));
            Instantiate(zombieClone, endroit1, Quaternion.identity);
            delayTime = 5f;
        }
    }


}
