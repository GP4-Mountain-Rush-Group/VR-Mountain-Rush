using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameArea : MonoBehaviour
{
    public GameObject EndMenu;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("1");
            Time.timeScale = 0;
            EndMenu.SetActive(true);
        }
        else
            Debug.Log("2");

    }
}
