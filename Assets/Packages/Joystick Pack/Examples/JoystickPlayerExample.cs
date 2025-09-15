#nullable enable

namespace JoystickPack
{
    using UnityEngine;

    internal sealed class JoystickPlayerExample : MonoBehaviour
    {
        [SerializeField]
        private float speed = 0;

        [SerializeField]
        private VariableJoystick variableJoystick = null!;

        [SerializeField]
        private new Rigidbody rigidbody = null!;

        private void FixedUpdate()
        {
            var direction = (Vector3.forward * this.variableJoystick.Vertical)
                        + (Vector3.right * this.variableJoystick.Horizontal);
            this.rigidbody.AddForce(this.speed * Time.fixedDeltaTime * direction, ForceMode.VelocityChange);
        }
    }
}
