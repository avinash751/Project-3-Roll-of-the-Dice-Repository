using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraiming : MonoBehaviour
{
    Vector3 mouseWorldSpace;

    private void Update()
    {

        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = transform.position.z;
        mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        transform.LookAt(mouseWorldSpace, -Vector3.forward);
        transform.eulerAngles = new Vector3(0, -transform.eulerAngles.z - 90, 0); 


       /* Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point); // Look at the point
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        } */
           
    }   
  
}

