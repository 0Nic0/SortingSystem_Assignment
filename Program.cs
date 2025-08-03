using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingSystem_Assignment
{
    internal class Program
    {
        static void Main()
        {
            int[] numbers = { 23, 45, 19, 1, 53, 8, 42, 37, 61 };
            int searchNum;

            while (true)
            { //Menu displays options 
                Console.WriteLine("Menu");
                Console.WriteLine("These are your numbers: " + string.Join(", ", numbers));
                Console.WriteLine();
                Console.WriteLine("Sorting");
                Console.WriteLine("1. Bubble sort");
                Console.WriteLine("2. Quicksort");
                Console.WriteLine("3. Merge sort");

                Console.WriteLine();

                Console.WriteLine("Searching");
                Console.WriteLine("4. Linear search");
                Console.WriteLine("5. Binary search");
                Console.WriteLine();
                Console.Write("Select your prefered option for Searching and Sorting: ");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        BubbleSort(numbers);
                        PrintArray(numbers);
                        break;
                    case 2:
                        quickSort(numbers, 0, numbers.Length - 1);
                        PrintArray(numbers);
                        break;
                    case 3:
                        mergeSort(numbers, 0, numbers.Length - 1);
                        PrintArray(numbers);
                        break;
                    case 4:
                        Console.Write("Please enter the number you would like to search: ");
                        searchNum = int.Parse(Console.ReadLine());
                        int linearSearchIndex = LinearSearch(numbers, searchNum);
                        if (linearSearchIndex != -1)
                            Console.WriteLine("This number is at index: " + linearSearchIndex);
                        else
                            Console.WriteLine("This number cannot be found");
                        break;
                    case 5:
                        Console.Write("Please enter the number you would like to search: ");
                        searchNum = int.Parse(Console.ReadLine());
                        int binarySearchIndex = BinarySearch(numbers, searchNum);
                        if (binarySearchIndex != -1)
                            Console.WriteLine("This number is at index: " + binarySearchIndex);
                        else
                            Console.WriteLine("This number cannot be found");
                        break;
                    default:
                        Console.WriteLine("This choice is not on the menu. Please try again!");
                        break;
                }
                Console.ReadKey();
            }
        }
        //Bubble sort Function
        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        //QuickSort Function
        static void quickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                quickSort(arr, low, pivotIndex - 1);
                quickSort(arr, pivotIndex + 1, high);
            }
        }
        //QuickSort Partition function (seperates low numbers and high numbers into sub arrays)
        static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < pivot)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp2 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp2;

            return i + 1;
        }
        //Merge Sort function
        static void mergeSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                mergeSort(arr, low, mid);
                mergeSort(arr, mid + 1, high);
                Merge(arr, low, mid, high);
            }
        }
        //Merging Function(Merges or sorted arrays)
        static void Merge(int[] arr, int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] left = new int[n1];
            int[] right = new int[n2];

            Array.Copy(arr, low, left, 0, n1);
            Array.Copy(arr, mid + 1, right, 0, n2);

            int i = 0, j = 0;
            int k = low;

            while (i < n1 && j < n2) //compares elements on the left and right sub-arrays,placing them in order
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < n1) //if any elements remain in the array
            {
                arr[k] = left[i];
                i++;
                k++;
            }

            while (j < n2) //if any elements remain in the array
            {
                arr[k] = right[j];
                j++;
                k++;
            }
        }
        //Linear Search
        static int LinearSearch(int[] arr, int searchNum) //Search for value in array
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == searchNum)
                    return i;
            }
            return -1; //if value not found
        }
        //Binary Search
        static int BinarySearch(int[] arr, int searchNum) 
        {
            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (arr[mid] == searchNum)
                    return mid;
                else if (arr[mid] < searchNum)
                    low = mid + 1;
                else
                    high = mid - 1;
            }

            return -1;
        }
        //Print values
        static void PrintArray(int[] arr)
        {
            Console.WriteLine("Sorted Array:");
            foreach (int num in arr)
            {
                Console.WriteLine(num + " ");

            }
            Console.WriteLine();
        }
    }
}
