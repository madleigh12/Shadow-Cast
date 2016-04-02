using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class H2PController : MonoBehaviour {

	void Update () {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
               SceneManager.LoadScene(0);
        }
    }
}
