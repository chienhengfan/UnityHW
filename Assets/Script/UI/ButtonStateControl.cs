using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonStateControl : Button
{
    private static ButtonStateControl _instance;
    public static ButtonStateControl Instance() { return _instance; }
    protected override void Awake()
    {
        base.Awake();
        onClick.AddListener(() => { DoStateTransition(SelectionState.Highlighted, false); });
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        if (interactable)
        {
            DoStateTransition(SelectionState.Highlighted, true);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        if (interactable)
        {
            DoStateTransition(SelectionState.Normal, true);
        }
    }
}
