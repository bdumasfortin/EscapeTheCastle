using UnityEngine;

public class SimpleDoor : Door
{
    public override void Open()
    {
        if (_isOpen) return;
        base.Open();
        RotateDoorTransform();
    }

    public override void Close()
    {
        if (!_isOpen) return;
        base.Close();
        RotateDoorTransform();
    }

    public override void Toggle()
    {
        base.Toggle();
        RotateDoorTransform();
    }

    void RotateDoorTransform()
    {
        transform.Rotate(Vector3.up * 90 * (_isOpen ? 1 : -1));
    }
}
