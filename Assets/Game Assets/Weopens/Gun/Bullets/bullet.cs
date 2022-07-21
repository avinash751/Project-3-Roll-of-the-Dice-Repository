using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody rb;
    public int speed = 20;
    public int bulletdamage = 2;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * speed * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        IDamagable enemy = collision.gameObject.GetComponent<IDamagable>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletdamage);
            Destroy(gameObject);
        }

    }
}
