using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoystickHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler,IDragHandler
{
    [SerializeField] private Image _tapZone;
    [SerializeField] private Image _joystickBack;
    [SerializeField] private Image _joystick;

    public static Vector2 Direction;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBack.rectTransform, eventData.position, null, out joystickPos))
        {
            joystickPos.x = (joystickPos.x * 2 / _joystickBack.rectTransform.sizeDelta.x);
            joystickPos.y = (joystickPos.y * 2 / _joystickBack.rectTransform.sizeDelta.y);
            Direction = new Vector2(joystickPos.x,joystickPos.y);
            Direction = (Direction.magnitude > 1f) ? Direction.normalized : Direction;
            _joystick.rectTransform.anchoredPosition = new Vector2(Direction.x * (_joystickBack.rectTransform.sizeDelta.x / 2), Direction.y * (_joystickBack.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _joystickBack?.gameObject.SetActive(true);
        Vector2 joystickBackPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_tapZone.rectTransform, eventData.position, null, out joystickBackPos))
        {
            _joystickBack.rectTransform.anchoredPosition = new Vector2(joystickBackPos.x, joystickBackPos.y);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _joystickBack?.gameObject.SetActive(false);
        Direction = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
