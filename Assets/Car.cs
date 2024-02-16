//////////////////////////////////////////////
//Assignment/Lab/Project: Car Class
//Name: Tristin Gatt
//Section: SGD.213.2172
//Instructor: Brian Sowers
//Date: 02/16/2024
/////////////////////////////////////////////


using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Car
{
    //fields for car year, make, max speed, and current speed
    private int year;
    private string make;
    private int maxSpeed = 100;
    private int currentSpeed;

    //year property
    public int Year
    {
        get { return year; }

        set { year = value; }
    }

    //make property
    public string Make
    {
        get { return make; }
   
        set { make = value; }
    }

    //current speed property
    public int Speed
    {
        get { return currentSpeed; }

        set { currentSpeed = value; }
    }

    //method to increase speed unitl 100
    public void Accelerate()
    {
        currentSpeed++;

        if (currentSpeed > maxSpeed) { currentSpeed = maxSpeed; }
    }

    //method to decrease speed until 0
    public void Decelerate()
    {
        currentSpeed--;

        if (currentSpeed < 0) { currentSpeed = 0;}
    }
}

