using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarcheJoueur : MonoBehaviour
{
    public AudioSource audioSource; // Reference de AudioSource
    public AudioClip[] sonsMarche; // Sons de marche
    public float stepInterval = 0.5f; // Temps entre pas
    private float stepTimer;

    private CharacterController characterController; // D�tection mouvement

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // V�rifier si le joueur se d�place
        if (characterController.velocity.magnitude > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                JouerSonDePas();
                stepTimer = stepInterval; // Reset le timer
            }
        }
        else
        {
            stepTimer = 0f; // Reset if not moving
        }
    }

    //Jouer le son de pas
    void JouerSonDePas()
    {
        if (sonsMarche.Length > 0)
        {
            int randomIndex = Random.Range(0, sonsMarche.Length);
            audioSource.PlayOneShot(sonsMarche[randomIndex]);
        }
    }
}
