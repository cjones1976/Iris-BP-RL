using System;
//using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;



namespace iris_classification
{

    public class RLPolicy
    {

        ANN Net;
        ELCache EnhancedLearning = new ELCache();
        int inputCount = 0;
        int OutputCount = 0;
    
        public int Training = 1;
        public int ReinforcementCount = 0;

        NetworkParse[] NetWorkInit;
        //Reporter ReportTrainingCSV;
     
        public long WriteCount;

        double Distance = 0;
        public double PreviousAverageValue;
        bool Learning = true;
        public int TrackID = 0;
        Boolean DoEnhancedLearning = false;

 
        public bool Reset = false;
        

        Random RND = new Random();


        public double NewLearnRate = 0.3D;
        public double InvestigationRate = 90;



        public RLPolicy(int _Input, int _Output, int _HL, int ERun, string LearnType, double _LearnRate)
        {

         
                 NetWorkInit = new NetworkParse[3];
           // ReportTrainingCSV = new Reporter(_HL, Letter, LearnType, ERun);

           // int HiddenLayerSize = _Input / 3 * 2 + _Output;
            int HiddenLayerSize = _HL;
            NewLearnRate = _LearnRate;
            NetWorkInit[0] = new NetworkParse(_Input, HiddenLayerSize, "INPUT", true, "None");
            NetWorkInit[1] = new NetworkParse(HiddenLayerSize, _Output, "HIDDEN", true, "Sigmoid");
            NetWorkInit[2] = new NetworkParse(_Output, _Output, "OUTPUT", false, "Sigmoid");
       
            
            double [] temp = new double[_Output];
            if (LearnType == "E") { DoEnhancedLearning = true;}
         

           
            inputCount = _Input;
            OutputCount = _Output;

            Net = new ANN(NetWorkInit, NewLearnRate);
        
            double [] inputCode = new double[inputCount];
            double [] result = new double[OutputCount];
        
            EnhancedLearning = new ELCache(50, ERun, NewLearnRate, InvestigationRate);
        
            
        }


        public int CacheCount()
        {
            return EnhancedLearning.CacheCount();
        }





        public void Learn(double[] MainResult, int Action, double [] Target, double [] inputs)
        {

            

       
      
            double TotalError = 0;
      

            

     

                TotalError = Net.LearnError(Target, MainResult, Action);

                if (Learning)
                {   
                    
                    // new Learn System
                    if (DoEnhancedLearning)
                    {

                        Net = EnhancedLearning.CacheLearn(new PastData(Target, MainResult, Action,RND, TotalError, inputs), Net);
                        Net = EnhancedLearning.UpdateCache(Net);
                    }
                    else
                    {


                        // normal Learn
                        Net.Learn(Target, MainResult, NewLearnRate);
                    }
                }

                if (DoEnhancedLearning)
                {
                    NewLearnRate = EnhancedLearning.GetLearnRate();
                    InvestigationRate = EnhancedLearning.GetInvestigationRate();
                    Learning = EnhancedLearning.UpdateTraining(Learning, TotalError);

                }       
                

              
           



            //ReportTrainingCSV.WriteErrorRate(TotalError, _LapCount, NewLearnRate, InvestigationRate, _reward, TrackID, EnhancedLearning.CacheCount(), EnhancedLearning.GetPreviousAverage(), EnhancedLearning.EnhancedLearning, Distance, EnhancedLearning.HighPos, EnhancedLearning.LowPos, CarSpeed, Net.LearnCount);
        }

       
       
 
   
    

        public int GetBestAction(double[] temp)
        {

        
            int TopActionID = 0;
            double TopActionVAlue = temp[0];
            for (int icount = 1; icount < temp.Count(); icount++)
            {
               
                if (temp[icount] > TopActionVAlue)
                {
                    TopActionID = icount;
                    TopActionVAlue = temp[icount];
                }


            }

         

            if (Learning)
            {
                
                if (RND.Next(0, 100) > InvestigationRate)
                {
                    TopActionID = RND.Next(0, OutputCount);
                }

            }
            return TopActionID;

        }

        public double[] FeedForward(double[] ID)
        {

            double[] temp;
            //temp = NetManager.GetSpecificActions(method, dataSet, ID);


            temp = Net.feedForward(ID);

            return temp;

        }

        public void CloseFile()
        {
            //ReportTrainingCSV.Close();
        }
 




       

    }
}



