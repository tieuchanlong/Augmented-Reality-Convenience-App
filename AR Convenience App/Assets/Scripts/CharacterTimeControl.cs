using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTimeControl : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 5f;
    public GameObject handle;

    public Animator charanimation;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            charanimation.SetFloat("Speed", 1f);
        }
        else
        {
            charanimation.SetFloat("Speed", 0f);
        }
        rigidbody.velocity = new Vector3(joystick.Horizontal * speed, rigidbody.velocity.y, joystick.Vertical * speed);

        float x = joystick.Horizontal;
        float z = joystick.Vertical;

        if (joystick.Horizontal == 0) x = transform.localScale.x;
        if (joystick.Vertical == 0) z = transform.localScale.z;

        transform.localRotation = Quaternion.Euler(transform.localRotation.x, handle.GetComponent<RectTransform>().position.x, transform.localRotation.z);
    }
}
