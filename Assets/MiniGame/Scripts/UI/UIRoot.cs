using System;
using MiniGame.Scripts.Gameplay.Conditions;
using UnityEngine;
using UnityEngine.UI;

namespace MiniGame.Scripts.UI
{
    public class UIRoot : MonoBehaviour
    {
        [SerializeField] private Button _allButton;
        [SerializeField] private Button _greenButton;
        [SerializeField] private Button _redButton;
        [SerializeField] private Button _whiteButton;

        private SelectedCondition _selectedCondition;
        private MiniGame _miniGame;

        public void Construct(SelectedCondition condition, MiniGame game)
        {
            _selectedCondition = condition;
            _miniGame = game;
        }
        
        private void OnEnable()
        { 
            _allButton.onClick.AddListener(OnAllButtonClicked);
            _greenButton.onClick.AddListener(OnGreenButtonClicked);
            _redButton.onClick.AddListener(OnRedButtonClicked);
            _whiteButton.onClick.AddListener(OnWhiteButtonClicked);
        }

        private void OnDisable()
        {
            _allButton.onClick.RemoveListener(OnAllButtonClicked);
            _greenButton.onClick.RemoveListener(OnGreenButtonClicked);
            _redButton.onClick.RemoveListener(OnRedButtonClicked);
            _whiteButton.onClick.RemoveListener(OnWhiteButtonClicked);
        }

        private void OnWhiteButtonClicked() => 
            StartGame(ConditionType.PickedWhite);

        private void OnRedButtonClicked() => 
            StartGame(ConditionType.PickedRed);

        private void OnGreenButtonClicked() => 
            StartGame(ConditionType.PickedGreen);

        private void OnAllButtonClicked() => 
            StartGame(ConditionType.PickedAll);

        private void StartGame(ConditionType type)
        {
            _selectedCondition.SwitchConditionTo(type);
            _miniGame.Start();
            Hide();
        }

        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);
    }
}