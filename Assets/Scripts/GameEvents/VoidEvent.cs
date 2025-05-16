using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/VoidEvent", fileName = "NewVoidEvent")]
public class VoidEvent : GameEvent
{
    private Action _action;

    public void AddListener(Action action)
    {
        _action += action;
    }

    public void RemoveListener(Action action)
    {
        _action -= action;
    }

    public void Raise()
    {
        _action?.Invoke();
    }
}