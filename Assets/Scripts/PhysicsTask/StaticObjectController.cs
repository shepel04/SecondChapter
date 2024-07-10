using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PhysicsTask
{
    public class StaticObjectController : MonoBehaviour
    {
        public TMP_Text PassText;

        private int _passCount = 0;


        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name == "Ball")
            {
                _passCount++;
                UpdatePassText();
            }
        }
        
        void UpdatePassText()
        {
            PassText.text = "Passings: " + _passCount;
        }
    }
}
