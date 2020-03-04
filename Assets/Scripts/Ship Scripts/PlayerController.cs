using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SeatType currentSeat;

    
    private GameObject[] seatsOnShip;
    

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            //setSeat();
        }
    }
}
