using System;

using PerceptronHillClimberLibrary;

namespace ANDGatePerceptron
{
    public class Program
    {
        public static double MeanSquaredError(double output, double desiredOutput)
        {
            return Math.Pow((desiredOutput - output), 2);
        }

        public static (double[][] inputs, double[] outputs) AndInOut()
        {
            double[][] inputs = new double[][] { new double[] { 0, 0 }, new double[] { 1, 0 }, new double[] { 0, 1 }, new double[] { 1, 1 } };
            double[] outputs = new double[] { -1, -1, 0, 1 };
            return (inputs, outputs);
        }

        static void Main(string[] args)
        {
            Random random = new Random();

            //creating a perceptron
            Perceptron gate = new Perceptron(2, 0.001, random, MeanSquaredError);

            //Setting random values for our weights and bias
            gate.Randomize(random, -1, 1);

            (double[][] inputs, double[] outputs) = AndInOut();
            double currentError = gate.GetError(inputs, outputs);
            //while (currentError > 0)
            //{
            //    currentError = gate.TrainWithHillClimbing(inputs, outputs, currentError);
            //}

            while (currentError > 0)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < inputs.Length; i++)
                {
                    Console.Write("Inputs: ");
                    for (int j = 0; j < inputs[i].Length; j++)
                    {
                        if (j != 0)
                        {
                            Console.Write(", ");
                        }
                        Console.Write(inputs[i][j]);
                    }

                    Console.Write(" Output: " + Math.Round(gate.Compute(inputs[i]), 3));
                    Console.WriteLine();
                }
                Console.WriteLine("Error: " + Math.Round(currentError, 3));
                currentError = gate.TrainWithHillClimbing(inputs, outputs, currentError);
            }

            Console.WriteLine("Final Error: " + Math.Round(currentError, 3));
            currentError = gate.TrainWithHillClimbing(inputs, outputs, currentError);

            Console.WriteLine(gate.Compute(inputs));
            Console.WriteLine("Complete");
            //write the four test cases and train perceptron until it's right
        }
    }
}
