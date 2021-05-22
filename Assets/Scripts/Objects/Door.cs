using UnityEngine;

public abstract class Door : MonoBehaviour, IOpenable
{
    protected bool _isOpen = false;
    public bool IsOpen => _isOpen;

    public virtual void Open() => _isOpen = true;
    public virtual void Close() => _isOpen = false;
    public virtual void Toggle() => _isOpen = !_isOpen;
}
