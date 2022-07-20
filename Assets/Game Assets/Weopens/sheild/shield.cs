using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public static int health = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if (enemy != null)
        {
            health = health - 2;
        }
        if (health >= 0)
        {
            gameObject.SetActive(false);
        }
         
    }
}
