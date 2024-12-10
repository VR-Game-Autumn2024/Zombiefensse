using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;

public class CloneZombie : MonoBehaviour
{
    public GameObject zombieClone;           // Prefab of the zombie to spawn
    public float delayTime = 120f;           // Time between zombie waves
    public int maxZombiesPerWave = 10;       // Number of zombies per wave
    public int maxTotalZombies = 50;         // Total number of zombies allowed to spawn

    private int currentZombies = 0;          // Current number of zombies spawned
    private bool canSpawn = true;            // Controls whether zombies can be spawned
    private int waveCount = 0;               // Keeps track of the wave number
    private int maxWave = 4;                 // Maximum number of waves

    public TextMeshProUGUI timerZombie;      // UI element to show timer
    public TextMeshProUGUI waveZombieCounter;       // UI element to show wave 

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
        int minutes = (int)(delayTime / 60);
        int seconds = (int)(delayTime % 60);
        timerZombie.text = "TEMPS À LA PROCHAINE VAGUE: " + $"{minutes:00}:{seconds:00}";

        //Update the wave counter on computer screen
        waveZombieCounter.text = "Vague: " + waveCount.ToString();

        // Check the wave limit and change to sucess scene
        if (waveCount >= maxWave)
        {
            canSpawn = false;
            SceneChangeFunction();
        }
    }

    // Function to spawn a wave of zombies
    void SpawnZombieWave()
    {
        int zombiesToSpawn = Mathf.Min(maxZombiesPerWave, maxTotalZombies - currentZombies);

        for (int i = 0; i < zombiesToSpawn; i++)
        {
            //float range
            float randomX = UnityEngine.Random.Range(405, 410);
            float randomZ = UnityEngine.Random.Range(570, 580);

            // Random position for the zombie
            Vector3 spawnPosition = new Vector3(randomX, 0.12f, randomZ);

            // Instantiate the zombie at the chosen position
            Instantiate(zombieClone, spawnPosition, Quaternion.identity);

            // Increment the count of spawned zombies
            currentZombies++;
        }

        // Optionally, log the wave number
        Debug.Log("Wave " + waveCount + " spawned " + zombiesToSpawn + " zombies.");

        //increase zombie for next wave: 50% more zombies each wave. Cap at 50max
        maxZombiesPerWave = Mathf.Min(Mathf.CeilToInt(maxZombiesPerWave * 1.25f), 50);
    }

    void SceneChangeFunction()
    {
        // Change to sucess scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("SceneSucess");
    }
}