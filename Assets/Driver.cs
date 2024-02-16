//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/16/2024
/////////////////////////////////////////////


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Driver : MonoBehaviour
{

    //input screen ui references
    [SerializeField] TMP_InputField makeField;
    [SerializeField] TMP_InputField yearField;
    [SerializeField] Button enterCarButton;

    //references to driving ui
    [SerializeField] GameObject carUI;
    [SerializeField] TMP_Text makeText;
    [SerializeField] TMP_Text yearText;

    //references to speedometer ui
    [SerializeField] GameObject speedometerUI;
    [SerializeField] TMP_Text speedometerText;

    //player car var and bool to enable input
    Car playerCar;
    bool inCar = false;

    //variables for input delay. inputTimer max determines responsiveness of controls
    bool inputDelayOn = false;
    [SerializeField] float inputTimerMax = 10f;
    float inputTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (inCar)
        {
            float direction = Input.GetAxisRaw("Vertical");

            if (direction < 0 && !inputDelayOn)
            {
                playerCar.Decelerate();
                SetSpeedUI();

                inputDelayOn = true;
            }
            if (direction > 0 && !inputDelayOn)
            {
                playerCar.Accelerate();
                SetSpeedUI();

                inputDelayOn = true;
            }

            while (inputDelayOn)
            {
                inputTimer -= Time.deltaTime;
                Debug.Log(inputTimer);
                if (inputTimer <= 0)
                {
                    inputDelayOn = false;
                    inputTimer = inputTimerMax;
                }
            }
        }
    }

    //when enter car button is clicked
    public void EnterCarButton()
    {

        //check the input fields are not empty
        if (makeField.text == "" || makeField.text == null)
        {
            Debug.Log("NO MAKE");
            return;
        }
        else if (yearField.text == "" || yearField == null)
        {
            Debug.Log("NO YEAR");
            return;
        }

        //move make field value to variable. declare year input variable
        string makeInput = makeField.text;
        int yearInput;

        //cast year input to integer
        yearInput = int.Parse(yearField.text);

        //check if the integer is a reasonable value for a car year
        if (yearInput > 1886 && yearInput < 2025)
        {
            //instantiate playerCar
            playerCar = new Car();

            //set playerCar year and make
            playerCar.Year = yearInput;
            playerCar.Make = makeInput;

            Debug.Log(playerCar.Make);
            Debug.Log(playerCar.Year);

            //call method to switch UI
            SetDrivingUI();
        }
        else
        {
            Debug.Log("Invalid Year");
        }
    }

    //method to switch ui from Input to Driving
    void SetDrivingUI()
    {
        //deactive all input ui
        makeField.gameObject.SetActive(false);
        yearField.gameObject.SetActive(false);
        enterCarButton.gameObject.SetActive(false);

        //enable car ui parent and speedometer parent
        carUI.SetActive(true);
        speedometerUI.SetActive(true);

        //set carUI text to values stored in playerCar
        makeText.text = $"Make: {playerCar.Make}";
        yearText.text = $"Year: {playerCar.Year}";

        //set playerCar speed to 0 and call SetSpeed Method to update speedometer UI
        playerCar.Speed = 0;
        SetSpeedUI();

        //set inCar to true, enables player driving controls
        inCar = true;
    }

    //method to update speedometer ui
    void SetSpeedUI()
    {
        speedometerText.text = $"Current Speed: {playerCar.Speed}";
    }
}
