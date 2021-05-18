using System;
using UnityEngine;
using UnityEngine.Events;

public class SwitchPuzzle : Puzzle
{
    [SerializeField] CollisionListener _switch;
    [SerializeField] UnityEvent _onCompleted;

    void Awake()
    {
        _switch.OnTriggerEntered += CompletePuzzle;
    }

    void OnDestroy()
    {
        _switch.OnTriggerEntered -= CompletePuzzle;
    }

    protected override void CompletePuzzle()
    {
        _onCompleted?.Invoke();
        base.CompletePuzzle();
    }
}
