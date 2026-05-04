using System.Collections.Generic;

public class LRUCache
{
    private readonly int capacity;
    private Dictionary<int, LinkedListNode<(int key, int value)>> cache;
    private LinkedList<(int key, int value)> dll;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<int, LinkedListNode<(int, int)>>();
        dll = new LinkedList<(int, int)>();
    }

    public int Get(int key)
    {
        if (!cache.ContainsKey(key))
            return -1;

        var node = cache[key];
        dll.Remove(node);
        dll.AddFirst(node);

        return node.Value.value;
    }

    public void Put(int key, int value)
    {
        if (cache.ContainsKey(key))
        {
            var node = cache[key];
            dll.Remove(node);
        }
        else if (cache.Count == capacity)
        {
            var last = dll.Last;
            cache.Remove(last.Value.key);
            dll.RemoveLast();
        }

        var newNode = new LinkedListNode<(int, int)>((key, value));
        dll.AddFirst(newNode);
        cache[key] = newNode;
    }
}
