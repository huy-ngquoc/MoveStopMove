#nullable enable

namespace JoystickPack
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public sealed class VariableJoystick : Joystick
    {
        [SerializeField]
        private float moveThreshold = 1;

        [SerializeField]
        private JoystickType joystickType = JoystickType.Fixed;

        private Vector2 fixedPosition = Vector2.zero;

        public enum JoystickType
        {
            Fixed,
            Floating,
            Dynamic,
        }

        public float MoveThreshold
        {
            get { return this.moveThreshold; }
            set { this.moveThreshold = Mathf.Abs(value); }
        }

        public void SetMode(JoystickType joystickType)
        {
            this.joystickType = joystickType;
            if (joystickType == JoystickType.Fixed)
            {
                this.Background.anchoredPosition = this.fixedPosition;
                this.Background.gameObject.SetActive(true);
            }
            else
            {
                this.Background.gameObject.SetActive(false);
            }
        }

        protected override void OnJoystickStart()
        {
            this.fixedPosition = this.Background.anchoredPosition;
            this.SetMode(this.joystickType);
        }

        protected override void BeforeJoystickOnPointerUp(PointerEventData eventData)
        {
            if (this.joystickType != JoystickType.Fixed)
            {
                this.Background.gameObject.SetActive(false);
            }
        }

        protected override void BeforeJoystickOnPointerDown(PointerEventData eventData)
        {
            if (this.joystickType != JoystickType.Fixed)
            {
                this.Background.anchoredPosition = this.ScreenPointToAnchoredPosition(eventData.position);
                this.Background.gameObject.SetActive(true);
            }
        }

        protected override void BeforeJoystickHandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera? cam)
        {
            if ((this.joystickType == JoystickType.Dynamic) && (magnitude > this.moveThreshold))
            {
                Vector2 difference = normalised * (magnitude - this.moveThreshold) * radius;
                this.Background.anchoredPosition += difference;
            }
        }
    }
}
