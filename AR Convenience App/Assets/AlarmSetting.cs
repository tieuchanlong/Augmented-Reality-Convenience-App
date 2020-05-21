using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmSetting : MonoBehaviour
{
    public GameObject HourObject;
    public GameObject MinuteObject;
    public GameObject Alarm;
    public GameObject AlarmReminder;
    public GameObject ReminderHourObject;
    public GameObject ReminderMinuteObject;
    public Text VoiceCommand;

    private int hour = 0;
    private int minute = 0;
    private string hourdig;
    private string minutedig;
    private bool AlarmOn;

    // Start is called before the first frame update
    void Start()
    {
        AlarmOn = false;
    }

    public void HourUpButton()
    {
        hour += 1;
        if (hour == 24) hour = 0;
        if (hour < 10)
        {
            HourObject.GetComponent<TextMesh>().text = "0" + hour.ToString();
            ReminderHourObject.GetComponent<TextMesh>().text = "0" + hour.ToString();
        }
        else
        {
            HourObject.GetComponent<TextMesh>().text = hour.ToString();
            ReminderHourObject.GetComponent<TextMesh>().text = hour.ToString();
        }
    }

    public void HourDownButton()
    {
        hour -= 1;
        if (hour == -1) hour = 23;
        if (hour < 10)
        {
            HourObject.GetComponent<TextMesh>().text = "0" + hour.ToString();
            ReminderHourObject.GetComponent<TextMesh>().text = "0" + hour.ToString();
        }
        else
        {
            HourObject.GetComponent<TextMesh>().text = hour.ToString();
            ReminderHourObject.GetComponent<TextMesh>().text = hour.ToString();
        }
    }

    public void MinuteUpButton()
    {
        minute += 1;
        if (minute == 24) minute = 0;
        if (minute < 10)
        {
            MinuteObject.GetComponent<TextMesh>().text = "0" + minute.ToString();
            ReminderMinuteObject.GetComponent<TextMesh>().text = "0" + minute.ToString();
        }
        else
        {
            MinuteObject.GetComponent<TextMesh>().text = minute.ToString();
            ReminderMinuteObject.GetComponent<TextMesh>().text = minute.ToString();
        }
    }

    public void MinuteDownButton()
    {
        minute -= 1;
        if (minute == -1) minute = 59;
        if (minute < 10)
        {
            MinuteObject.GetComponent<TextMesh>().text = "0" + minute.ToString();
            ReminderMinuteObject.GetComponent<TextMesh>().text = "0" + minute.ToString();
        }
        else
        {
            MinuteObject.GetComponent<TextMesh>().text = minute.ToString();
            ReminderMinuteObject.GetComponent<TextMesh>().text = minute.ToString();
        }
    }

    public void SetAlarm()
    {
        AlarmOn = true;
    }

    public void TurnOffAlarm()
    {
        if (VoiceCommand.text.Contains("off") && VoiceCommand.text.Contains("alarm"))
        {
            AlarmOn = false;
            VoiceCommand.text = "None";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hour < 10) hourdig = "0" + hour.ToString();
        else hourdig = hour.ToString();

        if (minute < 10) minutedig = "0" + minute.ToString();
        else minutedig = minute.ToString();

        string[] data = System.DateTime.Now.ToString().Split(new char[] { ' '});
        string[] time = data[1].Split(new char[] { ':' });

        if (time[0].Length == 1)
            time[0] = '0' + time[0];

        if (hourdig + ":" + minutedig == time[0] + time[1] && AlarmOn == true)
        {
            Alarm.SetActive(true);
        }
        else Alarm.SetActive(false);

        if (AlarmOn == true) AlarmReminder.SetActive(true);
        else AlarmReminder.SetActive(false);

        TurnOffAlarm();
    }
}
