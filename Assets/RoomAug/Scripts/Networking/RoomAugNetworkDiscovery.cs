//Adopted from Hololens Example Project
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;
using UnityEngine.Networking;

#if WINDOWS_UWP
using Windows.Networking.Connectivity;
using Windows.Networking;
#endif

namespace RoomAug.Networking
{

    public class RoomAugNetworkDiscovery : NetworkDiscovery
    {

        private void Start()
        {
            // Initializes NetworkDiscovery.
            Initialize();

			#if UNITY_EDITOR
			Debug.Log("// Starting as Server");
			NetworkManager.singleton.StartServer();
			StartAsServer();
			#else
			Debug.Log("// Starting as CLient");
			StartAsClient();
			#endif
        }


        /// <summary>
        /// Called by UnityEngine when a broadcast is received. 
        /// </summary>
        /// <param name="fromAddress">When the broadcast came from</param>
        /// <param name="data">The data in the broad cast. Not currently used, but could
        /// be used for differntiating rooms or similar.</param>
        public override void OnReceivedBroadcast(string fromAddress, string data)
        {
			Debug.Log ( "// " + name + " OnReceivedBroadcast from " + fromAddress + " of " + data);

			StopBroadcast ();

			NetworkManager.singleton.networkAddress = fromAddress;
			NetworkManager.singleton.StartClient();

			NetworkServer.SpawnObjects ();
        }


    }
}