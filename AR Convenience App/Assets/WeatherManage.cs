using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManage : MonoBehaviour
{
    public GameObject Weather;
    public GameObject UnityChan;
    public GameObject Time;
    public GameObject Alarm;
    public GameObject AlarmBtns;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WeatherButton.scene_state == 1) Weather.SetActive(true);
        if (WeatherButton.scene_state != 1) Weather.SetActive(false);
        if (WeatherButton.scene_state == 3) UnityChan.SetActive(true);
        if (WeatherButton.scene_state != 3) UnityChan.SetActive(false);
        if (WeatherButton.scene_state == 3) Time.SetActive(true);
        if (WeatherButton.scene_state != 3) Time.SetActive(false);
        if (WeatherButton.scene_state == 4)
        {
            Alarm.SetActive(true);
            AlarmBtns.SetActive(true);
        }
        if (WeatherButton.scene_state != 4)
        {
            Alarm.SetActive(false);
            AlarmBtns.SetActive(false);
        }
    }
}
