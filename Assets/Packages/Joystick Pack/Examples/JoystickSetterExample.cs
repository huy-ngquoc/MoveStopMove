#nullable enable

namespace JoystickPack
{
    using UnityEngine;
    using UnityEngine.UI;

    public sealed class JoystickSetterExample : MonoBehaviour
    {
        [SerializeField]
        private VariableJoystick variableJoystick = null!;

        [SerializeField]
        private Text valueText = null!;

        [SerializeField]
        private Image background = null!;

        [SerializeField]
        private Sprite[] axisSprites = null!;

        public void ModeChanged(int index)
        {
            switch (index)
            {
                case 0:
                    this.variableJoystick.SetMode(VariableJoystick.JoystickType.Fixed);
                    break;

                case 1:
                    this.variableJoystick.SetMode(VariableJoystick.JoystickType.Floating);
                    break;

                case 2:
                    this.variableJoystick.SetMode(VariableJoystick.JoystickType.Dynamic);
                    break;

                default:
                    break;
            }
        }

        public void AxisChanged(int index)
        {
            switch (index)
            {
                case 0:
                    this.variableJoystick.CurrentAxisOptions = Joystick.AxisOptions.Both;
                    this.background.sprite = this.axisSprites[index];
                    break;

                case 1:
                    this.variableJoystick.CurrentAxisOptions = Joystick.AxisOptions.Horizontal;
                    this.background.sprite = this.axisSprites[index];
                    break;

                case 2:
                    this.variableJoystick.CurrentAxisOptions = Joystick.AxisOptions.Vertical;
                    this.background.sprite = this.axisSprites[index];
                    break;

                default:
                    break;
            }
        }

        public void SnapX(bool value)
        {
            this.variableJoystick.SnapX = value;
        }

        public void SnapY(bool value)
        {
            this.variableJoystick.SnapY = value;
        }

        private void Update()
        {
            this.valueText.text = "Current Value: " + this.variableJoystick.Direction;
        }
    }
}
