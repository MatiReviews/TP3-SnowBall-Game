using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject P1Wins;
    public GameObject P2Wins;
    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;
    public AudioSource hurtSound;
    public AudioSource deathSound;

    public int P1Life;
    public int P2Life;

    public TextMeshProUGUI mainMenu;

    // Update is called once per frame
    void Update()
    {
        if(P1Life <= 0){           
            Player1.SetActive(false);
            P2Wins.SetActive(true);
        }

        if (P2Life <= 0){            
            Player2.SetActive(false);
            P1Wins.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }

        if (P1Wins.activeSelf || P2Wins.activeSelf){
            mainMenu.gameObject.SetActive(true);
        }
    }


    public void HurtP1(){
        P1Life -= 1;
        for (int i = 0; i < p1Sticks.Length; i++){
            if(P1Life > i)
                p1Sticks[i].SetActive(true);
            else
                p1Sticks[i].SetActive(false);        
        }
        
        
        hurtSound.Play();
        deathSFX();
    }

    public void HurtP2(){
        P2Life -= 1;
        for (int i = 0; i < p2Sticks.Length; i++){
            if (P2Life > i)            
                p2Sticks[i].SetActive(true);            
            else
                p2Sticks[i].SetActive(false);
        }

        hurtSound.Play();
        deathSFX();
    }

    void deathSFX(){
        if (P1Life <= 0)
            deathSound.Play();

        if (P2Life <= 0)
            deathSound.Play();
    }
}
