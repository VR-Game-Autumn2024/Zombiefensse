using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructParticles : MonoBehaviour
{
    public float tempsRestant;

    void Update()
    {
        //Temps restant avant que les particules soient d�truites
        tempsRestant -= Time.deltaTime;

        //D�truire particules
        if (tempsRestant <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
