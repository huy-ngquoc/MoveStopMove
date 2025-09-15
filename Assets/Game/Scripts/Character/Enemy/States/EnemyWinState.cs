#nullable enable

namespace Game;

public sealed class EnemyWinState : EnemyState
{
    public EnemyWinState(EnemyStateMachine enemyStateMachine)
    {
        this.EnemyStateMachine = enemyStateMachine;
    }

    public override EnemyStateMachine EnemyStateMachine { get; }

    public override string AnimationName => "Idle";
}
