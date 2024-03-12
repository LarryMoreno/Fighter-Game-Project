using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManagerUI : MonoBehaviour
{
    //[SerializeField] private Button serverbutton; 
    [SerializeField] private Button hostbutton;
    [SerializeField] private Button clientbutton;

    private void Awake(){
        /*serverbutton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartServer();
        });*/

        hostbutton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });

        clientbutton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });
    }

}
