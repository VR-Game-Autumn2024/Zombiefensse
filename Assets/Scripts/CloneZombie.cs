using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneZombie : MonoBehaviour


{
    public GameObject zombieClone;
    public float delayTime = 5f;




    // Start is called before the first frame update
    void Start()
    {
        Vector3 endroit1 = new Vector3(Random.Range(405, 410), 0.12f, Random.Range(570, 580));

    }
    void Update()
    {
        delayTime -= Time.deltaTime;
        if (delayTime <= 0)
        {
            Vector3 endroit1 = new Vector3(Random.Range(405, 410), 0.12f, Random.Range(570, 580));
            Instantiate(zombieClone, endroit1, Quaternion.identity);
            delayTime = 5f;
        }
    }


}