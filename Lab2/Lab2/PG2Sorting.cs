using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public static class PG2Sorting
    {
        public static List<string> bubblesort(List<string> input)
        {
            bool Swap = true;
            string temp;
            while (Swap == true)
            {
                Swap = false;
                for (int i = 1; i <= input.Count - 1; i++)
                {
                    if (string.Compare(input[i], input[i - 1]) < 0)
                    {
                        temp = input[i];
                        input[i] = input[i - 1];
                        input[i - 1] = temp;
                        Swap = true;
                    }
                }
            }
            return input;
        }

        public static List<string> mergsort(List<string> input)
        {
            if(input.Count <= 1)
                return input;

            List<string> left = new List<string>();
            List<string> right = new List<string>();
            for(int i = 0; i < input.Count; i++)
            {
                if(i < input.Count/2)
                    left.Add(input[i]);
                else
                    right.Add(input[i]);
            }

            left = mergsort(left);
            right = mergsort(right);

            return merge(left, right);
            
        }

        public static List<string> merge(List<string> left, List<string> right)
        {
            List<string> temp = new List<string>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (string.Compare(left[0], right[0]) < 0)
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            while (left.Count > 0)
            {
                temp.Add(left[0]);
                left.RemoveAt(0);
            }
            while(right.Count > 0)
            {
                temp.Add(right[0]);
                right.RemoveAt(0);
            }
            return temp;
        }


        public static object BinarySearch(List<string> input, string SearchTerm, int min, int max)
        {
            if (min > max)
                return -1;
            else
            {
                int mid = (min + max) / 2;
                if (String.Compare(SearchTerm, input[mid]) < 0)
                    return BinarySearch(input, SearchTerm, min, mid - 1);
                else if (string.Compare(SearchTerm, input[mid]) > 0)
                    return BinarySearch(input, SearchTerm, mid + 1, max);
                else
                    return mid;
            }
        }
    }
}
