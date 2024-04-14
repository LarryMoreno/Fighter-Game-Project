using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;
using UnityEditor;

public class NetworkManagerUI : MonoBehaviour
{
    //[SerializeField] private Button serverbutton; 
    [SerializeField] private Button hostbutton;
    [SerializeField] private Button clientbutton;

    public GameObject menu;
    public GameObject ui;

    private void Awake(){
        
        NetworkManager.Singleton.GetComponent<UnityTransport>().SetConnectionData("127.0.0.1", 4444);

        hostbutton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
            menu.SetActive(false);
            ui.SetActive(true);
        });

        clientbutton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
            menu.SetActive(false);
            ui.SetActive(true);
        });
    }

}
