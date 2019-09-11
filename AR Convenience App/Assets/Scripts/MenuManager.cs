using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool openmenu = false;
    public GameObject Menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Menu.SetActive(openmenu);
    }

    public void OpenMenu()
    {
        openmenu = !openmenu;
    }
}
