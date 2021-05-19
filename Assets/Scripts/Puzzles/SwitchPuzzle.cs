using UnityEngine;

public class SwitchPuzzle : Puzzle
{
    [SerializeField] CollisionListener _switch;

    void Awake()
    {
        _switch.OnTriggerEntered += CompletePuzzle;
    }

    void OnDestroy()
    {
        _switch.OnTriggerEntered -= CompletePuzzle;
    }
}
