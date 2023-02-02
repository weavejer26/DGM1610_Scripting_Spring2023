using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conditionals : MonoBehaviour
{
    public string weather = "clear";
    int time = 304;
    bool isStopLightRed = true;
    float gpa = 3.25f;
    double temperature = 101.45d;
   
    
    // Start is called before the first frame update
    void Start()
    {
        //Check Time
       if(time >= 200) 
       {
            Debug.Log("Rise and Shine!");
       }
       else
       {
            Debug.Log("Its too early go back to bed!");
       }
        //Check Weather
        if(weather == "cloudy")
        {
            Debug.Log("It is cloudy outside");
        }
        else if (weather == "raining")
        {
            Debug.Log("It is raining outside!");
        }
        else if (weather == "Clear")
        {
            Debug.Log("It is a beautiful day outside!");
        }
        else if(weather == "ThunderandLightning")
        {
            Debug.Log("There is thunder and lightning outside, stay indoors!!!");
        }
        else if (weather == "Snowing")
        {
            Debug.Log("It is snowing outside, bundle up it is cold!");
        }
        else if (weather =="Hail")
        {
            Debug.Log("There is hail falling outside, quickly get to cover!");
        }
        else
        {
            Debug.Log("Do what you want! Its a day!");
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
