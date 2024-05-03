public class FastRunningState : GroundedState
{
    private readonly RunningStateConfig _config;

    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) 
        : base(stateSwitcher, data, character) =>
        _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();
        Data.Speed = _config.FastSpeed;
        View.StartFastRunning();
    }

    public override void Exit()
    {
        base.Exit();
        View.StopFastRunning();
    }
}