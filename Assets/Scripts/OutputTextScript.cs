using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputTextScript : MonoBehaviour
{

    private bool isZero()
    {
        if (this.GetComponent<Text>().text == "0")
            return true;
        else
            return false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
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
                    Output.text = Convert.ToString(this.GetComponent<Calculate>().CalculateOutput(Output.text));
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