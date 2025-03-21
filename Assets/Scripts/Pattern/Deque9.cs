using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deque9<T> : MonoBehaviour where T : MonoBehaviour
{
    private LinkedList<T> items = new LinkedList<T>();

    public void AddFront(T item)
    {
        items.AddFirst(item);
    }

    public void AddBack(T item)
    {
        items.AddLast(item);
    }

    public T RemoveFront()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Deque is empty.");

        T item = items.First.Value;
        items.RemoveFirst();
        return item;
    }

    public T RemoveBack()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Deque is empty.");

        T item = items.Last.Value;
        items.RemoveLast();
        return item;
    }

    public T PeekFront()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Deque is empty.");
        
        return items.First.Value;
    }

    public T PeekBack()
    {
        if (items.Count == 0)
            throw new InvalidOperationException("Deque is empty.");
        
        return items.Last.Value;
    }

    public bool IsEmpty() => items.Count == 0;
    public int Count => items.Count;
}
