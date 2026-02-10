using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1 --> Need Top
    //2 --> Need Bottom
    //3 --> Need Right
    //4 --> Need Left

    private RoomTempelates tempelates;
    private int rand;
    private bool spawned = false;
    public string roomtype;

    void Start()
    {
        tempelates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTempelates>();
        Invoke("Spawn", 1f);
    }

    // Update is called once per frame
    void Spawn()
    {   if (roomtype == "coridor")
        {
            if (spawned == false)
            {
                if (openingDirection == 1)
                {
                    //Need to spawn Top Door
                    rand = Random.Range(0, tempelates.topRooms.Length);
                    Instantiate(tempelates.topRooms[rand], transform.position, tempelates.topRooms[rand].transform.rotation);
                }

                else if (openingDirection == 2)
                {
                    //Need to spawn Bottom Door
                    rand = Random.Range(0, tempelates.bottomRooms.Length);
                    Instantiate(tempelates.bottomRooms[rand], transform.position, tempelates.bottomRooms[rand].transform.rotation);
                }

                else if (openingDirection == 3)
                {
                    //Need to Right Top Door
                    rand = Random.Range(0, tempelates.rightRooms.Length);
                    Instantiate(tempelates.rightRooms[rand], transform.position, tempelates.rightRooms[rand].transform.rotation);
                }

                else if (openingDirection == 4)
                {
                    //Need to spawn Left Door
                    rand = Random.Range(0, tempelates.leftRooms.Length);
                    Instantiate(tempelates.leftRooms[rand], transform.position, tempelates.leftRooms[rand].transform.rotation);
                }
            }
        }
        else if (roomtype == "room")
        {
            if (openingDirection == 1 || openingDirection == 2)
            {


                Instantiate(tempelates.tbcoridor, transform.position,Quaternion.identity);
            }

            else if (openingDirection == 3 || openingDirection == 4)
            {


                Instantiate(tempelates.rlcoridor, transform.position,Quaternion.identity);
            }
        }

        spawned = true;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            print(openingDirection);
            print(collision.GetComponent<RoomSpawner>().openingDirection);
            if(collision.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                if(openingDirection == 3 && collision.GetComponent<RoomSpawner>().openingDirection == 1)
                {
                    Instantiate(tempelates.rt, transform.position, Quaternion.Euler(0, 0, 270));
                }
                else if (openingDirection == 3 && collision.GetComponent<RoomSpawner>().openingDirection == 2)
                {
                    Instantiate(tempelates.rb, transform.position, Quaternion.Euler(0, 0, 180));
                }
                else if (openingDirection == 4 && collision.GetComponent<RoomSpawner>().openingDirection == 1)
                {   
                    Instantiate(tempelates.lt, transform.position, Quaternion.Euler(0, 0, 0));            
                }
                else if (openingDirection ==  4 && collision.GetComponent<RoomSpawner>().openingDirection == 2)
                {
                    Instantiate(tempelates.lb, transform.position, tempelates.leftRooms[rand].transform.rotation);
                }
                Destroy(gameObject);
            }
            spawned = true;
        }
    }


}
