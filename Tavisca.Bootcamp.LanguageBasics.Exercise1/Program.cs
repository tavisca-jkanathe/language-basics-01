using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
	// To find and replace the digit and then to check whether it is valid or not
	public static int findMissing(int number,int position, String[] nums)
        {
            if(number.ToString().Length!= nums[position].Length)
					{
						return -1;
					}
					else
					{
						int find = nums[position].IndexOf('?');
						string oldA = number.ToString();
						char result = oldA[find];
						String newA = nums[position].Replace('?',result);
						if(string.Equals(newA,oldA))
						{
							return int.Parse(result.ToString());
						}
                   	    else
						return -1;
					}
        }
        
        public static int FindDigit(string equation)
        {
            // Add your code here.
            char[]  splitchars = new char[2]{'*','='};
            String[] nums=equation.Split(splitchars);
            int check=-1;
            for(int i=0;i<=2;i++)  
            {
                if(nums[i].Contains("?"))
                {
                    check=i;
					break;
                }
			}
			if(check==0)
			{
				int B = int.Parse(nums[1]);
				int C = int.Parse(nums[2]);
				if(C%B!=0)
				{
					return -1;
				}
				else
				{
					
					int A=C/B;
					return findMissing(A, 0, nums);
					
					
				}
				
			}
			else if(check==1)
			{
				int A = int.Parse(nums[0]);
				int C = int.Parse(nums[2]);
				if(C%A!=0)
				{
					return -1;
				}
				else
				{
					int B=C/A;
					return findMissing(B, 1, nums);
				}
				
			}
			
			else if(check==2)
			{
				int A = int.Parse(nums[0]);
				int B = int.Parse(nums[1]);
				int C=A*B;
				return findMissing(C, 2, nums);
				
			}
			else
				return -1;
        }
    }
}
