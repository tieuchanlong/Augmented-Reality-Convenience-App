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
    string url = "https://api.apixu.com/v1/current.json?key=84c61c16747d42baaac164809191307&q=Edmonton";

    void Start() // Use this for initialization
    {
        www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

    }

    IEnumerator WaitForRequest(WWW www)
    {
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
        second += Time.deltaTime;
        time_info = JSON_Time.Split(char.Parse(" "));
        furthertime_info = time_info[1].Split(char.Parse(":"));
        int hour, minute;
        int.TryParse(furthertime_info[0], out hour);
        int.TryParse(furthertime_info[1], out minute);

        if (second >= 60)
        {
            minute += 1;

            if (minute >= 60)
            {
                minute = 0;
                hour += 1;

                if (hour >= 24)
                {
                    hour = 0;
                }
            }
        }

        Debug.Log(hour + " " + minute + " " + second);

        if (hour < 10)
        {
            furthertime_info[0] = "0" + hour.ToString();
        }
        else
        {
            furthertime_info[0] = hour.ToString();
        }

        if (minute < 10)
        {
            furthertime_info[1] = "0" + minute.ToString();
        }
        else
        {
            furthertime_info[1] = minute.ToString();
        }

        time_info[1] = furthertime_info[0] + ":" + furthertime_info[1];

        GetComponent<TextMesh>().text = time_info[1];

    }

    void UpdateTime()
    {
        www = new WWW(url);
        StartCoroutine(WaitForRequest(www));
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
