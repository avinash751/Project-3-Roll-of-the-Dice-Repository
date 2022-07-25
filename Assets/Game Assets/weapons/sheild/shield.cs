using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    [SerializeField]public static int health = 100;
    public bool collided;
    public float CollsionCheckRate;
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
        if (enemy != null && !collided)
        {
            collided = true;
            health = health - 1;
            if (health <= 0)
            {
                gameObject.SetActive(false);
            }
        } 
    }

    private void OnCollisionExit(Collision collision)
    {

        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if(enemy != null && collided)
        {
            Invoke(nameof(EnableCollsion),CollsionCheckRate);
        }
    }

    void EnableCollsion()
    {
        collided = false;
    }
}
