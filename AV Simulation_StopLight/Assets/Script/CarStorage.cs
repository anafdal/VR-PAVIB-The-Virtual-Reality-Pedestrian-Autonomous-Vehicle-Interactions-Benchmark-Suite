﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarStorage : MonoBehaviour
{//script in CARS

    public GameObject[] cars;//list of cars
    private bool value;//only true if one or more cars are active
    public float rate = 10.0f;//rate at which cars get generated

    public void Start()
    {
        value = true;
        cars[0].SetActive(true);
       
    }

    void Update()
    {

        value = CallCar(cars);

        if (value == false)
        {
            StartCoroutine(RateCoroutine());//this will be called once all cars are deactivated
            value = true;
        }

    }

    private bool CallCar(GameObject[] cars)
    {
        bool value = true;

        for (int i = 0; i < cars.Length - 1; i++)
        {
            if (cars[cars.Length - 1].activeInHierarchy != true)//check if some cars are not active
            {
                value = false;
            }
            else
            {
                value = true;
            }
        }

        return value;
    }

    IEnumerator RateCoroutine()//wait for ... seconds before car becomes active
    {

        foreach (GameObject car in cars)
        {
            
            if (car.activeInHierarchy == false)
            {
               
                yield return new WaitForSeconds(rate);
                car.SetActive(true);// cars start activing 
            }

        }

    }
}



