using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public GameObject[] seatsOnShip;
    public Component[] controllersFromSeats;

    void Start()
    {
        controllersFromSeats = new Component[seatsOnShip.Length];
        collectControllers();
    }

    void collectControllers()
    {

    }

    void Update()
    {
        
    }
}
