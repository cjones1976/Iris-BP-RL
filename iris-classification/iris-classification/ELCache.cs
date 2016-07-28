using System;
//using System.Collections.Generic;
using System.Linq;

using System.Diagnostics;

using System.Collections.Generic;


namespace iris_classification
{
    class ELCache
    {

        public double DecayRate = 0.0005;
        int CacheSize;
        int Postcachesize;
        public int EnhancedLearning = 0;

        double NewLearnRate;
        double NewLearnRateLimit;
        double InvestigationRate;
        double InvestigationRateReset;
        
        double HighError;
        public int LowPos;
        public int HighPos;
        int ELResetRate;
        private PastData LastEntry;

        private Random RND = new Random();

        List<PastData> PreviousData = new List<PastData>();



        public ELCache()
        { }

        public ELCache(int _CachSize, int _EnhancedLearning, double _LearnRate, double _InvestigationRate)
        {
            CacheSize = _CachSize;
            Postcachesize = CacheSize * 4;
            PreviousData.Clear();
            EnhancedLearning = _EnhancedLearning;
            NewLearnRate = _LearnRate;
            NewLearnRateLimit = _LearnRate;
            InvestigationRate = _InvestigationRate;
            InvestigationRateReset = _InvestigationRate;
            ELResetRate = _EnhancedLearning;
        }

        public double GetPreviousAverage()
        {
            return HighError;
        }

       public bool UpdateTraining(bool  Learning, double TotalError)
       {
             //PreviousAverageValue = EnhancedLearning.GetPreviousAverage();
           if (EnhancedLearning < 1)
           {
               CacheSize = Postcachesize; 
               Learning = UpdateLearnRate(Learning, TotalError);
           }
                
           return Learning;
       }

        public bool UpdateLearnRate(Boolean Learning, double TotalError)
        {

           
            if (HighError < TotalError)
            {
                //Current Error More Need to Learn and be More Random
                if (Learning & InvestigationRate >= InvestigationRateReset)
                {
                    NewLearnRate = NewLearnRateLimit;
                    InvestigationRate = InvestigationRateReset;
                }
                else
                {
                    NewLearnRate = NewLearnRateLimit;
                    InvestigationRate = InvestigationRateReset;
                    PreviousData.Add(LastEntry);
                    PreviousData.RemoveAt(0);


                }

            }
            else
            {
                NewLearnRate = Math.Abs(NewLearnRate - (NewLearnRate * DecayRate));
                InvestigationRate = Math.Abs(InvestigationRate + (InvestigationRate/10 * DecayRate));

            }

            if (InvestigationRate > 99.5)
            {
                InvestigationRate = 100;
                NewLearnRate = 0;
                Learning = false;
            }
            else
            {
                Learning = true;
            }


            return Learning;
        }

        public ANN CacheLearn(PastData NewEntry, ANN Net)
        {
            double LowError = double.MaxValue;
            HighError = double.MinValue;
            LowPos = -1;
            HighPos = -1;

            LastEntry = NewEntry;

                PreviousData.Add(NewEntry);


            for (int a = 0; a < PreviousData.Count(); a++)
            {
                double ErrorLevel = 0;
              
                double[] NewInput = PreviousData[a].GetInput();


                int iAction = PreviousData[a].GetAction();
                double SingleTarget = PreviousData[a].GetTarget(iAction);
                double[] result = Net.feedForward(NewInput);
                double[] NewTarget = (double[])result.Clone();
                NewTarget[iAction] = SingleTarget;
            
                if (EnhancedLearning > 0)
                {
                    Net.Learn(NewTarget, result, NewLearnRate);
                    //EnhancedLearn(iAction, Net, NewInput, SingleTarget);
                }
                ErrorLevel = Net.LearnError(NewTarget, result, iAction);
   
 
                if (ErrorLevel < LowError)
                {

                    LowError = ErrorLevel;
                    LowPos = a;

                }
                if (ErrorLevel > HighError)
                {
                    HighError = ErrorLevel;
                    HighPos = a;
                }

            }

   
           
            if (EnhancedLearning > 0) { EnhancedLearning--; }

            return Net;
        }

        public ANN UpdateCache(ANN Net)
        {
            int count = PreviousData.Count;


            if (count > 2)
            {

                
                int Pos = HighPos;
                double[] NewInput = PreviousData[Pos].GetInput();

                int iAction = PreviousData[Pos].GetAction();
                double SingleTarget = PreviousData[Pos].GetTarget(iAction);

                double SetLevel = HighError * 0.9;
                double ErrorLevel;
                int CheckCount = 50;
                do
                {
                    double[] result = Net.feedForward(NewInput);
                    double[] NewTarget = (double[])result.Clone();
                    NewTarget[iAction] = SingleTarget;


                    Net.Learn(NewTarget, result, NewLearnRate);
                    CheckCount--;
                    ErrorLevel = Net.LearnError(NewTarget, result, iAction);


                } while (ErrorLevel > SetLevel & CheckCount > 0);

                if (count > CacheSize)
                {

                    PreviousData.RemoveAt(LowPos);
                }


            }
            

            return Net;
        }

        public void EnhancedLearn(int iAction,ANN Net,double[] NewInput, double SingleTarget)
        {
            double SetLevel = HighError * 0.9;
            double ErrorLevel;
            int CheckCount = 50;
            do
            {
                double[] result = Net.feedForward(NewInput);
                double[] NewTarget = (double[])result.Clone();
                NewTarget[iAction] = SingleTarget;


                Net.Learn(NewTarget, result, NewLearnRate);
                CheckCount--;
                ErrorLevel = Net.LearnError(NewTarget, result, iAction);


            } while (ErrorLevel > SetLevel & CheckCount > 0);
        }

        public int CacheCount()
        {
            return PreviousData.Count;
        }

       

        public double GetLearnRate()
        {
            return NewLearnRate;
        }
        public double GetInvestigationRate()
        {
            return InvestigationRate;
        }
     
    }
}
