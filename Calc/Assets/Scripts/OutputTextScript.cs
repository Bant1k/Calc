using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutputTextScript : MonoBehaviour
{
    //написать сам калькулятор(преобразование числа)

    bool isZero()
    {
        if (this.GetComponent<Text>().text == "0")
            return true;
        else
            return false;
    }

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
                if (Output.text.Contains(","))
                    break;

                Output.text += ',';
                break;

                //дописать преобразования текста
            case '=':
                if (isZero())
                    break;
                else
                    break;

            case '+':
                if (isZero())
                    break;
                else
                    break;

            case '-':
                if (isZero())
                    break;
                else
                    break;

            case 'b':
                if (isZero())
                    break;
                else
                    break;

            case '*':
                if (isZero())
                    break;
                else
                    break;

            case '/':
                if (isZero())
                    break;
                else
                    break;

            case '%':
                if (isZero())
                    break;
                else
                    break;

            default:
                return false;
                break;

        }

        return true;
    }
}