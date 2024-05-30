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
    //https://www.youtube.com/watch?v=VkQZzSiYkhc&t=235s

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
void FindMajorElement()
{
    int[] arr = new int[]{2, 3, 1, 3, 3};
    int n = 4;
    MooresVotingAlgo(arr,n);
}
void MooresVotingAlgo(int[] arr,int n)
{
    //https://www.youtube.com/watch?v=NgLeC7DeWn4&t=297s
    //Now find the element in an array that has frequency >k
    int k = n / 2;
    int count = 1; int res = 0;
    for(var i=1;i<arr.Length;i++)
    {
        if (arr[res] == arr[i])
            count++;
        else
            count--;

        if (count == 0)
        {
            count = 1;
            res = i;
        }
    }
    //Verify the element in an array that has frequency >k or not!
    count = 0;
    for(var i = 0; i < arr.Length; i++)
    {
        if (arr[i] == arr[res])
            count++;
    }
    if (count > k)
    {
        Console.WriteLine("Majority Element is " + arr[res]);
    }
    else
    {
        Console.WriteLine(-1);
    }
}
void FindingTheMaxSubArray()
{
    int[] arr = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
    KadaneAlgo(arr);
}
void KadaneAlgo(int[] arr)
{
    //Naive Approach for finding subarrays
    var maxSum = int.MinValue;
    for(var i = 0; i < arr.Length; i++)
    {
        var sum = 0;
        for (int j = i; j < arr.Length; j++)
        {
            sum += arr[j];
        }
        if (sum > maxSum)
            maxSum = sum;
    }
    Console.WriteLine("Max Sum is " + maxSum);

    //Kadane's Algorithm
    //https://www.youtube.com/watch?v=YxuK6A3SvTs
    var meh = 0; //maximum ending here
    var msf = int.MinValue;  //maximum so far
    for (int i = 0; i < arr.Length; i++)
    {
        meh += arr[i];
        if (meh < arr[i])
            meh = arr[i];
        if (meh > msf)
            msf = meh;
    }
    Console.WriteLine("Max Sum is " + msf);
}
void FindingSmallestPositiveMissingNumber()
{
    int[] arr = new int[] { 0, -10,2, 1, 3, -20 };
    bucketingAlgorithm(arr);
}
void bucketingAlgorithm(int[] arr)
{
    //Naive approach for finding the smallest positive missing number
    for (int i = 1; i < int.MaxValue; i++)
    {
        if (!arr.Contains(i))
        {
            Console.WriteLine("Missing positive number: " + i);
            break;
        }
    }

    //using Bucketing Algorithm
    for (int i = 0; i < arr.Length; i++)
    {
        //if (arr[i] <= 0)
        //    arr[i] = 1;

        var index = arr[i]-1;
        while (arr[i]>0 && arr[i] < arr.Length && arr[i] != arr[index])
        {
            //swap
            var temp = arr[i];
            arr[i] = arr[index];
            arr[index] = temp;
            index = arr[i] - 1;
        }
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] != i + 1)
        {
            Console.WriteLine("Missing positive number: " + (i+1));
            return;
        }
    }
    Console.WriteLine("Missing positive number: " + (arr.Length + 1));
}

//Q1 : Find all leaders of an array
//Leader of an array means the element that has all values lesser than that towards the right side
//FindLeadersOfAnArray();

//Q2 : Sort array and seperate 0's 1's and 2's using DNF Algo
//SortZeroesOnesAndTwos();

//Q3 : Find Majority element which is greater than n/2
//For example n is 4 then find the element of an array which is being occured (frequency) greater than 4/2 i.e. greater than 2.
//FindMajorElement();

//Q4 : Find the subarray of an array which has the maximum sum
//FindingTheMaxSubArray();

//Q5 : Find the smallest positive missing number
FindingSmallestPositiveMissingNumber();

Console.ReadLine();
