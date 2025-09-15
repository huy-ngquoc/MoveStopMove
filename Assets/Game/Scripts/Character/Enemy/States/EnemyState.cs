#nullable enable

namespace Game;

public abstract class EnemyState : CharacterState
{
    public EnemyController EnemyController => this.EnemyStateMachine.EnemyController;

    public abstract EnemyStateMachine EnemyStateMachine { get; }

    public sealed override CharacterStateMachine CharacterStateMachine => this.EnemyStateMachine;

    protected sealed override void OnCharacterStateEnter()
    {
        this.OnEnemyStateEnter();
    }

    protected sealed override void OnCharacterStateUpdate()
    {
        this.OnEnemyStateUpdate();
    }

    protected sealed override void OnCharacterStateExit()
    {
        this.OnEnemyStateExit();
    }

    protected virtual void OnEnemyStateEnter()
    {
    }

    protected virtual void OnEnemyStateUpdate()
    {
    }

    protected virtual void OnEnemyStateExit()
    {
    }
}
