#nullable enable

namespace Game
{
    using JoystickPack;
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerInputHandler : MonoBehaviour
    {
        [SerializeReference]
        private Joystick? joystick = null;

        public Vector2 MoveInput => (this.joystick != null) ? this.joystick.Direction : Vector2.zero;
    }
}
