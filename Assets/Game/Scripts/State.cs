#nullable enable

namespace Game;

using UnityEngine;

public abstract class State
{
    public float StateTimer { get; protected set; } = 0;

    public void Enter()
    {
        this.OnStateEnter();
    }

    public void Update()
    {
        var deltaTime = Time.deltaTime;
        if (this.StateTimer > deltaTime)
        {
            this.StateTimer -= deltaTime;
        }
        else
        {
            this.StateTimer = 0;
        }

        this.OnStateUpdate();
    }

    public void Exit()
    {
        this.OnStateExit();
    }

    protected virtual void OnStateEnter()
    {
    }

    protected virtual void OnStateUpdate()
    {
    }

    protected virtual void OnStateExit()
    {
    }
}
