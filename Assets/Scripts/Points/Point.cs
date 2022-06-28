using System;
using UnityEngine;

public abstract class Point: MonoBehaviour
{
    [SerializeField] protected int _value;

    public int Value { get => _value; }

    public event Action<int> Changed;

    public virtual void Set(int value)
    {
        if (value <= 0)
            return;

        _value += value;
        InvokeAction();
    }

    public virtual void IncreaseOn(int value)
    {
        if (value <= 0)
            return;

        _value += value;
        InvokeAction();
    }

    public void Reset()
    {
        _value = 0;
    }

    protected void InvokeAction()
    {
        Changed?.Invoke(Value);
    }
}
