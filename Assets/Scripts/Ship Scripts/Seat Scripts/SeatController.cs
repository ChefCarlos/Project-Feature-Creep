using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatController : MonoBehaviour
{
    private List<(GameObject, Seat)> seatWithType; 
    private GameObject[] seatsOnShip;
    
    void Start()
    {
        seatWithType = new List<(GameObject seatObject, Seat seatInfo)>();
        getAllSeats();
        getSeatTypes();
    }

    void getAllSeats()
    {
        seatsOnShip = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            seatsOnShip[i] = transform.GetChild(i).gameObject;
        }
    }

    void getSeatTypes()
    {
        foreach (GameObject seatObject in seatsOnShip)
        {
            Seat currentSeat = seatObject.GetComponent<Seat>();
            createSeatTuples(seatObject, currentSeat);
        }
    }

    void createSeatTuples(GameObject seatObject, Seat seatInfo)
    {
        seatWithType.Add((seatObject, seatInfo));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
