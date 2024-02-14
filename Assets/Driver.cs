using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField] TMP_InputField makeField;
    [SerializeField] TMP_InputField yearField;

    [SerializeField] GameObject carUI;

    Car playerCar;


    // Start is called before the first frame update
    void Start()
    {
        playerCar = new Car();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterCarButton()
    {
        if (makeField.text == null || yearField.text == null)
        {
            return;
        }

        string makeInput = makeField.text;
        int yearInput;

        if (yearField.text != "") 
        { 
            yearInput = int.Parse(yearField.text);

            if (yearInput > 1886 && yearInput < 2025)
            {
                playerCar.Year = yearInput;
                playerCar.Make = makeInput;

                Debug.Log(playerCar.Make);
                Debug.Log(playerCar.Year);

                //enable speedometer
            }
        }
    }

    void SetDrivingUI()
    {
        makeField.gameObject.SetActive(false);
        yearField.gameObject.SetActive(false);

        carUI.SetActive(true);
        //zzz
    }
}
