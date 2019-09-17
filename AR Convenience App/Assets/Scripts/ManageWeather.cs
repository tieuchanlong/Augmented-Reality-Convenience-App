using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageWeather : MonoBehaviour
{
    public static int location = 0;
    public static string[] locations = { "Edmonton", "Toronto", "Waterloo" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectEdmonton()
    {
        location = 0;
    }

    public void SelectToronto()
    {
        location = 1;
    }

    public void SelectWaterloo()
    {
        location = 2;
    }
}
