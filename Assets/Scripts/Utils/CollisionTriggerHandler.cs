using UnityEngine;
using UnityEngine.Events;

public class CollisionTriggerHandler : MonoBehaviour
{
    [SerializeField] UnityEvent OnTriggerEntered;

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke();
    }
}
