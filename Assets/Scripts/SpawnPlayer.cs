using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    public GameObject playerCamPrefab;
    public GameObject playerControlsPrefab;
    public Vector3 spawnPos = new Vector3(0, 0, 0);
    public override void OnJoinedRoom()
    {
        StartCoroutine(Epic());
    }
    IEnumerator  Epic()
    {
        print("thing");
        yield return new WaitForSeconds(1);
        GameObject spawned = PhotonNetwork.Instantiate(PlayerPrefab.name, spawnPos, Quaternion.identity);
        GameObject camera = Instantiate(playerCamPrefab, spawnPos, Quaternion.identity);
        GameObject canvas = Instantiate(playerControlsPrefab, spawnPos, Quaternion.identity);
        canvas.GetComponent<Movement>().player = spawned.GetComponent<Rigidbody>();
        canvas.GetComponent<Movement>().view = spawned.GetComponent<PhotonView>();
        //So the camera isn't sticking into the ground and looks over the shoulder (the root is at the feet)
        GameObject cameraOffset = new GameObject();
        cameraOffset.transform.position = new Vector3(0, 0f, 0f);
        cameraOffset.transform.parent = spawned.transform;
        cameraOffset.transform.position = new Vector3(0, 2f, 0.2f);
        camera.GetComponentInChildren<CinemachineVirtualCamera>().Follow = cameraOffset.transform;
        camera.GetComponentInChildren<CinemachineVirtualCamera>().LookAt =  spawned.transform;
        // if(spawned.GetComponentInChildren<PhotonView>().IsMine == false)
        // {
        //     Debug.Log("Not your view");
        //     //spawned.GetComponentInChildren<Camera>().gameObject.SetActive(false);
        //     Destroy(spawned.GetComponentInChildren<Camera>().gameObject);
        //     Destroy(spawned.GetComponentInChildren<Canvas>().gameObject);
        // }
        // print("Complete");
    }

}
