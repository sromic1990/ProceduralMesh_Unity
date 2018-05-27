using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sourav.Utilities.Scripts.Algoritms.Randomization
{
    public class RandomizationDither
    {
        private static List<int> OutputList;

        private static void Dither(int numberOfIterations, List<int> LikelihoodList)
        {
            //Initialization
            List<int> tempOutputList = new List<int>();
            List<int> probabilityList = new List<int>(LikelihoodList.Count);
            int sum = 0;
            for (int i = 0; i < LikelihoodList.Count; i++)
            {
                probabilityList.Add(0);
                sum += LikelihoodList[i];
            }

            //Algorithm
            for (int i = 0; i < numberOfIterations; i++)
            {
                int maxIndex = 0;
                int max = 0;
                for (int j = 0; j < probabilityList.Count; j++)
                {
                    probabilityList[j] += LikelihoodList[j];
                    if (probabilityList[j] > max)
                    {
                        maxIndex = j;
                        max = probabilityList[j];
                    }
                }
                tempOutputList.Add(maxIndex);
                probabilityList[maxIndex] = probabilityList[maxIndex] - sum;
            }

            //Send for Shuffle
            Shuffle(tempOutputList);
        }

        private static void Shuffle(List<int> tempOutputList)
        {
            int randomIteration = (int)Random.Range(0, (tempOutputList.Count + 1));

            List<int> alreadyTampered = new List<int>();

            for (int i = 0; i < randomIteration; i++)
            {
                int randomStart = 0;
                int randomEnd = 0;

                do
                {
                    randomStart = Random.Range(0, tempOutputList.Count);
                    randomEnd = Random.Range(0, tempOutputList.Count);
                }
                while (randomStart == randomEnd);

                if (alreadyTampered.Contains(randomStart) || alreadyTampered.Contains(randomEnd))
                {
                    continue;
                }

                tempOutputList[randomStart] += tempOutputList[randomEnd];
                tempOutputList[randomEnd] = tempOutputList[randomStart] - tempOutputList[randomEnd];
                tempOutputList[randomStart] = tempOutputList[randomStart] - tempOutputList[randomEnd];
            }

            OutputList = tempOutputList;
        }

        public static List<int> Generate(int numberOfGenaration, List<int> LikelihoodList)
        {
            OutputList = new List<int>();

            Dither(numberOfGenaration, LikelihoodList);

            return OutputList;
        }
    }
}
