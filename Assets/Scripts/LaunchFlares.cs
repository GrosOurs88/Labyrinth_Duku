using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchFlares : MonoBehaviour
{
    public GameObject flare;
    public Transform flareSpawnPoint;
    public float flareLaunchForce;
    public GameObject cam;

    void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            GameObject newFlare = Instantiate(flare, flareSpawnPoint.position, Quaternion.identity);
            newFlare.GetComponent<Rigidbody>().AddForce(cam.transform.forward * flareLaunchForce, ForceMode.Impulse);
        }
    }
}
