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

    public GameObject muzzleFlash;
    public Transform muzzleFlashPosition;
    public GameObject gunLight;

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
                Vibrate();
            }
        }
    }

    public void Shoot()
    {
        source.PlayOneShot(sonTire);
        //Lorsqu'on tire la balle apparait et se dirige vers l'avant
        Instantiate(ballePrefab, shootingPoint.position, shootingPoint.rotation * Quaternion.Euler(90f, 0f, 0f)).GetComponent<Rigidbody>().AddForce(shootingPoint.forward * forceBalle);
        countdownTire = 0.5f;

        GameObject Flash = Instantiate(muzzleFlash, muzzleFlashPosition);
        Destroy(Flash, 0.1f);

        GameObject light = Instantiate(gunLight, muzzleFlashPosition);
        Destroy(light, 0.1f);
    }

    public void Vibrate()
    {
        /*//Vibration de la manette 
        Invoke("CommencerVibrer", 0.05f);

        //Arret de la vibration
        Invoke("ArreterVibrer", 0.35f);*/

        OVRInput.Controller controller = OVRInput.GetActiveController();

        StartCoroutine(VibrationRoutine(controller));

    }

    /*public void CommencerVibrer()
    {
        //Vibrer avec une intensité de 1
        OVRInput.SetControllerVibration(1f, 1f, OVRInput.Controller.RTouch);
        //debug test 
        Debug.Log("Vibration");
    }
    public void ArreterVibrer()
    {
        //Réduction d'intensité après 0.7s
        OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
        Debug.Log("Arret Vibration");
    }*/

    private IEnumerator VibrationRoutine(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(1f, 1f, controller);

        yield return new WaitForSeconds(0.35f);

        OVRInput.SetControllerVibration(0f, 0f, controller);
    }

    }

