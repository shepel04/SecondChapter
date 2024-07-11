using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace RaycastTask
{
    public class RaycastController : MonoBehaviour
    {
        public Camera MainCamera;
        public float RayDistance = 100f;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, RayDistance))
                {
                    Debug.Log("Hit object: " + hit.collider.name);
                    Debug.DrawLine(ray.origin, hit.point, Color.red, 3f);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * RayDistance, Color.green, 3f);
                }
            }
        }
    }
}


