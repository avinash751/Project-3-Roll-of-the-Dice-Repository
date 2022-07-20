using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon_manager : MonoBehaviour
{
    public GameObject pistol;
    public Transform meeple;
    public GameObject sheild;
    public Transform meeple2;
    public GameObject launcher;
    public Transform meeple3;
    public GameObject sword;
    public Transform meeple4;
    private int index = 0;
    private int cou;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            weapondeactive();
            weaponreset();
            index = Random.Range(0, 4);
            cou = index;
            gameObject.transform.GetChild(index).gameObject.SetActive(true);
            
        }
    }

    void weapondeactive()
    {
        gameObject.transform.GetChild(cou).gameObject.SetActive(false);
    }

    private void weaponreset()
    {
        shooting.ammo = 30;
        shield.health = 20;
    }
}
