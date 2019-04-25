using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

// How to Add new parts to the map.
// 1. Make the map in google drive and save a normal version and a gold highlited version
// 2. Put both images into Objects/Menus
// 3. Add "public GameObject TutorialXY" and "public GameObject TutorialXYGold" directly below the rest 
// 4. Go to the map Prefab and click Pause-Map-Screens
// 5. On the Inspector tab scroll to the bottom and connect the map comonents to the corresponding link
// 6. Add an if check to the method "FindScene" at the bottom of this file (Yes I know that if statement is ugly, 
//    but I don't know how to find the GameObject specific as the global, by the name inputed into the method) 
// 7. Test to make sure everything works, if not ask Kyle 

public class Map : MonoBehaviour {

    public static bool gameIsPaused = false;

    public GameObject StartingArea;
    public GameObject StartingAreaGold;

    public GameObject Tutorial2;
    public GameObject Tutorial2Gold;

    public GameObject Tutorial3;
    public GameObject Tutorial3Gold;

    public GameObject Tutorial4;
    public GameObject Tutorial4Gold;

    public GameObject Tutorial5;
    public GameObject Tutorial5Gold;

    public GameObject TutorialBoss;
    public GameObject TutorialBossGold;

    public GameObject Greenhouse1;
    public GameObject Greenhouse1Gold;

    public GameObject Greenhouse2;
    public GameObject Greenhouse2Gold;

    public GameObject Greenhouse3;
    public GameObject Greenhouse3Gold;

    public GameObject Greenhouse4;
    public GameObject Greenhouse4Gold;

    public GameObject GreenhouseBoss;
    public GameObject GreenhouseBossGold;

    public GameObject GrassyZoneEntrance;
    public GameObject GrassyZoneEntranceGold;

    public GameObject GrassyZoneGreenhouse;
    public GameObject GrassyZoneGreenhouseGold;

    public GameObject GrassyZoneJunkyard;
    public GameObject GrassyZoneJunkyardGold;

    public GameObject GrassyZoneRainy;
    public GameObject GrassyZoneRainyGold;

    public GameObject Junkyard1;
    public GameObject Junkyard1Gold;
    
    public GameObject Junkyard2;
    public GameObject Junkyard2Gold;

    public GameObject Junkyard3;
    public GameObject Junkyard3Gold;

    public GameObject Junkyard4;
    public GameObject Junkyard4Gold;

    public GameObject JunkyardBoss;
    public GameObject JunkyardBossGold;

    public GameObject Moon1;
    public GameObject Moon1Gold;

    public GameObject Moon2;
    public GameObject Moon2Gold;

    public GameObject Moon3;
    public GameObject Moon3Gold;

    public GameObject Moon4;
    public GameObject Moon4Gold;

    public GameObject Moon5;
    public GameObject Moon5Gold;
   
    // public GameObject Rainy1;
    // public GameObject Rainy1Gold;
 
    // public GameObject Rainy2;
    // public GameObject Rainy2Gold;

    // public GameObject RainyBoss;
    // public GameObject RainyBossGold;

    // Update is called once per frame
    void Update() {
        if (SelectionMenus.mapOpen) {
            if (SelectionMenus.gameIsPaused) {
                Pause();
            }
        }
    }

    public void Pause() {
        // Set basic map scene to disapear and gold scene to appear
        SetActiveScene(SceneManager.GetActiveScene().name);

        for (int i = 0; i < PlayerInit.scenesVisited.Length; i++) {
            // Hide Scene!
            if (!PlayerInit.scenesVisited[i]) {
                string sceneName = GetSceneFromIndex(i);
                HideScene(sceneName);
            }
        }
    }

