using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Car
{
    private int year;
    private string make;
    private int maxSpeed = 100;
    private int currentSpeed;

    public int Year
    {
        get { return year; }

        set { year = value; }
    }

    public string Make
    {
        get { return make; }
   
        set { make = value; }
    }

    public void Accelerate()
    {
        currentSpeed++;

        if (currentSpeed > maxSpeed) { currentSpeed = maxSpeed; }
    }

    public void Decelerate()
    {
        currentSpeed--;

        if (currentSpeed < 0) { currentSpeed = 0;}
    }
}

