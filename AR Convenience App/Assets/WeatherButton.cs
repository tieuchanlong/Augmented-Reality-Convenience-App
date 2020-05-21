using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class WeatherButton : MonoBehaviour
{
    public static int scene_state;
    public GameObject Weather;
    
    // Start is called before the first frame update
    void Start()
    {
        scene_state = 3;
    }


    public void ActivateWeather()
    {
        scene_state = 1;
        Debug.Log("Pressed");
    }

    // Update is called once per frame
    void Update()
    {
        if (scene_state == 1)
        {
            Weather.SetActive(true);
        }
        else
        {
            Weather.SetActive(false);
        }
    }
}
