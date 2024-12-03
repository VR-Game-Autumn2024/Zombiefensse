using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public OVRInput.RawButton boutonTire;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
