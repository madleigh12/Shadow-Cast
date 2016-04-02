using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnEnter : MonoBehaviour {
    private int selected;
    public GameObject loadingScreen;
    public GameObject how2play;
    private bool H2P = false;
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;
    public GameObject t6;
    public void Start(){
        selected = 1;
        loadingScreen.SetActive(false);
        how2play.SetActive(false);
        t1.SetActive(true);
        t2.SetActive(false);
        t3.SetActive(false);
        t4.SetActive(false);
        t5.SetActive(true);
        t6.SetActive(true);
    }

    void Update(){
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (selected == 3)
            {
                Application.Quit();
            }
            else if (selected == 1)
            {
                loadingScreen.SetActive(true);
                SceneManager.LoadScene(selected);
            }
            else
            {
                how2play.SetActive(true);
                H2P = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow)){
            ++selected;
            if (selected == 4){
                selected = 1;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)){
            --selected;
            if (selected == 0)
            {
                selected = 3;
            }
        }
        if (Input.GetKeyUp(KeyCode.Backspace) && H2P)
        {
            how2play.SetActive(false);
            H2P = false;
        }
        if (selected == 1){
            t1.SetActive(true);
            t2.SetActive(false);
            t3.SetActive(false);
            t4.SetActive(false);
            t5.SetActive(true);
            t6.SetActive(true);
        }
        else if (selected == 2)
        {
            t1.SetActive(false);
            t2.SetActive(true);
            t3.SetActive(false);
            t4.SetActive(true);
            t5.SetActive(false);
            t6.SetActive(true);
        }
        else if (selected == 3)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(true);
            t4.SetActive(true);
            t5.SetActive(true);
            t6.SetActive(false);
        }
    }
}