using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;



namespace iris_classification
{
 
    public partial class Form1 : Form
    {

        int linecount = 150;
        double[,] inputarray;
        double Reward;
        double TrainingCorrect =0;
        int[] Answer;
        int currentPos = 0;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private double[] GetTarget (int _Answer, double[] result)
        {
            int ANNAnswer = -1;
            double[] Target = (double []) result.Clone();
            if (result[0] > result[1])
            {
                if (result[0] > result[2])
                {
                    ANNAnswer = 0;
                }
                else
                {
                    ANNAnswer = 2;
                }
            }
            else
                if (result[1] > result[2])
            {
                ANNAnswer = 1;
            }
            else
            {
                ANNAnswer = 2;
            }
        
           

            if (ANNAnswer == _Answer)
            {
                for (int A =0; A < Target.Count(); A++ )
                {
                    //Target[A] = 0;
                }
                Target[ANNAnswer] = 1;
                TrainingCorrect++;
            }
            else
            {
                Target[ANNAnswer] = 0;
                //Correct = 0;
            }
            

            return Target;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32( txtInput.Text);
            int hidden = Convert.ToInt32(txtHidden.Text);
            int output = Convert.ToInt32(txtOutputs.Text);
            double LearnRate = Convert.ToDouble(txtLearnRate.Text);
            string Enhanced = "S";
            TrainingCorrect = 0;
            if (chkEnhanced.CheckState == CheckState.Checked)
            {
                Enhanced = "E";
            }
            int repeat = Convert.ToInt32(txtRepeat.Text);

            RLPolicy learn = new RLPolicy(input,output, hidden, repeat, Enhanced,LearnRate);
            string fileName = "C:\\test.csv";
            int epochCount = Convert.ToInt32(txtEpochs.Text);


            using (StreamWriter writer = new StreamWriter(fileName))
            {


                for (int icount = 0; icount < epochCount; icount++)
                {
                    currentPos = rnd.Next(0, 150);

                    double[] feed = new double[4];
                    feed[0] = inputarray[currentPos, 0];
                    feed[1] = inputarray[currentPos, 1];
                    feed[2] = inputarray[currentPos, 2];
                    feed[3] = inputarray[currentPos, 3];

                    double[] result = learn.FeedForward(feed);


                    switch (Answer[currentPos])
                    {
                        case 1:
                            Reward = result[0];
                            break;

                        case 2:
                            Reward = result[1];
                            break;

                        case 3:
                            Reward = result[2];
                            break;

                    }

                    double[] Target = GetTarget(Answer[currentPos], result);

                    writer.Write(Target[0].ToString());
                    writer.Write(",");
                    writer.Write(Target[1].ToString());
                    writer.Write(",");
                    writer.Write(Target[2].ToString());
                    writer.Write(",");
                    writer.Write(result[0].ToString());
                    writer.Write(",");
                    writer.Write(result[1].ToString());
                    writer.Write(",");
                    writer.Write(result[2].ToString());
                    writer.Write(",");
                    writer.Write(TrainingCorrect.ToString());
                    writer.Write("\n");

                    learn.Learn(result, Answer[currentPos], Target, feed);
                }
            }
            double percorrect = (TrainingCorrect / epochCount)*100;
            txtCorrect.Text = percorrect.ToString() + "%";
        }

        private void LoadArray_Click(object sender, EventArgs e)
        {
            //this is where I am attempting to read from the .csv
            StreamReader LineData = new StreamReader(File.OpenRead("IrisData.csv"));
            inputarray = new double[linecount, 4];
            Answer = new int[linecount];
            try
            {

                
                

                for (int loop = 0; loop < linecount; loop++)
                {
                    string input = LineData.ReadLine();
                    string[] split = input.Split(',');
                    inputarray[loop, 0] = Convert.ToDouble(split[0]);
                    inputarray[loop, 1] = Convert.ToDouble(split[1]);
                    inputarray[loop, 2] = Convert.ToDouble(split[2]);
                    inputarray[loop, 3] = Convert.ToDouble(split[3]);

                    switch (split[4])
                    {
                        case "Iris-virginica":
                            Answer[loop] = 0;
                            break;

                        case "Iris-setosa":
                            Answer[loop] = 1;
                            break;

                        case "Iris-versicolor":
                            Answer[loop] = 2;
                            break;

                    }

                }

                      
     


        }
            catch (System.Exception)
        {
            MessageBox.Show("An error occured during the file read...","File Read Error");
        }
        finally
        {
                LineData.Close();
        }

        }

        
    }
}
