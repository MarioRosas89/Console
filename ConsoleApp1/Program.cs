// See https://aka.ms/new-console-template for more information

using IBM.WMQ;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text;

//Cambio mario

int[] arr1 = { 1, 2, 3, 1 };
int[] arr2 = { 51, 43, 12, 12, 18, 14 , 13 };
var lnkd1 = new LinkedList<int>(arr1);
var lnkd2 = new LinkedList<int>(arr2);
//var nsc = isMatch("ab", ".*c");
//linkedListSorted(lnkd1, lnkd2);
//int f = Fib(3);
//var days = getMinimumDays(new List<int> { 5 , 2 , 4});
//towerOfHanoi(n, 'A', 'C', 'B');
//int nsdin = CountTriplets(arr1);
//countSubarrays(new List<int> { 2, 3, 4 }, 6);
//findInterestingPairs(new List<int> { 4, 1, 3, 2, 0, 2 }, 1);
//Console.WriteLine("Hello, World!");
static int CountTriplets(int[] nums)
{
    int cnt = 0;

    for (int i = 0; i < nums.Length; i++)
        for (int j = i + 1; j < nums.Length; j++)
            for (int k = j + 1; k < nums.Length; k++)
                if (nums[k] < nums[i] &&
                    nums[i] < nums[j])
                {
                    cnt += 1;
                }

    return cnt;
}

static int getMinimumDays(List<int> parcels)
{
    if (!parcels.Any(o => o != parcels[0]))
        return 1;
    var maxParcels = parcels.Max();
    var minParcels = parcels.Min();
    int dispatched = maxParcels - minParcels;

    //for (var i = maxParcels; i >= minParcels; i--)
    //{
    //    if (i > minParcels)
    //        dispatched++;
    //    else if (i == minParcels)
    //    {
    //        dispatched++;
    //        break;
    //    }
    //}
    return dispatched;
}

static long findMaxProducts(List<int> products)
{
    int firstSum = products.Take(3).Sum();
    int secondSum = products.Take(4).Sum();
    int thirdSum = products.Take(5).Sum();
    if (firstSum > secondSum && firstSum > thirdSum)
        return firstSum;

    if (secondSum > firstSum && secondSum > thirdSum)
        return secondSum;

    if (thirdSum > secondSum && thirdSum > firstSum)
        return thirdSum;

    return thirdSum;
}

int Fib(int N)
{
    if (N <= 0)
    {
        return 0;
    }

    int a = 0, b = 1, c = 1;
    for (int i = 1; i < N; i++)
    {
        c = a + b;
        a = b;
        b = c;
    }

    return c;
}

static void towerOfHanoi(int n, char from_rod, char to_rod, char aux_rod)
{
    if (n == 0)
    {
        return;
    }
    towerOfHanoi(n - 1, from_rod, aux_rod, to_rod);
    Console.WriteLine("Move disk " + n + " from rod " +
                      from_rod + " to rod " + to_rod);
    towerOfHanoi(n - 1, aux_rod, to_rod, from_rod);
}
static double GetEvenNumberOnArray(int[] arr)
{
    int n = arr.Length;

    // If length of array is even
    if (n % 2 == 0)
    {
        int z = n / 2;
        double e = arr[z];
        double q = arr[z - 1];

        double ans = (e + q) / 2;
        return ans;
    }

    // If length if array is odd
    else
    {
        int z = n / 2;
        return arr[z];
    }
}

// Driver Code
static void Main()
{

    // TODO Auto-generated method stub
    int[] arr1 = { 1, 2 };
    int[] arr2 = { 3, 4 };

    // Merge two array into one array
    var myList = new List<int>();
    myList.AddRange(arr1);
    myList.AddRange(arr2);
    int[] arr3 = myList.ToArray();

    // Sort the merged array
    Array.Sort(arr3);

    // calling the method
    Console.Write("Median = " + GetEvenNumberOnArray(arr3));
}

static bool isMatch(string s, string p)
{
    if (string.IsNullOrEmpty(p))
        return string.IsNullOrEmpty(s);
    var dp = new bool[s.Length + 1, p.Length + 1];

    dp[0, 0] = true;
    for (int i = 2; i <= p.Length; i++)
        dp[0, i] = p[i - 1] == '*' && dp[0, i - 2];

    for (int i = 1; i <= s.Length; i++)
    {
        for (int j = 1; j <= p.Length; j++)
        {
            if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                dp[i, j] = dp[i - 1, j - 1];
            else if (p[j - 1] == '*')
                dp[i, j] = dp[i, j - 2] || ((s[i - 1] == p[j - 2] || p[j - 2] == '.') && dp[i - 1, j]);
        }
    }

    return dp[s.Length, p.Length];
}

