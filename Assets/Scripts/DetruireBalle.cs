using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetruireBalle : MonoBehaviour
{
    //Lorsque la balle est en collision avec un autre objet
    private void OnCollisionEnter(Collision other)
    {
        //D�truire la balle
        Destroy(gameObject);
    }
}
