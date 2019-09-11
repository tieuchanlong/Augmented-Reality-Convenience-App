using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void ActivateTime()
    {
        WeatherButton.scene_state = 3;
    }

    void Update()
    {

    }
}
