using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

//using RoomAug.Player;
using System.Linq;

namespace RoomAug.Networking
{
    //This is a specialised NetworkManager.
    //NetworkManager wraps the actual Link connection between Server and Client.
    //My Own NetworkController handles non UNET connection stuff
    public class RoomAugNetworkManager : NetworkManager
    {


        //Control adding new Players on client connection.  Runs on the server.  Modified to respect NetworkType
        //playerControllerId is the client scoped player id, for cases where a client has more than one player (eg multiple gamepads)
        public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
        {
			
        	GameObject player = (GameObject)Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
                    
        }

    }
}