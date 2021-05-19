using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public UnityEvent<Interactable> OnInteractedWith;
    Outline _outline;

    private void Awake()
    {
        InitOutline();
    }

    private void InitOutline()
    {
        _outline = gameObject.AddComponent<Outline>();
        _outline.enabled = false;
        _outline.OutlineMode = Outline.Mode.OutlineAll;
        _outline.OutlineColor = new Color(1, 1, 1, 0.3f);
        _outline.OutlineWidth = 2.5f;
    }

    private void OnMouseEnter()
    {
        _outline.enabled = true;
    }

    private void OnMouseExit()
    {
        _outline.enabled = false;
    }

    public void Interact()
    {
        OnInteractedWith?.Invoke(this);
    }
}
