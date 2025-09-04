using System.Linq;

namespace LeetCode
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Los problemas que terminan por "GPT" significa que tire la toalla y le pregunte a ChatGPT como se podia resolver :(
        /// Los problemas que terminan por "KRAOS" significa que fueron un desastre total y no funcionan, un "caos" marca de la casa ;)
        /// Todos los problemas estan ordenados en orden descendiente a la solucion de estos, el primero que encuentres sera el ultimo que hice y el ultimo en el codigo es el primero que hice :)
        /// Siento que sea asi de cutre, solo queria hacer debug de una forma rapida y sencilla :/
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            string result179_1 = LargestNumberGPT([10, 2]);
            string result179_2 = LargestNumberGPT([3, 30, 34, 5, 9]);
            string result179_3 = LargestNumberGPT([1, 2, 3, 4, 5, 6, 7, 8, 9, 0]);

            int[] result1_1 = TwoSum([2, 7, 11, 15], 9);
            int[] result1_2 = TwoSum([3, 2, 4], 6);
            int[] result1_3 = TwoSum([3, 3], 6);

            bool result9_1 = IsPalindrome(121);
            bool result9_2 = IsPalindrome(-121);
            bool result9_3 = IsPalindrome(10);

            int result13_1 = RomanToInt("III");
            int result13_2 = RomanToInt("LVIII");
            int result13_3 = RomanToInt("MCMXCIV");

            string result14_1 = LongestCommonPrefix(["flower", "flow", "flight"]);
            string result14_2 = LongestCommonPrefix(["dog", "racecar", "car"]);
            string result14_3 = LongestCommonPrefix(["c", "acc", "ccc"]);

            Console.WriteLine("Cargando...");
            Console.WriteLine("OK");
        }

        // TEST CHANGE GIT BASH USER

        // 14. Longest Common Prefix
        public string LongestCommonPrefix(string[] strs)
        {
            string result = string.Empty;

            for (int i = strs[0].Length - 1; i >= 0; i--)
            {
                string compare = strs[0].Substring(0, i + 1);

                bool ok = true;

                for (int j = 1; j < strs.Length; j++)
                {
                    if (!strs[j].StartsWith(compare))
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    result = compare;
                    break;
                }

            }

            return result;
        }

        public string LongestCommonPrefixKRAOS(string[] strs)
        {
            string result = string.Empty;

            if (strs.Length > 1)
            {
                char[] arr = strs[0].ToCharArray();

                foreach (char c in arr)
                {
                    string cIgual = string.Empty;
                    bool ok2 = false;
                    for (int k = 0; k < strs.Length; k++)
                    {
                        if (0 != k)
                        {
                            char[] arr2 = strs[k].ToCharArray();
                            ok2 = false;

                            foreach (char c2 in arr2)
                            {
                                if (c == c2)
                                {
                                    cIgual = c.ToString();
                                    ok2 = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (ok2)
                    {
                        result += cIgual.ToString();
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                result = strs[0];
            }

            return result;
        }

        // 13. Roman to Integer
        public int RomanToInt(string s)
        {
            int result = 0;
            char[] chars = s.ToCharArray();

            int lastNum = 0;

            for (int i = 0; i < chars.Length; i++)
            {
                int num = 0;
                switch (chars[i])
                {
                    case 'I':
                        num = 1;
                        break;
                    case 'V':
                        num = 5;
                        break;
                    case 'X':
                        num = 10;
                        break;
                    case 'L':
                        num = 50;
                        break;
                    case 'C':
                        num = 100;
                        break;
                    case 'D':
                        num = 500;
                        break;
                    case 'M':
                        num = 1000;
                        break;
                }

                if (lastNum < num && lastNum != 0)
                {
                    result = (result - lastNum) + (num - lastNum);
                }
                else
                {
                    result = result + num;
                }
                lastNum = num;
            }

            return result;
        }

        // 9. Palindrome Number
        public bool IsPalindrome(int x)
        {
            bool result = false;
            string str = x.ToString();
            char[] arr = str.ToCharArray();
            string strI = string.Empty;

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                strI += arr[i];
            }

            if (str == strI)
            {
                result = true;
            }

            return result;
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
