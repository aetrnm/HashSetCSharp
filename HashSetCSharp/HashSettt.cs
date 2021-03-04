using System;

namespace HashSetCSharp
{
    public class HashSettt
    {
    private int[] _sizeList = new[] {11, 103, 1009, 10007, 100003, 1000003, 10000019};
    private int _currentSetSize = 0;
    private int _currentSetSizeIndex = 0;
    private string[] _set;
    private int _filledCells = 0;

    public HashSettt()
    {
        _currentSetSizeIndex = 0;
        _currentSetSize = _sizeList[_currentSetSizeIndex];
        _set = new string[_currentSetSize];
    }

    public void Add(string value)
    {
        if ((double)_filledCells / _currentSetSize * 100 >= 70)
        {
            ResizeSet();
        }
        if (Find(value))
        {
            Console.WriteLine("here");
            return;
        }
        for (int i = 0; ; i++) 
        {
            int hash = (Hasher1(value) + i*Hasher2(value)) % _currentSetSize;
            if (_set[hash] == null) 
            {
                _set[hash] = value;
                _filledCells++;
                break;
            }
        }
    }

    private void ResizeSet()
    {
        Console.WriteLine("RESIZING");
        int oldSetSize = _currentSetSize;
        
        _currentSetSizeIndex++;
        _currentSetSize = _sizeList[_currentSetSizeIndex];
        
        string[] oldSet = _set;
        
        string[] newSet = new string[_currentSetSize];
        _set = newSet;

        for (int i = 0; i < oldSetSize; i++)
        {
            if (oldSet[i] != null)
            {
                Add(oldSet[i]);
            }
        }

    }

    public bool Find(string value)
    {
        for (int i = 0; ; i++)
        {
            int hash = (Hasher1(value) + i * Hasher2(value)) % _currentSetSize;
            //Console.WriteLine(value + " " + hash);
            if (_set[hash] == value)
            {
                return true;
            }
            if (_set[hash] is null)
            {
                return false;
            }
        }
    }

    private int Hasher1(string value)
    {
        return Math.Abs(value.GetHashCode()) % _currentSetSize;
    }

    private int Hasher2(string value)
    {
        return Math.Abs((value.GetHashCode() + "#").GetHashCode()) % _currentSetSize;
    }
    }
}    