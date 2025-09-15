#nullable enable

namespace Game;

public sealed class EnemyIdleState : EnemyState
{
    public EnemyIdleState(EnemyStateMachine enemyStateMachine)
    {
        this.EnemyStateMachine = enemyStateMachine;
    }

    public override EnemyStateMachine EnemyStateMachine { get; }

    public override string AnimationName => "Idle";
}
