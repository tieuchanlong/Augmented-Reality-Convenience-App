using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Weather_Text : MonoBehaviour
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



    string Zero;
    WWW www;
    string url = "https://api.apixu.com/v1/current.json?key=84c61c16747d42baaac164809191307&q=" + ManageWeather.locations[ManageWeather.location];

    void Start() // Use this for initialization
    {
        StartCoroutine(WaitForRequest(www));



    }

    IEnumerator WaitForRequest(WWW www)
    {
        url = "https://api.apixu.com/v1/current.json?key=84c61c16747d42baaac164809191307&q=" + ManageWeather.locations[ManageWeather.location];
        www = new WWW(url);
        yield return www;

        // check for errors
        if (www.error == null)
        {
            string work = www.text;

            _Particle fields = JsonUtility.FromJson<_Particle>(work);
            JSON_Name = fields.location.name;
            JSON_Country = fields.location.country;
            JSON_Weather = fields.current.condition.text;
            JSON_Temperature = fields.current.temp_c;
            JSON_Time = fields.location.localtime;
            temperature = float.Parse(JSON_Temperature);
            Debug.Log(JSON_Name);
            Debug.Log(JSON_Country);
            Debug.Log(JSON_Weather);
            Debug.Log(JSON_Temperature);
            Debug.Log(JSON_Time);
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(WaitForRequest(www));

        GetComponent<TextMesh>().text = temperature.ToString("f0") + "° C " + "in \n " + JSON_Name + ",\n " + JSON_Country;
        if (JSON_Weather == "Overcast" || JSON_Weather == "Partly cloudy")
        {
            StateWeather = 5;
            Debug.Log(StateWeather);
        }
        else if (JSON_Weather == "Sunny")
        {
            StateWeather = 3;
            Debug.Log(StateWeather);
        }
        else if (JSON_Weather == "Clear")
        {
            StateWeather = 2;
            Debug.Log(StateWeather);
        }


    }


    [System.Serializable]
    public class _condition
    {
        public string text;

    }

    [System.Serializable]
    public class _location
    {
        public string name;
        public string country;
        public string localtime;
    }

    [System.Serializable]
    public class _current
    {
        public _condition condition;
        public string temp_c;

    }


    [System.Serializable]
    public class _Particle
    {
        public _condition condition;
        public _location location;
        public _current current;
        public string temp;
        public string main;
    }




}