    public string GetSceneFromIndex(int index) {
        string path = SceneUtility.GetScenePathByBuildIndex(index);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    public void HideScene(string level) {
        GameObject[] array = FindScene(level);

        if (array != null) {
            array[0].SetActive(false);
            array[1].SetActive(false);
        }
    }

    public void SetActiveScene(string level) {
        FindScene(level)[0].SetActive(false);
        FindScene(level)[1].SetActive(true);
    }

    public GameObject[] FindScene(string level) {

        if (level.Equals(StartingArea.name)) {
            return (new[] {StartingArea, StartingAreaGold});

        } else if (level.Equals(Tutorial2.name)) {
            return  (new[] {Tutorial2, Tutorial2Gold});

        } else if (level.Equals(Tutorial3.name)) {
            return  (new[] {Tutorial3, Tutorial3Gold});

        } else if (level.Equals(Tutorial4.name)) {
            return  (new[] {Tutorial4, Tutorial4Gold});

        } else if (level.Equals(Tutorial5.name)) {
            return  (new[] {Tutorial5, Tutorial5Gold});

        } else if (level.Equals(TutorialBoss.name)) {
            return  (new[] {TutorialBoss, TutorialBossGold});

        } else if (level.Equals(Greenhouse1.name)) {
            return  (new[] {Greenhouse1, Greenhouse1Gold});

        } else if (level.Equals(Greenhouse2.name)) {
            return  (new[] {Greenhouse2, Greenhouse2Gold});

        } else if (level.Equals(Greenhouse3.name)) {
            return  (new[] {Greenhouse3, Greenhouse3Gold});

        } else if (level.Equals(Greenhouse4.name)) {
            return  (new[] {Greenhouse4, Greenhouse4Gold});

        } else if (level.Equals(GreenhouseBoss.name)) {
            return  (new[] {GreenhouseBoss, GreenhouseBossGold});

        } else if (level.Equals(GrassyZoneEntrance.name)) {
            return  (new[] {GrassyZoneEntrance, GrassyZoneEntranceGold});

        } else if (level.Equals(GrassyZoneGreenhouse.name)) {
            return  (new[] {GrassyZoneGreenhouse, GrassyZoneGreenhouseGold});

        } else if (level.Equals(GrassyZoneJunkyard.name)) {
            return  (new[] {GrassyZoneJunkyard, GrassyZoneJunkyardGold});

        } else if (level.Equals(GrassyZoneRainy.name)) {
            return  (new[] {GrassyZoneRainy, GrassyZoneRainyGold});

        } else if (level.Equals(Junkyard1.name)) {
            return  (new[] {Junkyard1, Junkyard1Gold});

        } else if (level.Equals(Junkyard2.name)) {
            return  (new[] {Junkyard2, Junkyard2Gold});

        } else if (level.Equals(Junkyard3.name)) {
            return  (new[] {Junkyard3, Junkyard3Gold});

        } else if (level.Equals(Junkyard4.name)) {
            return  (new[] {Junkyard4, Junkyard4Gold});

        } else if (level.Equals(JunkyardBoss.name)) {
            return  (new[] {JunkyardBoss, JunkyardBossGold});

        } else if (level.Equals(Moon1.name)) {
            return  (new[] {Moon1, Moon1Gold});

        } else if (level.Equals(Moon2.name)) {
            return  (new[] {Moon2, Moon2Gold});

        } else if (level.Equals(Moon3.name)) {
            return  (new[] {Moon3, Moon3Gold});

        } else if (level.Equals(Moon4.name)) {
            return  (new[] {Moon4, Moon4Gold});

        } else if (level.Equals(Moon5.name)) {
            return  (new[] {Moon5, Moon5Gold});
         
        // else if (level.Equals(Rainy1.name)) {
        //     return  (new[] {Rainy1, Rainy1Gold});

        // } else if (level.Equals(Rainy2.name)) {
        //     return  (new[] {Rainy2, Rainy2Gold});

        // } else if (level.Equals(RainyBoss.name)) {
        //     return  (new[] {RainyBoss, RainyBossGold});

        // } 
        
        } else {
           return null;
        }
    }
}
