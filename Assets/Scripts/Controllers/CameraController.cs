using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    [Header("Camera placement")]
    [SerializeField] private float _verticalOffset = 1.5f;
    [SerializeField] private float _initialDistance = 5f;

    [Header("Camera zoom")]
    [SerializeField] private float _maxCameraDistance = 20;
    [SerializeField] private float _minCameraDistance = 0f;
    [SerializeField] private float _zoomSensitivity = 200f;
    [SerializeField] private float _zoomDampening = 10f;

    [Header("Camera collision")]
    [SerializeField] private float _minDistanceFromWall = 0.5f;
    [SerializeField] private LayerMask _collisionLayers = -1;

    private Vector2 _eulerAngles = Vector2.zero;
    private float _currentDistance;
    private float _desiredDistance;
    private float _correctedDistance;

    void Start()
    {
        if (_targetTransform == null)
            _targetTransform = transform.parent;

        _eulerAngles.x = transform.eulerAngles.x;
        _eulerAngles.x = transform.eulerAngles.y;

        _currentDistance = _initialDistance;
        _desiredDistance = _initialDistance;
        _correctedDistance = _initialDistance;
    }

    void LateUpdate()
    {
        _desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * Mathf.Abs(_desiredDistance) * _zoomSensitivity;
        _desiredDistance = Mathf.Clamp(_desiredDistance, _minCameraDistance, _maxCameraDistance);

        _eulerAngles.y = ClampAngle(_eulerAngles.y, -89f, 89f);

        Quaternion rotation = Quaternion.Euler(_eulerAngles.y, _eulerAngles.x, 0);
        _correctedDistance = _desiredDistance;

        Vector3 vTargetOffset = new Vector3(0, -_verticalOffset, 0);
        Vector3 position = _targetTransform.position - (rotation * Vector3.forward * _desiredDistance + vTargetOffset);
        Vector3 trueTargetPosition = new Vector3(_targetTransform.position.x, _targetTransform.position.y, _targetTransform.position.z) - vTargetOffset;

        bool isCorrected = false;
        if (Physics.Linecast(trueTargetPosition, position, out RaycastHit collisionHit, _collisionLayers.value))
        {
            _correctedDistance = Vector3.Distance(trueTargetPosition, collisionHit.point) - _minDistanceFromWall;
            isCorrected = true;
        }

        // For smoothing, lerp distance only if either distance wasn't corrected, or correctedDistance is more than currentDistance
        _currentDistance = !isCorrected || _correctedDistance > _currentDistance ? Mathf.Lerp(_currentDistance, _correctedDistance, Time.deltaTime * _zoomDampening) : _correctedDistance;

        _currentDistance = Mathf.Clamp(_currentDistance, _minCameraDistance, _maxCameraDistance);

        position = _targetTransform.position - (rotation * Vector3.forward * _currentDistance + vTargetOffset);

        transform.rotation = rotation;
        transform.position = position;
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
