using UnityEngine;
using System.Collections;

public class QTE : MonoBehaviour {
    public float timeLeft;
    private bool active;
    private int i;
    public GameObject w;
    public GameObject a;
    public GameObject s;
    public GameObject d;
    // Use this for initialization
    void Start () {
        active = false;
        i = Random.Range(1, 4);
        Debug.Log(i);
        w.SetActive(false);
        a.SetActive(false);
        s.SetActive(false);
        d.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            active = !active;
        }
        if (active){
            switch (i){
                case 1:
                    w.SetActive(true);
                    break;
                case 2:
                    a.SetActive(true);
                    break;
                case 3:
                    s.SetActive(true);
                    break;
                case 4:
                    d.SetActive(true);
                    break;
            }
            if (i == 1 && Input.GetKeyUp(KeyCode.W)){
                Debug.Log("YOU HIT 'W' IN TIME!");
                active = false;
            }
            else if (i == 2 && Input.GetKeyUp(KeyCode.A))
            {
                Debug.Log("YOU HIT 'A' IN TIME!");
                active = false;
            }
            if (i == 3 && Input.GetKeyUp(KeyCode.S))
            {
                Debug.Log("YOU HIT 'S' IN TIME!");
                active = false;
            }
            if (i == 4 && Input.GetKeyUp(KeyCode.D))
            {
                Debug.Log("YOU HIT 'D' IN TIME!");
                active = false;
            }
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                active = false;
            }
        }
    }
}
