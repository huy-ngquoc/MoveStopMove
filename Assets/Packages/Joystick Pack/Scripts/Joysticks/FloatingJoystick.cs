#nullable enable

namespace JoystickPack
{
    using UnityEngine.EventSystems;

    public sealed class FloatingJoystick : Joystick
    {
        protected override void OnJoystickStart()
        {
            this.Background.gameObject.SetActive(false);
        }

        protected override void BeforeJoystickOnPointerUp(PointerEventData eventData)
        {
            this.Background.gameObject.SetActive(false);
        }

        protected override void BeforeJoystickOnPointerDown(PointerEventData eventData)
        {
            this.Background.anchoredPosition = this.ScreenPointToAnchoredPosition(eventData.position);
            this.Background.gameObject.SetActive(true);
        }
    }
}
