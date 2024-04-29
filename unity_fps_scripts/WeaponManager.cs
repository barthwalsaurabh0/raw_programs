using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Start is called before the first frame update 

    [SerializeField]
    private Weapons[] weapons;
    public int current_Weapon_Index;


    void Start()
    {
        current_Weapon_Index = 2;
        weapons[current_Weapon_Index].gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            TurnOnSelectedWeapon(0);
        }
        
        if(Input.GetKeyDown(KeyCode.Alpha2)) {
            TurnOnSelectedWeapon(1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha3)) {
            TurnOnSelectedWeapon(2);
        }
    }

    void TurnOnSelectedWeapon(int weapon_Index) {

        if (current_Weapon_Index == weapon_Index) {
            return;
        }

        weapons[current_Weapon_Index].gameObject.SetActive(false);
        weapons[weapon_Index].gameObject.SetActive(true);
        current_Weapon_Index = weapon_Index;
        print(current_Weapon_Index);
    }

    public Weapons GetCurrentSelectedWeapon() {
        return weapons[current_Weapon_Index];
    }
}

