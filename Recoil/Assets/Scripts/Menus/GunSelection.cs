using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunSelection : MonoBehaviour {

    public static bool gameIsPaused = false;
    public GameObject gunSelectionUI;

    public Image firstImage;
    public Image secondImage;

    public Sprite obj_gun;
    public Sprite obj_bolt_gun;
    public Sprite obj_fire_spitter;
    public Sprite obj_photon_launcher;
    public Sprite obj_machine_blaster;
    public Sprite obj_cluster_gun_mkII;

    private GameObject gun;
    GameObject player;
    
    private bool first = true;
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

        // Flip Gun...Again
        GameObject cursor = GameObject.Find("obj_cursor");
        if (cursor.transform.position.x <= player.transform.position.x) {
            gun.GetComponent<PivotGun>().FlipGun(true);
        } else {
            gun.GetComponent<PivotGun>().FlipGun(false);
        }

    }

    // Method called when gun is clicked in gun selction menu
    public void GunSelected() {
        // Get gun name from button name
        string gunName = EventSystem.current.currentSelectedGameObject.name;

        // Get index from selected guns array 
        int index = FindIndexOfGun(gunName);
        Sprite newImage = GetNewImage(gunName);

        // Set new gun in selected guns array
        PlayerInit.selectedGuns[selection] = index;
        
        // Remove all guns from players hand
        RemoveGuns();
        
        // Set first gun as current
        gun = player.transform.GetChild(PlayerInit.selectedGuns[0]).gameObject;
        gun.SetActive(true);    

        // Show Gun Stats
        if (first) {
            firstImage.sprite = newImage;
            first = false;
        } else {
            secondImage.sprite = newImage;
            first = true;
        }

        // Updated selected
        SwitchIndex();
    }

    // Method called when players click 's' to switch guns
    void SwitchGuns() { 
        // Remove all guns from hand     
        RemoveGuns();

        // Switch to new index
        SwitchSavedIndex();
        
        // Show new gun
        gun = player.transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).gameObject;
        gun.SetActive(true);
    }

    // Removes all guns from players hand
    void RemoveGuns() {
        for (int i = 0; i < 6; i++) {
            gun = player.transform.GetChild(i).gameObject;
            gun.SetActive(false);  
        }
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
    
    // Switch between 0 and 1
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

    Sprite GetNewImage(string gunName) {
        if (gunName.Equals("obj_gun")) {
            return obj_gun;
        } else if (gunName.Equals("obj_bolt_gun")) {
            return obj_bolt_gun;
        } else if (gunName.Equals("obj_fire_spitter")) {
            return obj_fire_spitter;
        } else if (gunName.Equals("obj_photon_launcher")) {
            return obj_photon_launcher;
        } else if (gunName.Equals("obj_machine_blaster")) {
            return obj_machine_blaster;
        } else if (gunName.Equals("obj_cluster_gun_mkII")) {
            return obj_cluster_gun_mkII;
        }
        return null;
    }
}
