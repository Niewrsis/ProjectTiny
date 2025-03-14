using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.KeySystem
{
    public class ZoneForKey : MonoBehaviour
    {
        public GameObject ToLower;
        private bool _isKey = false;
        private bool _isGotKey = false;
        private bool _isOpened = false;
        private void Start()
        {
            Key.IsKey += AfterGetKey;
        }

        private void Update()
        {
            if (_isGotKey) return;
            IsGotKey();
        }
        private void AfterGetKey()
        {
            _isKey = true;
        }
        private void IsGotKey()
        {
            if (!_isKey) return;
            _isGotKey = true;
            _isOpened = true;
            Debug.Log("Got Key");
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            if (_isOpened == false) return;
            Debug.Log("Opened");
            //TODO: Some logic after
            ToLower.transform.position = ToLower.transform.position - new Vector3(0, 6, 0); // shit code to lower the "ladder"
            // debloat it at some point
        }
    }
}