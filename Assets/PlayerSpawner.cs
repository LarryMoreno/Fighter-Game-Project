using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;
using System;


public class PlayerSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject Player;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public override void OnNetworkSpawn()
    {
        NetworkManager.Singleton.SceneManager.OnLoadEventCompleted += SceneLoaded;
    }

    private void SceneLoaded(string sceneName, LoadSceneMode loadSceneMode, List<ulong> clientsCompleted, List<ulong> clientsTimedOut)
    {
        if(IsHost && sceneName == "Stage01")
        {
            foreach (ulong id in clientsCompleted)
            {
                GameObject player = Instantiate(Player);
                player.GetComponent<NetworkObject>().SpawnAsPlayerObject(id, true);
            }
        }
    }
}
