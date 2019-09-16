using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;

public class CharacterTimeControl : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 5f;
    public GameObject handle;

    public Animator charanimation;
    private Vector3 m_Move;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        /*if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            charanimation.SetFloat("Speed", 1f);
        }
        else
        {
            charanimation.SetFloat("Speed", 0f);
        }*/

        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        Debug.Log(v + " " + h);

        m_Move = v * Vector3.forward * speed + h * Vector3.right * speed;
        GetComponent<ThirdPersonCharacter>().Move(m_Move, false, false);
        

    }
}
