﻿// 1.Basic queue implementation
public class MyQueue
{
    #region Fields
    int[] data;
    int capacity;
    int head, tail;
    int count;
    #endregion
    #region Ctors
    public MyQueue(): this(42)
    {
    }
    public MyQueue(int capacity)
    {
        this.capacity = capacity;
        data = new int[capacity];
        head = tail = 0;
        count = 0;
    }
    #endregion

    #region Properties
    public int Count => count;
    public bool Empty => count == 0;
    #endregion

    #region Methods
    public void Enqueue(int val)
    {
        if (count < capacity)
        {
            if (tail >= data.Length)
            {
                tail = 0;
            }
            data[tail++] = val;
            Logger.Instance.Log($"Am adaugat valoarea {val} in coada");
            count++;
        }
        else
            throw new QueueFullException("Coada este plina");
    }
    public int Dequeue()
    {
        if (count > 0)
        {
            int val = data[head];
            head = (head + 1) % capacity;
            count--;
            return val;
        }
        else
            throw new QueueEmptyException("Coada este goala");
    }
    #endregion
}