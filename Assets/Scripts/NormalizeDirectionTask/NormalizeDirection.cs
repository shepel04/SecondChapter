using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace NormalizeDirectionTask
{
    public class NormalizeDirection : MonoBehaviour
    {
        public Vector3 Direction;  
        public float Speed = 5.0f;

        void Start()
        {
            Direction = Direction.normalized;
        }

        void Update()
        {
            transform.position += Direction * Speed * Time.deltaTime;
        }
    }
}


