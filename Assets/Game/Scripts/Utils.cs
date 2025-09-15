#nullable enable

namespace Game;

using UnityEngine;
using UnityEngine.AI;

public static class Utils
{
    public static bool IsLayerInMask(GameObject obj, LayerMask mask)
    {
        return ((1 << obj.layer) & mask) != 0;
    }

    public static int ModPositive(int a, int b)
    {
        return ((a % b) + b) % b;
    }

    public static bool HasReachedDestination(NavMeshAgent agent, float tolerance)
    {
        if (agent.pathPending)
        {
            return false;
        }

        if (agent.remainingDistance > agent.stoppingDistance + tolerance)
        {
            return false;
        }

        if (agent.hasPath && agent.velocity.sqrMagnitude > 0.01f)
        {
            return false;
        }

        return true;
    }

    public static bool HasReachedDestination(NavMeshAgent agent)
    {
        return Utils.HasReachedDestination(agent, 0.1F);
    }
}
