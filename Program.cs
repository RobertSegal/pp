// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
int target = 10;

var x = GetSum(target, list);

foreach(var group in x)
{
    Console.WriteLine(string.Join(", ", group));
}

List<List<int>> GetSum(int total, List<int> A, List<int> result = null)
{
    List<List<int>> combinations = new List<List<int>>();

    if (result == null)
    {
        result = new List<int>();
    }

    for (int i = 0; i < A.Count; i++)
    {
        int n = A[i];

        if (n == total)
        {
            combinations.Add(new List<int>(result) { n });
        }

        if (n >= total)
        {
            continue;
        }

        combinations.AddRange(GetSum(total - n, A.GetRange(i + 1, A.Count - (i + 1)), result.Concat(new List<int> { n }).ToList()));
    }

    return combinations;
}