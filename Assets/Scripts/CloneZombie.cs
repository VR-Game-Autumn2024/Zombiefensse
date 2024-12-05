//using System.Collections;
//using System.Collections.Generic;
//using TMPro;
//using UnityEngine;

//============CODE CHATGPT============//

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CloneZombie : MonoBehaviour
{
    public GameObject zombieClone;           // Prefab of the zombie to spawn
    public float delayTime = 10f;           // Time between zombie waves
    public int maxZombiesPerWave = 10;       // Number of zombies per wave
    public int maxTotalZombies = 50;         // Total number of zombies allowed to spawn

    private int currentZombies = 0;          // Current number of zombies spawned
    private bool canSpawn = true;            // Controls whether zombies can be spawned
    private int waveCount = 0;               // Keeps track of the wave number

    public TextMeshProUGUI timerZombie;      // UI element to show timer

    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (!canSpawn) return;  // Don't spawn if we can't

        delayTime -= Time.deltaTime;  // Reduce delay time

        // If the delay time has passed and we haven't reached the max total zombies
        if (delayTime <= 0 && currentZombies < maxTotalZombies)
        {
            SpawnZombieWave();  // Spawn a wave of zombies
            waveCount++;        // Increment the wave counter
            delayTime = 120f;    // Reset the delay time for the next wave
        }

        // If all zombies have been spawned, stop spawning
        if (currentZombies >= maxTotalZombies)
        {
            canSpawn = false;
        }

        // Update the timer on the screen
        timerZombie.text = Mathf.Ceil(delayTime).ToString() + "s";
    }

    // Function to spawn a wave of zombies
    void SpawnZombieWave()
    {
        int zombiesToSpawn = Mathf.Min(maxZombiesPerWave, maxTotalZombies - currentZombies);

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            // Random position for the zombie
            Vector3 spawnPosition = new Vector3(Random.Range(405, 410), 0.12f, Random.Range(570, 580));

            // Instantiate the zombie at the chosen position
            Instantiate(zombieClone, spawnPosition, Quaternion.identity);

            // Increment the count of spawned zombies
            currentZombies++;
        }

        // Optionally, log the wave number
        Debug.Log("Wave " + waveCount + " spawned " + zombiesToSpawn + " zombies.");
    }
}
















//public class CloneZombie : MonoBehaviour


//{
//    public GameObject zombieClone;
//    public float delayTime = 120f;

//    private int maxZombies = 10;
//    private int currentZombies = 0;

//    private bool peutSpawn = true;

//    public TextMeshProUGUI timerZombie;

//    // Start is called before the first frame update
//    void Start()
//    {

//    }
//    void Update()
//    {
//        if (!peutSpawn) return;

//        delayTime -= Time.deltaTime;
//        if (delayTime <= 0 && currentZombies < maxZombies)
//        {
//            Vector3 endroit1 = new Vector3(Random.Range(405, 410), 0.12f, Random.Range(570, 580));
//            Instantiate(zombieClone, endroit1, Quaternion.identity);

//            currentZombies++;
//            delayTime = 120f;
//        }
//        if (currentZombies == maxZombies)
//        {
//            peutSpawn = false;
//        }

//        //Timer sur l'ordi
//        timerZombie.text = delayTime.ToString("0") + "Secondes";
//    }


//}