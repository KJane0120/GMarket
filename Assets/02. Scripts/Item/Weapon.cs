using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public int id;
    public int prefabId;
    public int damage;


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init()
    {
        switch (id)
        {
            case 0:
                damage = 5;

                break;
            default:
                break;

        }
    }
}
