using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void SavePlayer()
    {
        Save.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = Save.LoadPlayer();
       

        Vector3 position;
        //List<Key.KeyType> keyList; //save list of keys

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        //keyList = list of player's keys 
    }
    //Many methods to try

}
