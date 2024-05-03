using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [field: SerializeField, Range(0, 5)] public float WalkingSpeed { get; private set; }
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 20)] public float FastSpeed { get; private set; }
}
