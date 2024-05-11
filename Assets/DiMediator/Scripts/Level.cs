using System;
using UnityEngine;

namespace DiMediator
{
    public class Level
    {
        public event Action Defeat;

        public void Start() => 
            Debug.Log("StartLevel");

        public void Restart() => 
            Start();

        public void OnDefeat() => 
            Defeat?.Invoke();
    }
}