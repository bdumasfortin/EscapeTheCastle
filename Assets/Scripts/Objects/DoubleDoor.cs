using UnityEngine;

public class DoubleDoor : Door
{
    [SerializeField] Transform _leftDoor;
    [SerializeField] Transform _rightDoor;

    public override void Open()
    {
        if (_isOpen) return;
        base.Open();
        RotateDoorsTransform();
    }

    public override void Close()
    {
        if (!_isOpen) return;
        base.Close();
        RotateDoorsTransform();
    }

    public override void Toggle()
    {
        base.Toggle();
        RotateDoorsTransform();
    }

    void RotateDoorsTransform()
    {
        _leftDoor.Rotate(Vector3.up * 90 * (_isOpen ? 1 : -1));
        _rightDoor.Rotate(Vector3.up * 90 * (_isOpen ? -1 : 1));
    }
}