using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ActivateAlarm()
    {
        WeatherButton.scene_state = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
