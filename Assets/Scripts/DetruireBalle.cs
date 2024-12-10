using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetruireBalle : MonoBehaviour
{
    //Particules de la balle
    [SerializeField] GameObject particulesBalle;

    //Lorsque la balle est en collision avec un autre objet
    private void OnCollisionEnter(Collision other)
    {
        //Détruire la balle
        Destroy(gameObject);
        GameObject explosion = Instantiate(particulesBalle, transform.position, transform.rotation);
    }
}
