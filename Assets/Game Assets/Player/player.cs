using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController controller;
    public static float speed = 5.0f;
    private float gravity = 1;
    public static bool move = true;
    public static bool jump = true;
    private float yvelocity;

 
 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        Vector3 velocity = direction * speed;
        velocity.y = yvelocity; 
        
        if (move == true)
        {
            controller.Move(velocity * Time.deltaTime);
        }
        if (controller.isGrounded == false)
        {
            yvelocity = yvelocity - gravity;
        }

        
    }

}
