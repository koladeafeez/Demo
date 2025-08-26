public class BinarySort
{
    public static void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;
            
        int maxBits = GetMaxBits(arr);
        
        for (int bit = 0; bit < maxBits; bit++)
        {
            SortByBit(arr, bit);
        }
    }
    
    private static int GetMaxBits(int[] arr)
    {
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > max)
                max = arr[i];
        }
        
        int bits = 0;
        while (max > 0)
        {
            max >>= 1;
            bits++;
        }
        return bits;
    }
    
    private static void SortByBit(int[] arr, int bit)
    {
        int[] temp = new int[arr.Length];
        int zeroCount = 0;
        
        for (int i = 0; i < arr.Length; i++)
        {
            if ((arr[i] >> bit & 1) == 0)
                zeroCount++;
        }
        
        int zeroIndex = 0;
        int oneIndex = zeroCount;
        
        for (int i = 0; i < arr.Length; i++)
        {
            if ((arr[i] >> bit & 1) == 0)
                temp[zeroIndex++] = arr[i];
            else
                temp[oneIndex++] = arr[i];
        }
        
        for (int i = 0; i < arr.Length; i++)
            arr[i] = temp[i];
    }
}
