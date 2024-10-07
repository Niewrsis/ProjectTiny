using Game.PlayerSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.WaterSystem {

    [RequireComponent(typeof(BoxCollider2D))]
    public class Water : MonoBehaviour
    {
        private float _currentWaterLevel;
        public float TargetYLevel;
        public float TimeToRise = 60f; // Default time to rise
        private float waterRiseSpeed;

        public GameObject DeathScreen;

        [Range(0, 5)] public float waveAmplitude = 0.1f;
        [Range(0, 5)] public float waveSpeed = 1.0f;
        [Range(0, 5)] public float waveFrequency = 1.0f;

        private void Start()
        {
            _currentWaterLevel = transform.position.y;
        }

        private void LateUpdate()
        {
            waterRiseSpeed = (TargetYLevel - _currentWaterLevel) / TimeToRise;

            Rise();

            Wave();
        }

        void Rise()
        {
            _currentWaterLevel = Mathf.MoveTowards(_currentWaterLevel, TargetYLevel, waterRiseSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, _currentWaterLevel, transform.position.z);
        }

        void Wave()
        {
            // Only adjust the y-position for a simple wave effect
            float waveYOffset = waveAmplitude * Mathf.Sin(Time.time * waveSpeed + transform.position.x * waveFrequency);
            transform.position = new Vector3(transform.position.x, _currentWaterLevel + waveYOffset, transform.position.z);
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<Player>().IsDead = true;
                if (DeathScreen != null)
                {
                    DeathScreen.SetActive(true);
                } else
                {
                    Debug.LogError("Why the uck did you not set a death screen plaeese fucking od smth bout it");
                }
            }
        }  
    }

}