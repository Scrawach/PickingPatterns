using UnityEngine;
using Zenject;

namespace DiMediator.Installers
{
    public class MediatorInstaller : MonoInstaller
    {
        [SerializeField] private DefeatPanel _panelPrefab;
        
        public override void InstallBindings()
        {
            Container.Bind<Level>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle();
            
            Container.Bind<DefeatPanel>().FromComponentInNewPrefab(_panelPrefab).AsSingle();
            
            Container.BindInterfacesAndSelfTo<Player>().AsSingle().NonLazy();
        }
    }
}