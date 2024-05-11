﻿using PureSpawner.Gameplay.Enemies;
using PureSpawner.Gameplay.Enemies.Services;
using PureSpawner.Infrastructure.Pausing;
using UnityEngine;
using Zenject;

namespace PureSpawner.Infrastructure.Installers
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _spawner;

        private PauseHandler _pauseHandler;

        [Inject]
        private void Construct(PauseHandler pauseHandler)
        {
            _pauseHandler = pauseHandler;
        }

        private void Awake()
        {
            _spawner.StartWork();
        }

        private void Update()
        {
            if(Input.GetKeyUp(KeyCode.Space))
                _pauseHandler.SetPause(true);

            if(Input.GetKeyUp(KeyCode.F))
                _pauseHandler.SetPause(false);
        }
    }
}