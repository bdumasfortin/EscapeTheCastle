using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SequencePuzzle : Puzzle
{
    [SerializeField] List<Interactable> _sequenceObjects;
    [SerializeField] List<int> _correctSequence;
    [SerializeField] SortedList<int, Interactable> _testSequence;

    readonly List<int> _currentSequence = new List<int>();

    void Awake()
    {
        _sequenceObjects.ForEach(obj => obj.OnInteractedWith.AddListener(OnInteractedWithObject));
    }

    private void OnInteractedWithObject(Interactable interactable)
    {
        AddSequenceItem(_sequenceObjects.FindIndex(obj => obj == interactable));
    }

    void AddSequenceItem(int item)
    {
        TrimCurrentSequenceIfNeeded();
        _currentSequence.Insert(0, item);
        ValidateCurrentSequence();
    }

    void TrimCurrentSequenceIfNeeded()
    {
        if (_currentSequence.Count >= _correctSequence.Count)
            _currentSequence.RemoveAt(_currentSequence.Count - 1);
    }

    void ValidateCurrentSequence()
    {
        if (_correctSequence.SequenceEqual(_currentSequence))
            CompletePuzzle();
    }

    void OnDestroy()
    {
        _sequenceObjects.ForEach(obj => obj.OnInteractedWith.RemoveListener(OnInteractedWithObject));
    }
}