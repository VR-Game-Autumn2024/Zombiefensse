using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    //Appuyer sur le trigger de la manette
    public OVRInput.RawButton boutonTire;


    //Prefab de la balle
    public GameObject ballePrefab;
    //Origine
    public Transform shootingPoint;
    //Force/vitesse de la balle
    public float forceBalle = 20f;

    public AudioSource source;
    public AudioClip shootingAudioClip;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(boutonTire))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log("Pew Pew");

        Instantiate(ballePrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(shootingPoint.forward * forceBalle);

        /*RigidBody rb = ballePrefab.GetComponent<RigidBody>();

        /*if (rb is null)
        {
            rb.AddForce(shootingpoint.forward = forceBalle, ForceMode.Inpulse);
        }*/
    }
}