static void fizzBuzz(int n)
{
    for (var i = 1; i <= n; i++)
    {

        if (i % 3 == 0 && i % 5 == 0)
        {
            Console.WriteLine("FizzBuzz");
        }
        else if (i % 3 == 0)
        {
            Console.WriteLine("Fizz");
        }
        else if (i % 5 == 0)
        {
            Console.WriteLine("Buzz");
        }
        else
        {
            Console.WriteLine(i);
        }

    }
}

static bool SumArray(int[] array, int value)
{
    var foundValues = new List<int>();
    foreach (var a in array) {
        if (foundValues.Contains(value - a))
        {
            return true;
        }

        foundValues.Add(a);
    }
return false;
}

static void linkedListSorted(LinkedList<int> values1, LinkedList<int> value2)
{
    LinkedList<int> sorted = new LinkedList<int>();
    foreach (var item in values1.ToList())
    {
        sorted.AddFirst(item);
    }

    foreach (var item in value2.ToList())
    {
        sorted.AddFirst(item);
    }

    var sortedLinked = sorted.OrderBy(x => x).ToList();
}

int ROW = 5, COL = 5, ROWCOL = 4 ;

// A function to check if
// a given cell (row, col)
// can be included in DFS
bool isSafe(int[,] M, int row,
                   int col, bool[,] visited)
{
    // row number is in range,
    // column number is in range
    // and value is 1 and not
    // yet visited
    return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL) && (M[row, col] == 1 && !visited[row, col]);
}

// A utility function to do
// DFS for a 2D boolean matrix.
// It only considers the 8
// neighbors as adjacent vertices
void DFS(int[,] M, int row,
                int col, bool[,] visited)
{
    // These arrays are used to
    // get row and column numbers
    // of 8 neighbors of a given cell
    int[] rowNbr = new int[] { -1, -1, -1, 0,
                                   0, 1, 1, 1 };
    int[] colNbr = new int[] { -1, 0, 1, -1,
                                   1, -1, 0, 1 };

    // Mark this cell
    // as visited
    visited[row, col] = true;

    // Recur for all
    // connected neighbours
    for (int k = 0; k < 8; ++k)
        if (isSafe(M, row + rowNbr[k], col + colNbr[k], visited))
            DFS(M, row + rowNbr[k],
                col + colNbr[k], visited);
}

// The main function that
// returns count of islands
// in a given boolean 2D matrix
int countIslands(int[,] M)
{
    // Make a bool array to
    // mark visited cells.
    // Initially all cells
    // are unvisited
    bool[,] visited = new bool[ROW, COL];

    // Initialize count as 0 and
    // traverse through the all
    // cells of given matrix
    int count = 0;
    for (int i = 0; i < ROW; ++i)
        for (int j = 0; j < COL; ++j)
            if (M[i, j] == 1 && !visited[i, j])
            {
                // If a cell with value 1 is not
                // visited yet, then new island
                // found, Visit all cells in this
                // island and increment island count
                DFS(M, i, j, visited);
                ++count;
            }

    return count;
}

int[,] M = new int[,] { { 1, 1, 0, 0, 0 },
                                  { 0, 1, 0, 0, 1 },
                                  { 1, 0, 0, 1, 1 },
                                  { 0, 0, 0, 0, 0 },
                                  { 1, 0, 1, 0, 1 } };
int MinimunSteps(List<string> loggedMoves) {
    Stack<string> stackedMoves =
        new Stack<string>();

    for (int i = 0; i < loggedMoves.Count; i++)
    {
        if (loggedMoves[i] == "../" &&
            stackedMoves.Count != 0)
        {           
            stackedMoves.Pop();
        }
        else if (loggedMoves[i] != "./")
        {          
            stackedMoves.Push(loggedMoves[i]);
        }
    }

    return stackedMoves.Count;

}
static List<string> FilterConsecutiveOperations(List<string> operations)
{
    List<string> filteredOperations = new List<string>();

    string prevOp = "";

    foreach (string op in operations)
    {
        if (op != prevOp)
        {
            filteredOperations.Add(op);
        }

        prevOp = op;
    }

    return filteredOperations;
}
static List<string> ReplaceXOperations(List<string> operations)
{
    List<string> modifiedOperations = new List<string>();

    foreach (string op in operations)
    {
        if (op.StartsWith("/"))
        {
            modifiedOperations.Add("../");
        }
        else
        {
            modifiedOperations.Add(op);
        }
    }

    return modifiedOperations;
}

