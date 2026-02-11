using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRooms : MonoBehaviour
{
    private RoomTempelates tempelates;
    void Start()
    {
        tempelates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTempelates>();
        tempelates.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    
    }



}
