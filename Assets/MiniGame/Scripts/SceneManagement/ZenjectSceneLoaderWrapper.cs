﻿using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace MiniGame.Scripts.SceneManagement
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader) => 
            _zenjectSceneLoader = zenjectSceneLoader;

        public void Load(int sceneId, Action<DiContainer> action = null) => 
            _zenjectSceneLoader.LoadScene(sceneId, LoadSceneMode.Single, container => action?.Invoke(container));
    }
}