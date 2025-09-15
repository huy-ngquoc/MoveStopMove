#nullable enable

namespace Game;

using UnityEngine;

public abstract class CharacterController : MonoBehaviour
{
    // TODO: attack range and speed in here. Maybe?

    [Header("Character info")]

    [SerializeReference]
    [ResolveComponentFromSelf]
    private new Rigidbody rigidbody = null!;

    [SerializeReference]
    [ResolveComponentFromChildren]
    private Animator animator = null!;

    public Rigidbody Rigidbody => this.rigidbody;

    public Animator Animator => this.animator;

    public abstract CharacterStateMachine CharacterStateMachine { get; }

    protected void Awake()
    {
        this.OnCharacterControllerAwake();
    }

    protected virtual void OnCharacterControllerAwake()
    {
    }

    protected void OnDestroy()
    {
        this.OnCharacterControllerDestroy();
    }

    protected virtual void OnCharacterControllerDestroy()
    {
    }
}
