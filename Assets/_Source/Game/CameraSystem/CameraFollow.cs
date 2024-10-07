using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float speed;

        private void Update()
        {
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -20), target.position, speed * Time.deltaTime);
        }
    }
}