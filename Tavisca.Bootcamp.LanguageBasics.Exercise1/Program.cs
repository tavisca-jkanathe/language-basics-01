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
					if(A.ToString().Length!= nums[0].Length)
					{
						return -1;
					}
					else
					{
						int find = nums[0].IndexOf('?');
						string oldA = A.ToString();
						char result = oldA[find];
						String newA = nums[0].Replace('?',result);
						if(string.Equals(newA,oldA))
						{
							return int.Parse(result.ToString());
						}
                    else
						return -1;
					}
					
					
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
					if(B.ToString().Length!= nums[1].Length)
					{
						return -1;
					}
					else
					{
						int find = nums[1].IndexOf('?');
						string oldB = B.ToString();
						char result = oldB[find];
						String newB = nums[1].Replace('?',result);
						if(string.Equals(newB,oldB))
						{
							return int.Parse(result.ToString());
						}
                    else
						return -1;
					}
				}
				
			}
			
			else if(check==2)
			{
				int A = int.Parse(nums[0]);
				int B = int.Parse(nums[1]);
				int C=A*B;
				if(C.ToString().Length!= nums[2].Length)
					{
						return -1;
					}
				else
				{
					int find = nums[2].IndexOf('?');
						string oldC = C.ToString();
						char result = oldC[find];
						String newC = nums[2].Replace('?',result);
						if(string.Equals(newC,oldC))
						{
							return int.Parse(result.ToString());
						}
                    else
						return -1;
				}
				
			}
			else
				return -1;
            throw new NotImplementedException();
        }
    }
}
