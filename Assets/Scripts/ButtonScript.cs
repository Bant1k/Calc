using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Text name;
    public GameObject DigitsText;

    // Start is called before the first frame update
    private void Start()
    {   
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void OnPressed()
    {
        DigitsText.GetComponent<OutputTextScript>().ChangeOutput(name.text[0]);
        Debug.Log(name.text[0]);
    }
}
