using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private CharacterController controller;
    public static float speed = 5.0f;
    public static bool move = true;
    public static bool jump = true;

 
 
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

        if (move == true)
        {
            controller.Move(velocity * Time.deltaTime);
        }
        
    }

}
