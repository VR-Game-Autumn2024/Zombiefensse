using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonMarcheZombie : MonoBehaviour
{
    public AudioSource audioSource; // Reference de AudioSource
    public AudioClip[] sonsMarche; // Sons de marche
    public float stepInterval; // Temps entre pas
    private float stepTimer;

    // Update is called once per frame
    void Update()
    {
        //Il y a un son à chaque pas
        stepTimer -= Time.deltaTime;
        if (stepTimer <= 0f)
        {
            JouerSonDePas();
            stepTimer = stepInterval; // Reset le timer
        }
    }

    //Jouer le son de pas
    void JouerSonDePas()
    {
        if (sonsMarche.Length > 0)
        {
            int randomIndex = Random.Range(0, sonsMarche.Length);
            audioSource.PlayOneShot(sonsMarche[randomIndex]);

            //Jouer le son de pas avec des variations
            audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.5f);
            audioSource.volume = UnityEngine.Random.Range(0.1f, 0.2f);
        }
    }
}