int diagonalDifference(List<List<int>> arr)
{
    int n = arr.Count;
    int leftToRightDiagonalSum = 0;
    int rightToLeftDiagonalSum = 0;

    for (int i = 0; i < n; i++)
    {
        leftToRightDiagonalSum += arr[i][i];
        rightToLeftDiagonalSum += arr[i][n - i - 1];
    }

    return Math.Abs(leftToRightDiagonalSum - rightToLeftDiagonalSum);
}


static long findInterestingPairs(List<int> arr, int sumVal)
{
    int num_of_pairs = 0;
    for (int i = 0; i < arr.Count; i++)
    {
        for (int j = i + 1; j < arr.Count; j++)
        {
            if (Math.Abs(arr[i] - arr[j]) + Math.Abs(arr[i] + arr[j]) == sumVal)
            {
                num_of_pairs++;
            }
        }
    }
    return num_of_pairs;
}
List<List<long>> sides = new List<List<long>> {
            new List<long> { 4, 8 },
            new List<long> { 15, 30 },
            new List<long> { 25, 50 }
        };
long result = nearlySimilarRectangles(sides);
Console.WriteLine(result);
static long nearlySimilarRectangles(List<List<long>> sides)
{
    int count = 0;
    HashSet<double> ratios = new HashSet<double>();
    for (int i = 0; i < sides.Count; i++)
    {
        double ratio = (double)sides[i][0] / (double)sides[i][1];
        if (ratios.Contains(ratio))
        {
            count++;
        }
        else
        {
            ratios.Add(ratio);
        }
    }
    return count;
}
int miniMaxSum(List<int> arr)
{
    long minSum = 0;
    long maxSum = 0;
    long currentSum;

    for (int i = 0; i < arr.Count; i++)
    {
        currentSum = 0;
        for (int j = 0; j < arr.Count; j++)
        {
            if (i != j)
            {
                currentSum += arr[j];
            }
        }

        if (i == 0)
        {
            minSum = currentSum;
            maxSum = currentSum;
        }
        else
        {
            if (currentSum < minSum)
            {
                minSum = currentSum;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }
    }

    Console.WriteLine("{0} {1}", minSum, maxSum);
    return 0;
}

int MaxArea(int[] height)
{
    int left = 0;
    int right = height.Count() - 1;

    // initialize the maximum water variable
    int max_water = 0;

    // loop until the pointers meet
    while (left < right)
    {
        // calculate the maximum amount of water that can be stored between the two lines
        int water = Math.Min(height[left], height[right]) * (right - left);
        // update the maximum water variable
        max_water = Math.Max(max_water, water);
        // move the pointer with the shorter line inward
        if (height[left] < height[right])
            left = left + 1;
        else
            right = right - 1;
    }

    // return the maximum water
    return max_water;
}


static long countSubarrays(List<int> numbers, int k)
{

    int numSubarrays = 0;

    for (int startIndex = 0; startIndex < numbers.Count; startIndex++)
    {
        for (int endIndex = startIndex; endIndex < numbers.Count; endIndex++)
        {
            if (Product(numbers, startIndex, endIndex) <= k)
            {
                numSubarrays++;
            }
        }
    }

    return numSubarrays;
}

static long Product(List<int> numbers, int startIndex, int endIndex)
{
    long product = 1;
    for (int i = startIndex; i <= endIndex; i++)
    {
        product *= numbers[i];
    }
    return product;
}

static string findNumber(List<int> arr, int k)
{
    string founded = "";
    bool found = false;
    for (int i = 0; i < arr.Count; i++)
    {
        if (arr[i] == k)
        {
            found = true;
            break;
        }
    }

    if (found)
    {
        founded = "YES";
    }
    else
    {
        founded = "NO";
    }
    return founded;
}

static List<int> oddNumbers(int l, int r)
{
    var lstInt = new List<int>();
    for (int i = l; i <= r; i++)
    {
        if (i % 2 != 0)
        {
            lstInt.Add(i);
        }
    }
    return lstInt;
}
 static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
{
    return employees.OrderBy(x => x.Company)
    .GroupBy(e => e.Company)
    .ToDictionary(g => g.Key, g => (int)Math.Round(g.Average(e => e.Age)));
}

 static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
{
    return employees
   .GroupBy(e => e.Company)
    .ToDictionary(g => g.Key, g => g.Count());
}

 static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
{
    return employees
       .GroupBy(e => e.Company)
       .ToDictionary(g => g.Key, g => g.Max(e => e))
       .OrderBy(d => d.Key)
       .ToDictionary(d => d.Key, d => d.Value);

}


maxPairs(new List<int> { 6,3,4,5,2,1,1,3 }, 6);
static long getMinCost(List<int> crew_id, List<int> job_id)
{
    crew_id.Sort();
    job_id.Sort();

    int minTotalDistance = 0;

    for (int i = 0; i < crew_id.Count; i++)
    {
        int matchCost = Math.Abs(crew_id[i] - job_id[i]);

        minTotalDistance += matchCost;
    }

    return minTotalDistance;
}

int max_two_distinct(List<int> arr)
{
    int max = 0;
    List<int> count = new List<int>
    {
        1
    }, elem = new List<int>
    {
        arr[0]
    };

    for (int i = 1; i < arr.Count; i++)
    {
        if (Math.Abs(arr[i] - arr[i - 1]) < 2)
        {
            if (elem.Contains(arr[i]) || elem.Count == 1)
            {
                count.Add(count[i - 1] + 1);
                if (elem.Count == 1) elem.Add(arr[i]);
            }
            else
            {
                int j = i - 2; 
                while (j >= 0 && arr[j] == arr[i - 1]) j--;
                count.Add(i - j);
            }
        }
        else
        {
            count.Add(1);
        }
        max = Math.Max(max, count[i]);
    }

    return max;
}

static long taskOfPairing(List<long> freq)
{
    long ans = 0, rem = 0;
    for (int i = 0; i < freq.Count; i++)
    {
        if (freq[i] != 0)
        {
            ans += (freq[i] + rem) / 2;
            rem = (freq[i] + rem) % 2;
        }
        else
        {
            rem = 0; 
        }
    }
    return ans;
}


int maxPairs(List<int> skillLevel, int minDiff)
{
    skillLevel = skillLevel.OrderBy(x => x).ToList();
    int num_pairs = 0;

    for (int i = 0; i < skillLevel.Count; i++)
    {
        for (int j = i + 1; j < skillLevel.Count; j++)
        {
            if (skillLevel[j] - skillLevel[i] >= minDiff)
            {
                num_pairs++;
                break;
            }
        }
    }

    return num_pairs;
}

int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
{
    // Initialize counts for each direction
    int up = n - r_q;
    int down = r_q - 1;
    int left = c_q - 1;
    int right = n - c_q;
    int up_left = Math.Min(up, left);
    int up_right = Math.Min(up, right);
    int down_left = Math.Min(down, left);
    int down_right = Math.Min(down, right);

    // Loop through obstacles
    foreach (var obstacle in obstacles)
    {
        int r_o = obstacle[0];
        int c_o = obstacle[1];

        // Check if obstacle is on same row or column as queen
        if (r_o == r_q)
        {
            if (c_o < c_q)
            {
                left = Math.Min(left, c_q - c_o - 1);
            }
            else
            {
                right = Math.Min(right, c_o - c_q - 1);
            }
        }
        else if (c_o == c_q)
        {
            if (r_o < r_q)
            {
                down = Math.Min(down, r_q - r_o - 1);
            }
            else
            {
                up = Math.Min(up, r_o - r_q - 1);
            }
        }

        // Check if obstacle is on same diagonal as queen
        else if (Math.Abs(r_o - r_q) == Math.Abs(c_o - c_q))
        {
            if (r_o < r_q)
            {
                if (c_o < c_q)
                {
                    down_left = Math.Min(down_left, c_q - c_o - 1);
                }
                else
                {
                    down_right = Math.Min(down_right, c_o - c_q - 1);
                }
            }
            else
            {
                if (c_o < c_q)
                {
                    up_left = Math.Min(up_left, c_q - c_o - 1);
                }
                else
                {
                    up_right = Math.Min(up_right, c_o - c_q - 1);
                }
            }
        }
    }

    // Return total number of squares queen can attack
    return up + down + left + right + up_left + up_right + down_left + down_right;
}

int GetResult(string S)
{
    var stack = new Stack<int>();
    foreach (string operation in S.Split(' '))
    {
        if (int.TryParse(operation, out int num))
        {
            stack.Push(num);
        }
        else
        {
            switch (operation)
            {
                case "DUP":
                    if (stack.Count == 0)
                    {
                        return -1;
                    }
                    int top = stack.Peek();
                    stack.Push(top);
                    break;
                case "POP":
                    if (stack.Count == 0)
                    {
                        return -1;
                    }
                    stack.Pop();
                    break;
                case "+":
                    if (stack.Count < 2)
                    {
                        return -1;
                    }
                    int num1 = stack.Pop();
                    int num2 = stack.Pop();
                    stack.Push(Math.Abs(num1 + num2));
                    break;
                case "-":
                    if (stack.Count < 2)
                    {
                        return -1;
                    }
                    int num3 = stack.Pop();
                    int num4 = stack.Pop();
                    stack.Push(Math.Abs(num4 - num3));
                    break;
                default:
                    return -1;
            }
        }
    }

    if(stack.Count == 1)
        return -1;

    return stack.Pop();    

}

string Solution(string S)
{
    if (S.All(c => c == '0'))
    {
        return "0";
    }

    List<string> palindromes = new List<string>();
    for (int i = 0; i < S.Length; i++)
    {
        for (int j = i + 1; j <= S.Length; j++)
        {
            string candidate = S.Substring(i, j - i);
            if (IsPalindrome(candidate) && !candidate.StartsWith("0"))
            {
                palindromes.Add(candidate);
            }
        }
    }

    return palindromes.FirstOrDefault();
}

bool IsPalindrome(string input)
{
    int length = input.Length;
    for (int i = 0; i < length / 2; i++)
    {
        if (input[i] != input[length - i - 1])
        {
            return false;
        }
    }
    return true;
}

//int[] arreglo = { 4, 5, 2, 4, 5, 9, 9, 4, 4 };
//var v = mismaDiferencia(new double[] { 1, 3, 5 }); // true;
//var cds = mismaDiferencia(new double[] { 194, 54, 23, 7, 3, 6, 8 }); // false;
//var sdv = contiene(arreglo, 4, 3);
//var svdf = contiene(arreglo, 9, 2);
static bool contiene(int[] arreglo, int numero, int cantidad_minima)
{
    int repeticiones = 0;
    foreach (int num in arreglo)
    {
        if (num == numero)
        {
            repeticiones++;
        }
    }
    return repeticiones >= cantidad_minima;
}

static int mayorDiferencia(int[] arreglo)
{
    int min_num = arreglo.Min();
    int max_num = arreglo.Max();

    return max_num - min_num;
}

static bool mismaDiferencia(double[] arreglo)
{
    if (arreglo.Length < 3) 
    {
        return true;
    }

    double diferencia = arreglo[1] - arreglo[0]; 

    for (int i = 2; i < arreglo.Length; i++)
    {
        if (Math.Abs(arreglo[i] - arreglo[i - 1] - diferencia) > 0.00001) 
        {
            return false;
        }
    }

    return true;
}

static void Mandamensage()
{
    string strQueueManagerName = "QM1";
    string strChannelName = "CLIENTS";
    string strQueueName = "Q1";
    string strServerName = "127.0.0.1";
    int intPort = 1414;
    string strMsg = "Hello IBM, this is a message";

    Hashtable queueProperties = new Hashtable
            {
                { MQC.HOST_NAME_PROPERTY, strServerName },
                { MQC.CHANNEL_PROPERTY, strChannelName },
                { MQC.PORT_PROPERTY, intPort },
                { MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED }
            };

    //Set Username
    //MQEnvironment.UserId = "User";

    //Set Passowrd
    //MQEnvironment.Password = "123";

    //Define a Queue Manager
    try
    {
        MQQueueManager myQM = new MQQueueManager
                              (strQueueManagerName, queueProperties);

        //Define a Message
        MQMessage queueMessage = new MQMessage();
        queueMessage.Format = MQC.MQFMT_STRING;
        queueMessage.CharacterSet = Encoding.UTF8.CodePage;
        queueMessage.Write(Encoding.UTF8.GetBytes(strMsg));

        //Define a Queue
        var queue = myQM.AccessQueue
            (strQueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING);
        MQPutMessageOptions queuePutMessageOptions = new MQPutMessageOptions();
        queue.Put(queueMessage, queuePutMessageOptions);
        queue.Close();
        Console.WriteLine("Success");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.ReadLine();
}

ExisteDns("www.google.com");
static void ExisteDns(string domainName)
{
    try
    {
        IPHostEntry hostEntry = Dns.GetHostEntry(domainName);
        Console.WriteLine($"{domainName} existe y se resuelve a la dirección IP {hostEntry.AddressList[0]}");
    }
    catch (SocketException)
    {
        Console.WriteLine($"{domainName} no existe o no se puede resolver");
    }
}






