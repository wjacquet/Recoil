﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunSelection : MonoBehaviour {

    public static bool gameIsPaused = false;
    public static bool onCheckpoint = false;
    public GameObject gunSelectionUI;

    public Image firstImage;
    public Image secondImage;

    public Sprite obj_gun;
    public Sprite obj_bolt_gun;
    public Sprite obj_fire_spitter;
    public Sprite obj_photon_launcher;
    public Sprite obj_machine_blaster;
    public Sprite obj_cluster_gun_mkII;

    public GameObject gunBox1;
    public GameObject gunBox2;
    public GameObject gunBox3;
    public GameObject gunBox4;
    public GameObject gunBox5;
    public GameObject gunBox6;


    private GameObject gun;
    private SpriteRenderer spriteRen;
    private GameObject player;
    private Sprite[] sprites;
    private GameObject[] gunBoxes;
    private bool first = true;
    private int selection = 0;

    void Start() {
        gunBoxes = new GameObject[6] {gunBox1, gunBox2, gunBox3, gunBox4, gunBox5, gunBox6};
        sprites = new Sprite[6] {obj_gun, obj_bolt_gun, obj_fire_spitter, obj_photon_launcher, obj_machine_blaster, obj_cluster_gun_mkII};

        player = GameObject.Find("obj_player");
        gun = GameObject.Find("obj_gun_pivot");
        spriteRen = player.transform.GetChild(0).GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).GetChild(0).GetComponent<SpriteRenderer>();

        SwitchGuns();
        SwitchGuns();

        SetGunSelected();

        // Debug.Log(PlayerInit.currentGunIndex);

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.G) && onCheckpoint) {
            if (gameIsPaused) {
                Resume();
            } else {
                ShowGunsUnlocked();
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.S)) {  
            SwitchGuns();
        }    
 
        // Flip Gun
        CheckFlip();
    }

    // Method called when gun is clicked in gun selction menu
    public void GunSelected() {

        // Get index from selected guns array 
        string indexStr = EventSystem.current.currentSelectedGameObject.name;
        int index = int.Parse(indexStr);

        // Get Sprite Image for gun stats panel
        Sprite newImage = sprites[index];

        // Set new gun in selected guns array
        PlayerInit.selectedGuns[selection] = index;
        
        // Remove all guns from players hand
        RemoveGuns();
        
        // Set first gun as current
        GameObject tmp = player.transform.GetChild(0).GetChild(PlayerInit.selectedGuns[0]).gameObject;
        tmp.SetActive(true);    

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

        // Swappy Swappy 
        SwitchGuns();
        SwitchGuns();
    }

    void SetGunSelected() {
        Sprite newImage = sprites[PlayerInit.selectedGuns[0]];
        Sprite newImage2 = sprites[PlayerInit.selectedGuns[1]];

        // Show Gun Stats
        firstImage.sprite = newImage;
        secondImage.sprite = newImage2;
        
    }

    void ShowGunsUnlocked() {
        for (int i = 0; i < gunBoxes.Length; i++) {
            if (!PlayerInit.gunsFound[i]) {
                gunBoxes[i].SetActive(false);
            } else {
                gunBoxes[i].SetActive(true);
            }
        }
    }

    // Method called when players click 's' to switch guns
    public void SwitchGuns() { 
        // Remove all guns from hand     
        RemoveGuns();

        // Switch to new index
        SwitchSavedIndex();
        
        // Show new gun
        GameObject tmp = player.transform.GetChild(0).GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).gameObject;
        spriteRen = player.transform.GetChild(0).GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).GetChild(0).GetComponent<SpriteRenderer>();
        tmp.SetActive(true);

        SetSpriteInPivot();
        CheckFlip();
    }

    void CheckFlip() {
        GameObject cursor = GameObject.Find("obj_cursor");
        if (cursor.transform.position.x <= player.transform.position.x) {
            spriteRen.flipX = true;
            gun.GetComponent<PivotGun>().FlipGun(true);
        } else {
            spriteRen.flipX = false;
            gun.GetComponent<PivotGun>().FlipGun(false);
        }
    }

    void SetSpriteInPivot() {
        Transform tmp =  player.transform.GetChild(0).transform.GetChild(PlayerInit.selectedGuns[PlayerInit.currentGunIndex]).transform;
        gun.GetComponent<PivotGun>().SetSprite(tmp);
    }
    

    // Removes all guns from players hand
    void RemoveGuns() {
        for (int i = 0; i < 6; i++) {
            GameObject tmp = player.transform.GetChild(0).GetChild(i).gameObject;
            tmp.SetActive(false);  
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
        selection = 1 - selection;
    }
    
    // Switch between 0 and 1
    void SwitchSavedIndex() {
        PlayerInit.currentGunIndex = 1 - PlayerInit.currentGunIndex;
    }

    public void FlipCheckpoint(bool value) {
        onCheckpoint = value;
    }

}
