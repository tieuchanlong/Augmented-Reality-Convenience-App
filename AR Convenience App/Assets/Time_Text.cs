using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Text : MonoBehaviour
{
    string JSON_Name;
    string JSON_Country;
    string JSON_Temperature;
    string JSON_Weather;
    string JSON_Time;
    string path;
    string Url;
    float temperature;
    public int StateWeather;
    public static string[] time_info;
    private static string[] furthertime_info;
    private float second = 0f;



    string Zero;
    WWW www;
    string url = "https://api.apixu.com/v1/current.json?key=84c61c16747d42baaac164809191307&q=" + ManageWeather.locations[ManageWeather.location];

    void Start() // Use this for initialization
    {
        www = new WWW(url);

    }

    // Update is called once per frame
    void Update()
    {
        string[] data = System.DateTime.Now.ToString().Split(new char[] { ' ' });
        string[] time = data[1].Split(new char[] { ':' });

        if (data[2] == "PM")
            time[0] = (int.Parse(time[0]) + 12).ToString();

        if (time[0].Length == 1)
            time[0] = '0' + time[0];

         GetComponent<TextMesh>().text = time[0] + ":" + time[1];

    }
}
