#nullable enable

namespace Game;

public abstract class CharacterStateMachine : StateMachine
{
    public abstract CharacterController CharacterController { get; }
}
