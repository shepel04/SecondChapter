using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Transform
{
    public class CubeRotation : MonoBehaviour
    {
        public float Rpm = 60f;

        void Update()
        {
            float anglePerSecond = (Rpm / 60f) * 360f;
            float angleThisFrame = anglePerSecond * Time.deltaTime;

            // Euler angles
            // transform.Rotate(Vector3.up, angleThisFrame);

            // Quaternions
            Quaternion rotation = Quaternion.Euler(0, angleThisFrame, 0);
            transform.rotation = transform.rotation * rotation;
        }
    }
}


