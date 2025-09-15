#nullable enable

namespace Game;

public sealed class EnemyDeadState : EnemyState
{
    public EnemyDeadState(EnemyStateMachine enemyStateMachine)
    {
        this.EnemyStateMachine = enemyStateMachine;
    }

    public override EnemyStateMachine EnemyStateMachine { get; }

    public override string AnimationName => "Idle";
}
