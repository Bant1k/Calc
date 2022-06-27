using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputTextScript : MonoBehaviour
{

    bool isZero()
    {
        if (this.GetComponent<Text>().text == "0")
            return true;
        else
            return false;
    }


    /* old code
    //calculator line count
    double Calculate(string inpStr)
    {
        //variables for adding two numbers
        double f1 = Convert.ToDouble(inpStr.Substring(0, FindIndexOfAction(inpStr) - 1));
        double f2;
        //indexes of the previous and next action
        int indexOfAction;
        int indexOfNextAction;

        while (inpStr.Length!=0)
        {
            indexOfAction = FindIndexOfAction(inpStr);
            indexOfNextAction = FindIndexOfAction(inpStr.Substring(indexOfAction, inpStr.Length));



            //checking next action for multiplication or division
            if (inpStr[indexOfNextAction] == '/' && inpStr[indexOfNextAction] == '*')
            {
                f2 = Calculate(inpStr.Substring(indexOfAction + 1, inpStr.Length));

            }
            else
                f2 = Convert.ToDouble(inpStr.Substring(0, indexOfAction - 1));

            //counting based on action
            switch (inpStr[indexOfAction])
            {
                case '/':
                    f1 /= f2;
                    break;

                case '*':
                    f1 *= f2;
                    break;

                case '+':
                    f1 += f2;
                    break;

                case '-':
                    f1 -= f2;
                    break;
            }

            int indexOfLastMultipli = 0;
            bool removeFlag = true;
            while (removeFlag)
            {
                indexOfLastMultipli = FindIndexOfAction(inpStr.Substring((indexOfNextAction), inpStr.Length));
            }
        }

        return f1;
    }
    */

    //calculator line count
    double Calculate(string inpStr)
    {
        /*
            List<List<object>> list = new List<List<object>>(); //инициализация
            list.Add(new List<object>);//добавление новой строки
            list[0].Add("asd")//добавление столбца в новую строку
            list[0][0];//обращение к первому столбцу первой строки
        */

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
            switch (Convert.ToChar(digitsAndOperations[indexOfList-1][1]))
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

    /*old code
        int FindIndexOfAction(string inpStr)
    {
        return inpStr.IndexOfAny(new char[] { '+', '-', '/', '*' });
    }
    */

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeOutput(char characterToPush)
    {
        Text Output = this.GetComponent<Text>();

        switch (characterToPush)
        {
            case '0':

                if (isZero())
                    break;

                Output.text += '0';
                break;

            case '1':
                if(isZero())
                    Output.text = "1";
                else
                    Output.text += '1';
                break;

            case '2':
                if (isZero())
                    Output.text = "2";
                else
                    Output.text += '2';
                break;

            case '3':
                if (isZero())
                    Output.text = "3";
                else
                    Output.text += '3';
                break;

            case '4':
                if (isZero())
                    Output.text = "4";
                else
                    Output.text += '4';
                break;

            case '5':
                if (isZero())
                    Output.text = "5";
                else
                    Output.text += '5';
                break;

            case '6':
                if (isZero())
                    Output.text = "6";
                else
                    Output.text += '6';
                break;

            case '7':
                if (isZero())
                    Output.text = "7";
                else
                    Output.text += '7';
                break;

            case '8':
                if (isZero())
                    Output.text = "8";
                else
                    Output.text += '8';
                break;

            case '9':
                if (isZero())
                    Output.text = "9";
                else
                    Output.text += '9';
                break;

            case 'С':
                Output.text = "0";
                break;

            case ',':
                //есть ли в числе уже ','
                if ((Output.text.LastIndexOfAny(new char[] { '/', '*', '-', '+' }) == -1 && Output.text.Contains(",")) || 
                    (Output.text.LastIndexOfAny(new char[] { '/', '*', '-', '+' }) != -1 && Output.text.Substring(Output.text.LastIndexOfAny(new char[] { '/', '*', '-', '+' })).Contains(",")))
                        break;

                //если перед ',' нет никакой цифры добавляем 0
                if (Output.text.LastIndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }) != (Output.text[Output.text.Length - 1]))
                {
                    Output.text += '0';
                    Output.text += ',';
                }
                else
                    Output.text += ',';

                break;

            case '=':
                if (isZero() || Output.text == "-" || Output.text == "+" || Output.text == "/" || Output.text == "*")
                {
                    Output.text = "0";
                    break;
                }
                else
                {
                    Output.text = Convert.ToString(Calculate(Output.text));
                    break;
                }

            case '+':
                if (isZero() || Output.text == "-" || Output.text == "+" || Output.text == "/" || Output.text == "*")
                {
                    Output.text = "0";
                    break;
                }
                else
                {
                    if (Output.text[Output.text.Length - 1] == '-' || Output.text[Output.text.Length - 1] == '+' ||
                            Output.text[Output.text.Length - 1] == '/' || Output.text[Output.text.Length - 1] == '*')
                        Output.text = Output.text.Remove(Output.text.Length - 1);

                    Output.text += '+';
                }
                break;

            case '-':
                if (Output.text[Output.text.Length - 1] == '-' || Output.text[Output.text.Length - 1] == '+' ||
                            Output.text[Output.text.Length - 1] == '/' || Output.text[Output.text.Length - 1] == '*' || isZero())
                        Output.text = Output.text.Remove(Output.text.Length - 1);

                    Output.text += '-';
                break;

            case 'b':
                if (isZero())
                    break;
                else
                {
                    if (Output.text.Length == 1)
                        Output.text = "0";
                    else
                        Output.text = Output.text.Remove(Output.text.Length - 1);
                }
                    break;

            case '*':
                if (isZero() || Output.text == "-" || Output.text == "+" || Output.text == "/" || Output.text == "*")
                {
                    Output.text = "0";
                    break;
                }
                else
                {
                    if (Output.text[Output.text.Length - 1] == '-' || Output.text[Output.text.Length - 1] == '+' ||
                            Output.text[Output.text.Length - 1] == '/' || Output.text[Output.text.Length - 1] == '*')
                        Output.text = Output.text.Remove(Output.text.Length - 1);

                    Output.text += '*';
                }
                break;

            case '/':
                if (isZero() || Output.text == "-" || Output.text == "+" || Output.text == "/" || Output.text == "*")
                {
                    Output.text = "0";
                    break;
                }
                else
                {
                    if (Output.text[Output.text.Length - 1] == '-' || Output.text[Output.text.Length - 1] == '+' ||
                            Output.text[Output.text.Length - 1] == '/' || Output.text[Output.text.Length - 1] == '*')
                        Output.text = Output.text.Remove(Output.text.Length - 1);

                    Output.text += '/';
                }
                break;
                
                /* нахождение процента от числа
            case '%':
                if (isZero())
                    break;
                else
                    if (Output.text[Output.text.Length - 1] == '-' || Output.text[Output.text.Length - 1] == '+' ||
                            Output.text[Output.text.Length - 1] == '/' || Output.text[Output.text.Length - 1] == '*')
                    break;
                double buffer;
                int indexOfDigit = Output.text.LastIndexOfAny(new char[] { '+', '-', '/', '*' })+1;
                if (indexOfDigit-1 == -1)
                {
                    buffer = Convert.ToDouble(Output.text.Substring(0));
                    Output.text = Output.text.Remove(0);
                }
                else
                {
                        buffer = Convert.ToDouble(Output.text.Substring(indexOfDigit, (Output.text.Length - 1) - indexOfDigit));
                        Output.text = Output.text.Remove(indexOfDigit);
                }
                buffer /= 100.0; 
                Output.text += Convert.ToString(buffer);
                Debug.Log(buffer);
                break;
                */

            default:
                return false;

        }

        return true;
    }
}