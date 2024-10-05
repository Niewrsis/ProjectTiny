using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game.GameTimer
{

    public class GameTimer : MonoBehaviour
    {
        private float _time;

        public bool announceFinish;
        [field: SerializeField] public MonoBehaviour CommandingScript { get; private set; }
        public string scriptName;

        public float CurrentTime => _time;
        public bool StopWhenReached = false;
        public float TargetTime = 0;
        void Update()
        {
            if (!StopWhenReached)
            {
                _time += Time.deltaTime;
                if (_time > TargetTime) 
                {
                    StopWhenReached = true;
                    if (announceFinish)
                    {
                        CommandingScript.Invoke(scriptName, 0);
                        StopWhenReached = true;
                    }
                }
            }
        }

    }

}