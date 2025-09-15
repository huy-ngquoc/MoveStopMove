#nullable enable

namespace Game;

using Unity.VisualScripting;
using UnityDebug = UnityEngine.Debug;
using UnityDisallowMultipleComponent = UnityEngine.DisallowMultipleComponent;
using UnityMonoBehaviour = UnityEngine.MonoBehaviour;
using UnityObject = UnityEngine.Object;

[UnityDisallowMultipleComponent]
public abstract class SingletonMonoBehaviour<T> : UnityMonoBehaviour
    where T : SingletonMonoBehaviour<T>
{
    private static readonly object LockInstanceObj = new();

    private static T? instance = null;

    protected SingletonMonoBehaviour()
    {
        var newInstance = this.LocalInstance;
        var newInstanceTypeName = typeof(T).FullName;
        if (newInstance == null)
        {
            UnityDebug.LogWarning($"There has been an attempt of assigning null to the instance of {newInstanceTypeName}!");
            return;
        }

        lock (LockInstanceObj)
        {
            if (instance == null)
            {
                instance = newInstance;
                return;
            }

            if (instance == newInstance)
            {
                UnityDebug.Log($"The same instance of {newInstanceTypeName} has been assigned twice or more times!");
                return;
            }

            UnityDebug.Log($"There're two of more components of {newInstanceTypeName}! " +
                $"By continuing, the new components will be destroyed!");
            UnityObject.Destroy(newInstance);
        }
    }

    protected static T Instance
    {
        get
        {
            lock (LockInstanceObj)
            {
                if (!QuickLog.WarnIfAccessNull(instance))
                {
                    return instance;
                }

                instance = UnityObject.FindFirstObjectByType<T>();
                if (instance != null)
                {
                    return instance;
                }

                var singletonObject = new UnityObject
                {
                    name = typeof(T).Name,
                };
                instance = singletonObject.AddComponent<T>();

                return instance;
            }
        }
    }

    protected abstract T LocalInstance { get; }

    protected void Awake()
    {
        this.OnAwake();
    }

    protected virtual void OnAwake()
    {
    }
}
