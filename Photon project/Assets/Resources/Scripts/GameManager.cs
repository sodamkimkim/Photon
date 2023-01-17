using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab = null;


    private void Start()
    {
        if (playerPrefab != null)
        {
            GameObject go = PhotonNetwork.Instantiate(
                playerPrefab.name,
                new Vector3(
                    Random.Range(-10.0f, 10.0f),
                    0.0f,
                    Random.Range(-10.0f, 10.0f)),
                Quaternion.identity,
                0);
            go.GetComponent<PlayerCtrl>().SetMaterial(PhotonNetwork.CurrentRoom.PlayerCount);
        }
    }

    // PhotonNetwork.LeaveRooom 함수가 호출되면 호출
    public override void OnLeftRoom()
    {
        Debug.Log("Left Room");

        SceneManager.LoadScene("Launcher");
    }

    // 플레이어가 입장할 때 호출되는 함수
    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Entered Room: {0}",
                        otherPlayer.NickName);
    }

    // 플레이어가 나갈 때 호출되는 함수
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player Left Room: {0}",
                        otherPlayer.NickName);
    }

    public void LeaveRoom()
    {
        Debug.Log("Leave Room");

        PhotonNetwork.LeaveRoom();
    }
}
