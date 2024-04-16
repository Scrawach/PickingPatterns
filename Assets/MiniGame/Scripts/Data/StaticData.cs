using System.Collections.Generic;
using System.Linq;
using MiniGame.Scripts.Gameplay.Balls;
using MiniGame.Scripts.Gameplay.Balls.View;
using UnityEngine;

namespace MiniGame.Scripts.Data
{
    public class StaticData
    {
        private readonly SettingsAsset _settings;
        private BallMaterial[] _materials;

        public StaticData(SettingsAsset settings) => 
            _settings = settings;

        public void Load()
        {
            var settings = _settings.Load();
            _materials = settings.Materials;
        }

        public IReadOnlyList<BallMaterial> AllMaterials() => 
            _materials;

        public Material GetMaterialByType(BallType type) => 
            _materials.First(material => material.Type == type).Material;
    }
}