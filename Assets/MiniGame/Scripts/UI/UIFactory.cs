using MiniGame.Scripts.UI.Assets;
using MiniGame.Scripts.UI.View;
using UnityEngine;

namespace MiniGame.Scripts.UI
{
    public class UIFactory
    {
        private readonly MainMenuPanelAsset _mainMenuPanelAsset;
        private readonly VictoryPanelAsset _victoryPanelAsset;

        public UIFactory(MainMenuPanelAsset mainMenuPanelAsset, VictoryPanelAsset victoryPanelAsset)
        {
            _mainMenuPanelAsset = mainMenuPanelAsset;
            _victoryPanelAsset = victoryPanelAsset;
        }

        public MainMenuPanel CreateMainMenuPanel() => 
            _mainMenuPanelAsset.Instantiate(Vector3.zero, Quaternion.identity);

        public VictoryPanel CreateVictoryPanel() =>
            _victoryPanelAsset.Instantiate(Vector3.zero, Quaternion.identity);
    }
}