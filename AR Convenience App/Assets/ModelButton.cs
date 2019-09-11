using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ModelButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void ActivateModel()
    {
        WeatherButton.scene_state = 2;
    }

    void Update()
    {

    }
}
