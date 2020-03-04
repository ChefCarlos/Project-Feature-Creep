using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seat : MonoBehaviour
{
    public SeatType typeOfSeat;

    public SeatType GetTypeOfSeat{
        get { return typeOfSeat; }
    }
    
}
