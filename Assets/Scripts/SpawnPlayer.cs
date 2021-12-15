using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    void Start()
    {
        StartCoroutine(Epic());
    }
    IEnumerator  Epic()
    {
        print("thing");
        yield return new WaitForSeconds(1);
        PhotonNetwork.Instantiate(PlayerPrefab.name, spawnPos, Quaternion.identity);
    }

}
