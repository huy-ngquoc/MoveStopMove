#nullable enable

namespace JoystickPack
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        [SerializeField]
        private float handleRange = 1;

        [SerializeField]
        private float deadZone = 0;

        [SerializeField]
        private AxisOptions currentAxisOptions = AxisOptions.Both;

        [SerializeField]
        private bool snapX = false;

        [SerializeField]
        private bool snapY = false;

        [SerializeField]
        private RectTransform background = null!;

        [SerializeField]
        private RectTransform handle = null!;

        private RectTransform baseRect = null!;

        private Canvas canvas = null!;

        private Camera? cam = null;

        private Vector2 input = Vector2.zero;

        public enum AxisOptions
        {
            Both,
            Horizontal,
            Vertical,
        }

        public float Horizontal => this.snapX ? this.SnapFloat(this.input.x, AxisOptions.Horizontal) : this.input.x;

        public float Vertical => this.snapY ? this.SnapFloat(this.input.y, AxisOptions.Vertical) : this.input.y;

        public Vector2 Direction => new(this.Horizontal, this.Vertical);

        public float HandleRange
        {
            get { return this.handleRange; }
            set { this.handleRange = Mathf.Abs(value); }
        }

        public float DeadZone
        {
            get { return this.deadZone; }
            set { this.deadZone = Mathf.Abs(value); }
        }

        public AxisOptions CurrentAxisOptions
        {
            get { return this.currentAxisOptions; }
            set { this.currentAxisOptions = value; }
        }

        public bool SnapX
        {
            get { return this.snapX; }
            set { this.snapX = value; }
        }

        public bool SnapY
        {
            get { return this.snapY; }
            set { this.snapY = value; }
        }

        protected RectTransform Background => this.background;

        public void OnPointerUp(PointerEventData eventData)
        {
            this.BeforeJoystickOnPointerUp(eventData);

            this.input = Vector2.zero;
            this.handle.anchoredPosition = Vector2.zero;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            this.BeforeJoystickOnPointerDown(eventData);

            this.OnDrag(eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.cam = null;
            if (this.canvas.renderMode == RenderMode.ScreenSpaceCamera)
            {
                this.cam = this.canvas.worldCamera;
            }

            Vector2 position = RectTransformUtility.WorldToScreenPoint(this.cam, this.background.position);
            Vector2 radius = this.background.sizeDelta / 2;
            this.input = (eventData.position - position) / (radius * this.canvas.scaleFactor);
            this.FormatInput();
            this.HandleInput(this.input.magnitude, this.input.normalized, radius, this.cam);
            this.handle.anchoredPosition = this.input * radius * this.handleRange;
        }

        protected Vector2 ScreenPointToAnchoredPosition(Vector2 screenPosition)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(this.baseRect, screenPosition, this.cam, out var localPoint))
            {
                Vector2 pivotOffset = this.baseRect.pivot * this.baseRect.sizeDelta;
                return localPoint - (this.background.anchorMax * this.baseRect.sizeDelta) + pivotOffset;
            }
            return Vector2.zero;
        }

        protected void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera? cam)
        {
            this.BeforeJoystickHandleInput(magnitude, normalised, radius, cam);

            if (magnitude > this.deadZone)
            {
                if (magnitude > 1)
                {
                    this.input = normalised;
                }
            }
            else
            {
                this.input = Vector2.zero;
            }
        }

        protected virtual void BeforeJoystickOnPointerUp(PointerEventData eventData)
        {
        }

        protected virtual void BeforeJoystickOnPointerDown(PointerEventData eventData)
        {
        }

        protected virtual void BeforeJoystickHandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera? cam)
        {
        }

        protected void Start()
        {
            this.baseRect = this.GetComponent<RectTransform>();
            this.canvas = this.GetComponentInParent<Canvas>();
            if (this.canvas == null)
            {
                Debug.LogError("The Joystick is not placed inside a canvas");
            }

            var center = new Vector2(0.5f, 0.5f);
            this.background.pivot = center;
            this.handle.anchorMin = center;
            this.handle.anchorMax = center;
            this.handle.pivot = center;
            this.handle.anchoredPosition = Vector2.zero;

            this.OnJoystickStart();
        }

        protected virtual void OnJoystickStart()
        {
        }

        private void FormatInput()
        {
            switch (this.currentAxisOptions)
            {
                case AxisOptions.Horizontal:
                    this.input = new Vector2(this.input.x, 0);
                    break;

                case AxisOptions.Vertical:
                    this.input = new Vector2(0, this.input.y);
                    break;

                default:
                    break;
            }
        }

        private float SnapFloat(float value, AxisOptions snapAxis)
        {
            if (Mathf.Abs(value) < Mathf.Epsilon)
            {
                return value;
            }

            var valueSign = Mathf.Sign(value);
            if (this.currentAxisOptions != AxisOptions.Both)
            {
                return valueSign;
            }

            var angle = Vector2.Angle(this.input, Vector2.up);
            return snapAxis switch
            {
                AxisOptions.Horizontal => ((angle >= 22.5F) && (angle <= 157.5F)) ? valueSign : 0,
                AxisOptions.Vertical => ((angle > 67.5F) && (angle < 112.5F)) ? 0 : valueSign,
                _ => value,
            };
        }
    }
}
