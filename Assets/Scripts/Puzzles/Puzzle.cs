using System;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    public event Action OnPuzzleCompleted;
    protected virtual void CompletePuzzle() => NotifyPuzzleCompleted();
    private void NotifyPuzzleCompleted() => OnPuzzleCompleted?.Invoke();
}
