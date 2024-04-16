using MiniGame.Scripts.Gameplay.Conditions;

namespace MiniGame.Scripts.UI
{
    public class GameUI
    {
        private readonly MiniGame _game;
        private readonly SelectedCondition _selectedCondition;
        private readonly UIFactory _factory;

        private UIRoot _uiRoot;
        
        public GameUI(MiniGame game, SelectedCondition selectedCondition, UIFactory factory)
        {
            _game = game;
            _selectedCondition = selectedCondition;
            _factory = factory;
        }

        public void Start()
        {
            _uiRoot = _factory.CreateUIRoot();
            _uiRoot.ConditionSelected += OnConditionSelected;
            _game.Completed += OnGameCompleted;
        }
        
        public void Stop()
        {
            _uiRoot.ConditionSelected -= OnConditionSelected;
            _uiRoot.Hide();

            _game.Stop();
            _game.Completed -= OnGameCompleted;
        }
        
        private void OnConditionSelected(ConditionType type)
        {
            _selectedCondition.SwitchConditionTo(type);
            _uiRoot.Hide();
            _game.Start();
        }

        private void OnGameCompleted()
        {
            _game.Stop();
            _uiRoot.Show();
        }
    }
}