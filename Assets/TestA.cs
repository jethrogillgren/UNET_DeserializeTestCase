using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestA : NetworkBehaviour {






	//[SyncVar(hook="TestHook")]
	[SyncVar]
	[HideInInspector]
	public string test = "default";


	private int c = 0;
	private int m_step = 100;
	void Update()
	{

		if( c % m_step == 0 )
		{
			if (isServer)
			{
				Debug.Log("// "  + name + " is updating SYncVar and calling RPC");
				test = Time.frameCount.ToString();
				RpcCall ();

			} else if ( isClient && test != "default" )
			{
				Debug.Log ( "//////// TestA: " + name + " -> " + test );

			} else {
				Debug.LogError ("// TestA is not a aserver or a client. ******");
			}
		}
		++c;
	}

	public override void OnStartClient()
	{
		base.OnStartClient ();
		Debug.Log("// "  + name + " Starting on CLient with netId: " + netId + "  assetId: " + GetComponent<NetworkIdentity>().assetId);
	}
	public override void OnStartServer()
	{
		base.OnStartServer ();
		Debug.Log("// "  + name + " Starting on Server with netId: " + netId + "  assetId: " + GetComponent<NetworkIdentity>().assetId);

	}

	[ClientRpc]
	public void RpcCall()
	{
		Debug.Log ( "// " + name + " Client called by server OK.  NetId: " + netId );
	}





	//TEST CASE
	//If this is commented out, it works.  Left uncommented, errors are given.
	public override void OnDeserialize(NetworkReader reader, bool initialState)
	{
		base.OnDeserialize(reader, initialState);
	}
	/*

Pass Case:
03-10 10:48:49.953 26909 26921 I Unity   : // Starting as CLient
03-10 10:49:33.949 26909 26921 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO
03-10 10:49:34.020 26909 26921 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}
03-10 10:49:34.286 26909 26921 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527
03-10 10:49:34.311 26909 26921 I Unity   : //////// TestA: A -> 1
...
03-10 10:49:35.947 26909 26921 I Unity   : //////// TestA: A -> 101
...



Fail Case:
03-10 10:46:54.119 26625 26649 I Unity   : // Starting as CLient
03-10 10:47:23.600 26625 26649 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO
03-10 10:47:23.658 26625 26649 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}
03-10 10:47:23.931 26625 26649 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527
03-10 10:47:23.955 26625 26649 E Unity   : // TestA is not a aserver or a client. ******
...
03-10 10:47:25.584 26625 26649 E Unity   : // TestA is not a aserver or a client. ******
...

	 * 
	 * /
}
