using System;
using UnityEngine;

public class CollisionListener : MonoBehaviour
{
    public event Action OnTriggerEntered;
    public event Action OnCollisionEntered;

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEntered?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered?.Invoke();
    }
}
