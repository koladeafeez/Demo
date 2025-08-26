public class BinarySort
{
    public static void Sort(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return;
            
        SortRecursive(arr, 0, arr.Length - 1);
    }
    
    private static void SortRecursive(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int mid = (left + right) / 2;
            
            SortRecursive(arr, left, mid);
            SortRecursive(arr, mid + 1, right);
            
            Merge(arr, left, mid, right);
        }
    }
    
    private static void Merge(int[] arr, int left, int mid, int right)
    {
        int[] temp = new int[right - left + 1];
        int i = left, j = mid + 1, k = 0;
        
        while (i <= mid && j <= right)
        {
            if (arr[i] <= arr[j])
                temp[k++] = arr[i++];
            else
                temp[k++] = arr[j++];
        }
        
        while (i <= mid)
            temp[k++] = arr[i++];
            
        while (j <= right)
            temp[k++] = arr[j++];
            
        for (i = 0; i < temp.Length; i++)
            arr[left + i] = temp[i];
    }
}
