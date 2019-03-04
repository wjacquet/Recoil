using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunSelection : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject gunSelectionUI;
    private GameObject gun;
    GameObject player;

    private int[] selectedGuns = new int[] {0, 0};
    private int selection = 0;

    void Start() {
        player = GameObject.Find("obj_player");
        gun = GameObject.Find("obj_gun");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {  
            SwitchGuns();
        }    

        GameObject cursor = GameObject.Find("obj_cursor");
        if (cursor.transform.position.x <= player.transform.position.x) {
            gun.GetComponent<FireWeapon>().FlipGun(true);
        } else {
            gun.GetComponent<FireWeapon>().FlipGun(false);
        }

    }

    public void GunSelected() {
        string gunName = EventSystem.current.currentSelectedGameObject.name;

        int index = FindIndexOfGun(gunName);

        PlayerInit.selectedGuns[selection] = index;
        // selectedGuns[selection] = index;
        
        RemoveGuns();
        
        Debug.Log(selection);
        gun = player.transform.GetChild(PlayerInit.selectedGuns[0]).gameObject;
        gun.SetActive(true);    

        SwitchIndex();
    }

     void SwitchGuns() {            
        RemoveGuns();

        // Switch to new index
        SwitchSavedIndex();
        
        // Show new gun
        gun = player.transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).gameObject;
        gun.SetActive(true);

    }

    void RemoveGuns() {
        gun = player.transform.GetChild(0).gameObject;
        gun.SetActive(false);

        gun = player.transform.GetChild(1).gameObject;
        gun.SetActive(false);

        gun = player.transform.GetChild(2).gameObject;
        gun.SetActive(false);

        gun = player.transform.GetChild(3).gameObject;
        gun.SetActive(false);

        gun = player.transform.GetChild(4).gameObject;
        gun.SetActive(false);

        gun = player.transform.GetChild(5).gameObject;
        gun.SetActive(false);
    }

   
    public void Resume() {
        gunSelectionUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause() {
        Cursor.visible = true;
        gunSelectionUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    // Switch between 0 and 1
    void SwitchIndex() {
        if (selection == 0)
            selection = 1;
        else 
            selection = 0;
    }
    
    void SwitchSavedIndex() {
        if (PlayerInit.currentGunIndex == 0)
            PlayerInit.currentGunIndex = 1;
        else 
            PlayerInit.currentGunIndex = 0;
    }

    int FindIndexOfGun(string gunName) {
        if (gunName.Equals("obj_gun")) {
            return 0;
        } else if (gunName.Equals("obj_bolt_gun")) {
            return 1;
        } else if (gunName.Equals("obj_fire_spitter")) {
            return 2;
        } else if (gunName.Equals("obj_photon_launcher")) {
            return 3;
        } else if (gunName.Equals("obj_machine_blaster")) {
            return 4;
        } else if (gunName.Equals("obj_cluster_gun_mkII")) {
            return 5;
        }
        return 0;
    }
}
