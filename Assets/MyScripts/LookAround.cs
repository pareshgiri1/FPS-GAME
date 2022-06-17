using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public Transform Player, lookRoot;
    public float sensivity = 5;
    //public float Roll_Angle = 10f;
    public Vector2 default_look_limit = new Vector2 (-40f,80f);
    private Vector2 look_Angles;
    public Vector2 current_Mouse_Look;
    public Transform bullet;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

        LookAround1();
        
    }

    void LookAround1()
    {

        current_Mouse_Look = new Vector2( Input.GetAxis(MouseAxis.MOUSE_Y), Input.GetAxis(MouseAxis.MOUSE_X));

        look_Angles.x -= current_Mouse_Look.x * sensivity;
        look_Angles.y += current_Mouse_Look.y * sensivity;

        look_Angles.x = Mathf.Clamp(look_Angles.x,default_look_limit.x, default_look_limit.y);

        lookRoot.localRotation = Quaternion.Euler(look_Angles.x, look_Angles.y, 0f);
        Player.localRotation   = Quaternion.Euler(0f, look_Angles.y, 0f);
        bullet.localRotation = Quaternion.Euler(look_Angles.x,0, 0f);
    }
}
