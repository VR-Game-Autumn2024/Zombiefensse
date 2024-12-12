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
    //Temps restant avant de tirer une autre balle
    public float countdownTire;

    public AudioSource source;

    //Son lors d'un tire
    public AudioClip sonTire;

    // Start is called before the first frame update
    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdownTire -= Time.deltaTime;

        if (OVRInput.GetDown(boutonTire))
        {
            if (countdownTire <= 0.0f)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        source.PlayOneShot(sonTire);
        //Lorsqu'on tire la balle apparait et se dirige vers l'avant
        Instantiate(ballePrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(shootingPoint.forward * forceBalle);
        countdownTire = 2f;
    }
}
