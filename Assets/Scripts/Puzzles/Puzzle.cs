using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField] UnityEvent _onCompleted;

    public event Action OnPuzzleCompleted;
    private void NotifyPuzzleCompleted() => OnPuzzleCompleted?.Invoke();

    protected virtual void CompletePuzzle()
    {
        _onCompleted?.Invoke();
        NotifyPuzzleCompleted();
    }
}
