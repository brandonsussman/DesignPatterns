using System;
using System.Diagnostics;

public class Merge2SortedArrays
{
    static void Main(string[] args)
    {
        int[] array1 = new int[] { 1, 2, 3,9,0,0,0};
        int[] array2 = new int[] { 1, 2, 3 };

        Merge(array1, array2);

    }

    public static void Merge(int[] array1, int[] array2)

    {
        int i1, i2, merged;
        i1 = array1.Length - array2.Length -1;
        i2 = array2.Length - 1;
        merged = array1.Length - 1;
        while (i2>=0)
        {
            if (i1>=0 && array1[i1] > array2[i2])
            {
                array1[merged] = array1[i1];
                i1--;
            }
            else {
                array1[merged] = array2[i2];
                i2--;
            }
            merged--;
        }

        for (int i = 0; i < array1.Length; i++)
        {
            Console.WriteLine(array1[i]);
        }
    }
}