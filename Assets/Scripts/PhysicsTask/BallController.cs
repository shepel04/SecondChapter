using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PhysicsTask
{
    public class BallController : MonoBehaviour
    {
        public TMP_Text BounceText;
        public TMP_Text DistanceText;
        
        private Rigidbody2D _rb;
        private int _bounceCount = 0;
        private GameObject _floor;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _floor = GameObject.FindWithTag("Floor");
            UpdateBounceText();
        }

        void Update()
        {
            UpdateDistanceText();
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                _bounceCount++;
                UpdateBounceText();
            }
        }

        void UpdateBounceText()
        {
            BounceText.text = "Bounces: " + _bounceCount;
        }

        void UpdateDistanceText()
        { 
            float distance = transform.position.y - _floor.transform.position.y - _floor.transform.lossyScale.y / 2;
            DistanceText.text = "Distance to Floor: " + distance.ToString("F2") + " units";
        }
    }
}


