using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //Temporary Immediate load of Menu scene
        SceneManager.LoadScene("Lobby");
    }
}
