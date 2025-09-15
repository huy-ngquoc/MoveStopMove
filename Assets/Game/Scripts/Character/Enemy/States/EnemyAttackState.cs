#nullable enable

namespace Game;

public sealed class EnemyAttackState : EnemyState
{
    public EnemyAttackState(EnemyStateMachine enemyStateMachine)
    {
        this.EnemyStateMachine = enemyStateMachine;
    }

    public override EnemyStateMachine EnemyStateMachine { get; }

    public override string AnimationName => "Attack";
}
