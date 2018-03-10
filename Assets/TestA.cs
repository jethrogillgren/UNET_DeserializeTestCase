using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestA : NetworkBehaviour {


	//[SyncVar(hook="TestHook")]
	[HideInInspector]
	[SyncVar]
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

			} else if ( isClient )
			{
				Debug.Log ( "// TestA: " + name + " -> " + test );

			} else {
				Debug.LogError ( "// TestA is not a a server or a client" );
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
		Debug.Log ( "// " + name + " ClientRPC called by server OK.  NetId: " + netId );
	}





	//TEST CASE
	//If this is commented out, it works.  Left uncommented, errors are given.
	public override void OnDeserialize(NetworkReader reader, bool initialState)
	{
		base.OnDeserialize(reader, initialState);
	}


}
