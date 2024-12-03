using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneZombie2 : MonoBehaviour


{
    public GameObject zombieClone;
    public float delayTime = 5f;

    private int zombieCount = 0;
    private int maxZombies = 10;

    private bool peutSpawnZombie = true;


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (!peutSpawnZombie) return;


        delayTime -= Time.deltaTime;
        if (delayTime <= 0 && zombieCount < maxZombies)
        {
            Vector3 endroit1 = new Vector3(Random.Range(321, 330), 0.12f, Random.Range(605, 614));
            Instantiate(zombieClone, endroit1, Quaternion.identity);

            zombieCount++;
            delayTime = 5f;
        }
        if (zombieCount == maxZombies)
        {
            Debug.Log("TEST MAX ZOMBIE 2  COUNT REACHED");
            //STOP INSTANTIATING ZOMBIES
            peutSpawnZombie = false;
        }
    }


}
