using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculate : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public double CalculateOutput(string inpStr)
    {

        //list of operators and digits (mas[next_operator][this_digit])
        List<List<string>> digitsAndOperations = new List<List<string>>();

        //временная переменная для чисел
        string[] doubles = inpStr.Split(new char[] { '+', '-', '/', '*' });

        int indexOfList = 0;
        int indexOfDoubles = 0;

        //fill massive of strings
        for (int i = 0; i < inpStr.Length; i++)
        {
            //нахождение операторов и заполнение всех данных в массив
            if (inpStr[i] == '+' || inpStr[i] == '-' || inpStr[i] == '*' || inpStr[i] == '/')
            {
                //проверка на первое отрицательное
                if (i == 0 && inpStr[i] == '-')
                {
                    doubles[indexOfDoubles] = "0";
                }

                digitsAndOperations.Add(new List<string>());


                digitsAndOperations[indexOfList].Add(doubles[indexOfDoubles]);
                digitsAndOperations[indexOfList].Add(Convert.ToString(inpStr[i]));

                indexOfList++;
                indexOfDoubles++;
            }

        }

        //add one more pair of digit and void operator
        digitsAndOperations.Add(new List<string>());
        digitsAndOperations[indexOfList].Add(doubles[indexOfDoubles]);
        digitsAndOperations[indexOfList].Add(" ");

        double result = Convert.ToDouble(digitsAndOperations[0][0]);
        double d2 = Convert.ToDouble(digitsAndOperations[1][0]);
        int counter;

        //if many multiply find it and do it all while not some else
        for (indexOfList = 1; indexOfList < digitsAndOperations.Count; indexOfList++)
        {
            counter = 0;
            while (digitsAndOperations[indexOfList][1] == "/" || digitsAndOperations[indexOfList][1] == "*")
            {
                if (digitsAndOperations[indexOfList][1] == "/")
                    d2 = Convert.ToDouble(digitsAndOperations[indexOfList][0]) / Convert.ToDouble(digitsAndOperations[indexOfList + 1][0]);

                if (digitsAndOperations[indexOfList][1] == "*")
                    d2 = Convert.ToDouble(digitsAndOperations[indexOfList][0]) * Convert.ToDouble(digitsAndOperations[indexOfList + 1][0]);

                indexOfList++;
                counter++;
            }

            //проверка на вход в цикл
            if (counter == 0)
                d2 = Convert.ToDouble(digitsAndOperations[indexOfList][0]);

            indexOfList -= counter;


            //serch operation and do it
            switch (Convert.ToChar(digitsAndOperations[indexOfList - 1][1]))
            {
                case '+':
                    result += d2;
                    break;

                case '-':
                    result -= d2;
                    break;

                case '*':
                    result *= d2;
                    break;

                case '/':
                    result /= d2;
                    break;

                default:
                    break;
            }
            indexOfList += counter;
        }

        return result;
    }
}
