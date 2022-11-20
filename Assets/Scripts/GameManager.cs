using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public GameObject GameOver;
    public GameObject[] p1Sticks;
    public GameObject[] p2Sticks;

    public int P1Life;
    public int P2Life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(P1Life <= 0){
            Player1.SetActive(false);
            GameOver.SetActive(true);
        }

        if (P2Life <= 0){
            Player2.SetActive(false);
            GameOver.SetActive(true);
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
    }

    public void HurtP2(){
        P2Life -= 1;
        for (int i = 0; i < p2Sticks.Length; i++){
            if (P2Life > i)            
                p2Sticks[i].SetActive(true);            
            else
                p2Sticks[i].SetActive(false);
        }
    }

}
