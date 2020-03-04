using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SeatType currentSeat;

    private float seatChange;

    void Start()
    {
        
    }

    private void getInputs()
    {
        seatChange = Input.GetAxis("Vertical");
    }

    void nextSeat(Seat seatToMoveTo)
    {
        currentSeat = seatToMoveTo.GetTypeOfSeat;
    }

    void setSeat()
    {
        Seat seatToMoveTo = findNextSeat();
        nextSeat(seatToMoveTo);
        moveToSeat(seatToMoveTo);
        Debug.Log("Changed Seats");
    }

    void moveToSeat(Seat seatToMoveTo)
    {
        transform.position = seatToMoveTo.transform.position;
    }

    Seat findNextSeat()
    {
        bool seatFound = false;
        while (!seatFound) { 
            GameObject seatToMoveTo = GameObject.FindGameObjectWithTag("Seat");
            Seat seatScript = seatToMoveTo.GetComponent<Seat>();
            if (seatScript.GetTypeOfSeat != currentSeat)
            {
                return seatScript;
            }
        }
        seatFound = false;
        return null;
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("h"))
        {
            setSeat();
        }
    }
}
