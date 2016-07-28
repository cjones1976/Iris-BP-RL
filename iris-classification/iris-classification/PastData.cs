using System;
using System.Linq;


namespace iris_classification
{
    class PastData
    {
         double[] Target;
         double[] Result;
         public double errorlevel;
         int Action;
         double [] Input;
         int iAge;
         int Arraysize;
    
        public bool DeleteMe = false;

        public PastData() { }

        public PastData(double [] _Target, double[] _Result, int _Action, Random _RND,  double _Error, double [] _inputs)
        {
            Target = _Target;
            Result = _Result;
            Action = _Action;
            Input = _inputs;
            Arraysize = 5;
            iAge = _RND.Next(1, 4000);
          
            errorlevel = _Error;
       
        }

        public bool CompareInputs(double [] OtherInput)
        {
            bool tempFlag = true;
            double temp;
            
            for (int icount = 0; icount < Arraysize; icount++)
            {
                temp = Math.Abs( OtherInput[icount] - Input[icount]);

                if (temp > 0.1f)
                {
                    tempFlag = false;
                    break;
                }


            }

            return tempFlag;
        }

        public double[] GetInput()
        {
            return Input;
        }

        public int GetAction()
        {
            return Action;
        }
        public double GetTarget(int a)
        {
            return Target[a];
        }

        public void Age(int a)
        {
            iAge -= a;
            if (iAge < 0)
            {
                DeleteMe = true;
            }
        }

        
        public void SetTarget(double[] _Target)
        {
            Target = _Target;
        }

    }
}
