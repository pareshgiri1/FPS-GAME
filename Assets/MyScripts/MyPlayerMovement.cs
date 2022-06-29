using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MyPlayerMovement : MonoBehaviour
{
    public static MyPlayerMovement instance;
    public CharacterController character;
    public float speed = 5;
    float VerticalInput ;
    float HorizontalInput;
    public float health;
    public TextMeshProUGUI HealthText;


    public Image endScreen;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        health = 100;
        endScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        VerticalInput = Input.GetAxis("Vertical");
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * VerticalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.right * HorizontalInput * speed * Time.deltaTime);

        if(health<=0)
        {
            endScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
                                                                                                                                                                                  
    }
    public void SetHealth()
    {
        HealthText.text = health.ToString();
    }

    public void ReduceHealth(float reduceAmount)
    {
        health -= reduceAmount;
        SetHealth();
    }
}
