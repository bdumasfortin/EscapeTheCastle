using UnityEngine;

public class DoubleDoor : MonoBehaviour, IOpenable
{
    [SerializeField] Transform _leftDoor;
    [SerializeField] Transform _rightDoor;

    public bool IsOpen => _isOpen;
    bool _isOpen = false;

    public void Open()
    {
        if (_isOpen) return;

        _isOpen = true;
        Apply();
    }

    public void Close()
    {
        if (!_isOpen) return;

        _isOpen = false;
        Apply();
    }

    public void Toggle()
    {
        _isOpen = !_isOpen;
        Apply();
    }

    void Apply()
    {
        _leftDoor.Rotate(Vector3.up * 90 * (_isOpen ? 1 : -1));
        _rightDoor.Rotate(Vector3.up * 90 * (_isOpen ? -1 : 1));
    }
}
