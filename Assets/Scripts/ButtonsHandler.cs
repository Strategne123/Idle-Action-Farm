using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    [SerializeField] private ActionHandler _actionHandler;

    public void Mow()
    {
        _actionHandler.Mow();
    }
}
