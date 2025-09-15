#nullable enable

namespace JoystickPack
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public sealed class DynamicJoystick : Joystick
    {
        [SerializeField]
        private float moveThreshold = 1;

        public float MoveThreshold
        {
            get { return this.moveThreshold; }
            set { this.moveThreshold = Mathf.Abs(value); }
        }

        protected override void OnJoystickStart()
        {
            this.Background.gameObject.SetActive(false);
        }

        protected override void BeforeJoystickOnPointerDown(PointerEventData eventData)
        {
            this.Background.anchoredPosition = this.ScreenPointToAnchoredPosition(eventData.position);
            this.Background.gameObject.SetActive(true);
        }

        protected override void BeforeJoystickOnPointerUp(PointerEventData eventData)
        {
            this.Background.gameObject.SetActive(false);
        }

        protected override void BeforeJoystickHandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera? cam)
        {
            if (magnitude > this.moveThreshold)
            {
                var difference = normalised * (magnitude - this.moveThreshold) * radius;
                this.Background.anchoredPosition += difference;
            }
        }
    }
}
