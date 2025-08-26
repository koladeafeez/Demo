public class HashMap<TKey, TValue>
{
    private class Node
    {
        public TKey Key;
        public TValue Value;
        public Node Next;
        
        public Node(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
    
    private Node[] buckets;
    private int count;
    
    public HashMap() : this(16) { }
    
    public HashMap(int size)
    {
        buckets = new Node[size];
        count = 0;
    }
    
    private int Hash(TKey key)
    {
        return Math.Abs(key.GetHashCode()) % buckets.Length;
    }
    
    public void Put(TKey key, TValue value)
    {
        int index = Hash(key);
        Node current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                current.Value = value;
                return;
            }
            current = current.Next;
        }
        
        Node newNode = new Node(key, value);
        newNode.Next = buckets[index];
        buckets[index] = newNode;
        count++;
    }
    
    public TValue Get(TKey key)
    {
        int index = Hash(key);
        Node current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
                return current.Value;
            current = current.Next;
        }
        
        throw new KeyNotFoundException();
    }
    
    public bool Remove(TKey key)
    {
        int index = Hash(key);
        Node current = buckets[index];
        Node prev = null;
        
        while (current != null)
        {
            if (current.Key.Equals(key))
            {
                if (prev == null)
                    buckets[index] = current.Next;
                else
                    prev.Next = current.Next;
                    
                count--;
                return true;
            }
            prev = current;
            current = current.Next;
        }
        
        return false;
    }
    
    public bool ContainsKey(TKey key)
    {
        int index = Hash(key);
        Node current = buckets[index];
        
        while (current != null)
        {
            if (current.Key.Equals(key))
                return true;
            current = current.Next;
        }
        
        return false;
    }
    
    public int Count { get { return count; } }
}

// Usage example
class Program
{
    static void Main()
    {
        var map = new HashMap<string, int>();
        map.Put("test", 42);
        Console.WriteLine(map.Get("test"));
    }
}
