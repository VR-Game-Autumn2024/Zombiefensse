using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneZombie2 : MonoBehaviour


{
    public GameObject zombieClone;
    public float delayTime = 5f;

    private int maxZombies = 10;
    private int currentZombies = 0;

    private bool peutSpawn = true;


    // Start is called before the first frame update
    void Start()
    {
       

    }
    void Update()
    {
        if (!peutSpawn) return;

        delayTime -= Time.deltaTime;
        if (delayTime <= 0 && currentZombies < maxZombies)
        {
            Vector3 endroit1 = new Vector3(Random.Range(321, 330), 0.12f, Random.Range(605, 614));
            Instantiate(zombieClone, endroit1, Quaternion.identity);

            currentZombies++;
            delayTime = 5f;
        }
        if (currentZombies == maxZombies)
        {
            peutSpawn = false;
        }
    }


}
