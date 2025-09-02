namespace LeetCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            int[] result1_1 = TwoSum([2, 7, 11, 15], 9);
            int[] result1_2 = TwoSum([3, 2, 4], 6);
            int[] result1_3 = TwoSum([3, 3], 6);

            string result179_1 = LargestNumberGPT([10, 2]);
            string result179_2 = LargestNumberGPT([3, 30, 34, 5, 9]);
            string result179_3 = LargestNumberGPT([1, 2, 3, 4, 5, 6, 7, 8, 9, 0]);

            Console.WriteLine("Test");
        }

        // 1. Two Sum
        public int[] TwoSum(int[] nums, int target)
        {
            int[] ints = new int[2];
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {

                    if (i != j)
                    {
                        if (nums[i] + nums[j] == target)
                        {
                            ints = [i, j];
                            return ints;
                        }
                    }
                }
            }
            return ints;
        }

        // 179. Largest Number
        public string LargestNumberGPT(int[] nums)
        {
            string[] strNums = nums.Select(n => n.ToString()).ToArray();

            Array.Sort(strNums, (a, b) =>
            {
                string order1 = a + b;
                string order2 = b + a;
                return order2.CompareTo(order1); // descendente
            });

            if (strNums[0] == "0") return "0";

            return string.Join("", strNums);
        }

        public string LargestNumberKRAOS(int[] nums)
        {
            List<string> resultados = new List<string>();

            Array.Sort(nums);

            bool seguir = true;
            while (seguir)
            {
                resultados.Add(string.Join("", nums));
                seguir = NextPermutation(nums);
            }

            resultados.Sort();
            string masGrande = resultados[resultados.Count - 1];

            return masGrande;
        }

        public bool NextPermutation(int[] array)
        {
            int i = array.Length - 2;
            while (i >= 0 && array[i] >= array[i + 1]) i--;

            if (i < 0) return false;

            int j = array.Length - 1;
            while (array[j] <= array[i]) j--;

            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;

            Array.Reverse(array, i + 1, array.Length - (i + 1));
            return true;
        }

    }
}
