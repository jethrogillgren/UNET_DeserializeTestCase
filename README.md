Test case for a UNET bug

Commenting out Assets/TestA.cs  override of OnDeserialize works, uncommenting it fails.


		public override void OnDeserialize(NetworkReader reader, bool initialState)
		{
			base.OnDeserialize(reader, initialState);
		}


Reproduce steps:
Tested on: Unity2017.3.1p1, Mac

Open project
Open Main6 scene
Build and run to android (tested on Android 6.0)
Press play in the editor.


Fail Case:
03-10 10:46:54.119 26625 26649 I Unity   : // Starting as CLient
03-10 10:47:23.600 26625 26649 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO
03-10 10:47:23.658 26625 26649 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}
03-10 10:47:23.931 26625 26649 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527
03-10 10:47:23.955 26625 26649 E Unity   : // TestA is not a aserver or a client. ******
...
03-10 10:47:25.584 26625 26649 E Unity   : // TestA is not a aserver or a client. ******
...


Pass Case:
03-10 10:48:49.953 26909 26921 I Unity   : // Starting as CLient
03-10 10:49:33.949 26909 26921 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO
03-10 10:49:34.020 26909 26921 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}
03-10 10:49:34.286 26909 26921 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527
03-10 10:49:34.311 26909 26921 I Unity   : //////// TestA: A -> 1
...
03-10 10:49:35.947 26909 26921 I Unity   : //////// TestA: A -> 101
...
