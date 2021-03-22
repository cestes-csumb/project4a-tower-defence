using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
     public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
          if (Input.GetMouseButtonDown(0))
          {
               Raycast();
          }
    }

     void Raycast() {
          Ray ray = camera.ScreenPointToRay(Input.mousePosition);
          RaycastHit hit;
          if (Physics.Raycast(ray, out hit))
          {
               if (hit.collider.name.Equals("BigBadGuy") || hit.collider.name.Equals("SmallBadGuy")){
                    hit.collider.GetComponent<Enemy>().UpdateHealth();
                    Debug.Log(hit.collider.name + " Remaining Health " + hit.collider.GetComponent<Enemy>().health);
               }
          }
     }
}
