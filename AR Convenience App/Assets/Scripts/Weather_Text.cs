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
    string url = "http://api.openweathermap.org/data/2.5/weather?q=" + ManageWeather.locations[ManageWeather.location] + "&APPID=2249cec4e08c29433668be5504cc9dec";

    void Start() // Use this for initialization
    {
        StartCoroutine(WaitForRequest(www));
    }

    IEnumerator WaitForRequest(WWW www)
    {
        url = "http://api.openweathermap.org/data/2.5/weather?q=" + ManageWeather.locations[ManageWeather.location] + "&APPID=2249cec4e08c29433668be5504cc9dec";
        www = new WWW(url);
        yield return www;

        // check for errors
        if (www.error == null)
        {
            string work = www.text;

            _Particle fields = JsonUtility.FromJson<_Particle>(work);
            JSON_Name = fields.name;
            JSON_Country = fields.sys.country;
            /*JSON_Weather = fields.current.condition.text;
            JSON_Temperature = fields.current.temp_c;
            JSON_Time = fields.location.localtime;*/
            JSON_Temperature = (fields.main.temp - 271.23).ToString();
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
    public class _coord
    {
        public float lon;
        public float lat;

    }

    [System.Serializable]
    public class _weather
    {
        public int id;
        public string main;
        public string description;
        public string icon;
    }

    [System.Serializable]
    public class _main
    {
        public float temp;
        public float feels_like;
        public float temp_min;
        public float temp_max;
        public float pressure;
        public float humidity;
    }

    [System.Serializable]
    public class _wind
    {
        public float speed;
        public float deg;
    }

    [System.Serializable]
    public class _clouds
    {
        public string all;
    }

    [System.Serializable]
    public class _sys
    {
        public int type;
        public int id;
        public string country;
        public string sunrise;
        public string sunset;
    }


    [System.Serializable]
    public class _Particle
    {
        public _coord coord;
        public _weather weather;

        public string _base;

        public _main main;

        public int visibility;

        public _wind wind;

        public _clouds cloud;

        public string dt;

        public _sys sys;

        public string timezone;
        public int id;
        public string name;
        public float cod;


    }




}