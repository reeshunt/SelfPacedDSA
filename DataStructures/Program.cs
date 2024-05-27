void PrintAllItems(int[] arr)
{
    Console.WriteLine("Result : \n");
    foreach (var item in arr)
    {
        Console.WriteLine(item);
    }
}
void FindLeadersOfAnArray()
{
    int[] arr = new int[] { 16, 17, 4, 3, 5, 2 };
    //Finding the leaders of the array i.e. the number of the array is the greatest if we look towards the right side of that particular element of an array
    List<int> leaders = new List<int>();
    int maxValue = arr[arr.Length - 1];
    leaders.Add(maxValue); // as the right most value is always going to be the leader
    for (var i = arr.Length - 1; i >= 0; i--)
    {
        if (maxValue <  arr[i]) //if the value is gt than maxValue then add to list 
        {
            leaders.Add(arr[i]);
            maxValue = arr[i];  //change the new max value
        }
    }
    PrintAllItems(leaders.ToArray());
}
void SortZeroesOnesAndTwos()
{
    int[] arr = new int[] { 0, 2, 1, 2, 0};
    dutchNationalFlagAlgo(arr);
}
void swap(int[] arr,int swapPos1,int swapPos2)
{
    int temp = arr[swapPos1];
    arr[swapPos1] = arr[swapPos2];
    arr[swapPos2] = temp;
}
void dutchNationalFlagAlgo(int[] arr)
{
    int start = 0;
    int end = arr.Length - 1;
    int mid = (start + end) / 2;
    while (mid <= end)
    {
        if (arr[mid] == 0)
        {
            //swap with start
            swap(arr, start, mid);
            start += 1;
        }
        if (arr[mid] == 2)
        {
            //swap with end
            swap(arr, end, mid);
            end -= 1;
        }
        if (arr[mid] == 1)
        {
            //leave as it is and increase mid
            mid += 1;
        }
    }
    PrintAllItems(arr);

}
Console.ReadLine();



//Q1 : Find all leaders of an array
//FindLeadersOfAnArray();
//Q2 : Sort array and seperate 0's 1's and 2's using DNF Algo
//SortZeroesOnesAndTwos();
//Q3 : 