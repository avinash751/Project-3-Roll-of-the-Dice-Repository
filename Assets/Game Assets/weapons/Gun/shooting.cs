using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bullet;
    public static int ammo = 30;
    public Transform SpawnPoint;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ammo != 0)
        {
            ammo--;
           GameObject duplicate = Instantiate(bullet, SpawnPoint.transform.position, transform.rotation);
           duplicate.GetComponent<Rigidbody>().AddForce((SpawnPoint.transform.up * bulletSpeed));
        }
    }
}
