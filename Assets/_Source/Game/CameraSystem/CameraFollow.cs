using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.CameraSystem
{
    public class CameraFollow : MonoBehaviour
    {
        //Main character
        [SerializeField] private Transform target;
        //Camera speed
        [SerializeField] private float speed;

        private void Update()
        {
            //Transform position of camera
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, -10), target.position, speed * Time.deltaTime);
        }
    }
}