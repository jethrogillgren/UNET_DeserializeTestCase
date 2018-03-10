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


Minimized Fail Case:
```

		03-10 11:08:15.783 28614 28626 I Unity   : // Starting as CLient                                                                                                           │
		03-10 11:08:26.000 28614 28626 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO                                                          │
		03-10 11:08:26.068 28614 28626 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}                                                       │
		03-10 11:08:26.231 28614 28626 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527                                                │
		03-10 11:08:26.261 28614 28626 I Unity   : // TestA: A -> default                                                                                                          │
		...
		03-10 11:08:27.288 28614 28626 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   │
		03-10 11:08:27.899 28614 28626 I Unity   : // TestA: A -> default                                                                                                          │
		...
		03-10 11:08:28.985 28614 28626 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   │
		03-10 11:08:29.570 28614 28626 I Unity   : // TestA: A -> default   
		...
```

Minimized Pass Case:
```

03-10 11:10:29.412 28912 28941 I Unity   : // Starting as CLient                                                                                                           │
03-10 11:11:12.700 28912 28941 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO                                                          ┤
03-10 11:11:12.761 28912 28941 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}                                                       │
03-10 11:11:13.012 28912 28941 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527                                                │
03-10 11:11:13.037 28912 28941 I Unity   : // TestA: A -> 1                                                                                                                │
03-10 11:11:14.666 28912 28941 I Unity   : // TestA: A -> 1                                                                                                                │
...
03-10 11:11:15.374 28912 28941 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   │
03-10 11:11:16.340 28912 28941 I Unity   : // TestA: A -> 101                                                                                                              ┤
...
03-10 11:11:17.659 28912 28941 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   ┤
03-10 11:11:18.009 28912 28941 I Unity   : // TestA: A -> 201  
```






Full logs (NetMan log lv Developer) of fail case:
```
03-10 11:14:01.325 29394 29406 I Unity   : NetworkManager created singleton (DontDestroyOnLoad)                                                                            │
03-10 11:14:01.325 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:01.325 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:01.325 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:01.499 29394 29406 I Unity   : // Starting as CLient                                                                                                           │
03-10 11:14:01.499 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:01.499 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:01.499 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:01.512 29394 29406 I Unity   : StartAsClient Discovery listening                                                                                               ┤
03-10 11:14:01.512 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:01.512 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:01.512 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.824 29394 29406 I Unity   : // NetworkManager OnReceivedBroadcast from ::ffff:192.168.0.2 of HELLO                                                          ┤
03-10 11:14:19.824 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.824 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.824 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.825 29394 29406 I Unity   : Stopped Discovery broadcasting                                                                                                  ┤
03-10 11:14:19.825 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.825 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.825 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.852 29394 29406 I Unity   : Client created version Current                                                                                                  ┤
03-10 11:14:19.852 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.852 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.852 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.865 29394 29406 I Unity   : RegisterHandler id:32 handler:OnClientConnectInternal                                                                           │
03-10 11:14:19.865 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.865 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.865 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.866 29394 29406 I Unity   : RegisterHandler id:33 handler:OnClientDisconnectInternal                                                                        ┤
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.866 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.866 29394 29406 I Unity   : RegisterHandler id:36 handler:OnClientNotReadyMessageInternal                                                                   ┤
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.866 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 ├
03-10 11:14:19.866 29394 29406 I Unity   : RegisterHandler id:34 handler:OnClientErrorInternal                                                                             │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.866 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.866 29394 29406 I Unity   : RegisterHandler id:39 handler:OnClientSceneInternal                                                                             │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.866 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.866 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.887 29394 29406 I Unity   : Registering prefab 'DummyPlayer' as asset:09a71469cca77bc4f89e3fe745bf86a9     
03-10 11:14:19.887 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.887 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.887 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.891 29394 29406 I Unity   : Registering prefab 'A' as asset:03e03a64232c84b98afccf5819592527                                                                │
03-10 11:14:19.891 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.891 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.891 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.891 29394 29406 I Unity   : NetworkManager StartClient address:::ffff:192.168.0.2 port:7777                                                                 │
03-10 11:14:19.891 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.891 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.891 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:3 handler:OnObjectSpawn                                                                                  ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:10 handler:OnObjectSpawnScene                                                                            ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:12 handler:OnObjectSpawnFinished                                                                         ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:1 handler:OnObjectDestroy                                                                                ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:13 handler:OnObjectDestroy                                                                               │
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.896 29394 29406 I Unity   : RegisterHandlerSafe id:8 handler:OnUpdateVarsMessage                                                                            │
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.896 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.896 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:4 handler:OnOwnerMessage                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 ├
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:9 handler:OnSyncListMessage                                                                              │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:40 handler:OnAnimationClientMessage                                                                      │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:41 handler:OnAnimationParametersClientMessage                                                            ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:15 handler:OnClientAuthority                                                                             ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:2 handler:OnRPCMessage
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:7 handler:OnSyncEventMessage                                                                             │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:42 handler:OnAnimationTriggerClientMessage                                                               │
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:14 handler:OnCRC                                                                                         ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.897 29394 29406 I Unity   : RegisterHandlerSafe id:17 handler:OnFragment                                                                                    ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.897 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.897 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.899 29394 29406 I Unity   : Client Connect: ::ffff:192.168.0.2:7777                                                                                         ┤
03-10 11:14:19.899 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.899 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.899 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.901 29394 29406 I Unity   : Async DNS START:::ffff:192.168.0.2                                                                                              ┤
03-10 11:14:19.901 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.901 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.901 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.911 29394 29406 E Unity   : host id out of bound id {-1} max id should be greater 0 and less than {1}                                                       │
03-10 11:14:19.911 29394 29406 E Unity   :                                                                                                                                 ┤
03-10 11:14:19.911 29394 29406 E Unity   : (Filename:  Line: 541)                                                                                                          ┤
03-10 11:14:19.911 29394 29406 E Unity   :                                                                                                                                 │
03-10 11:14:19.938 29394 29495 I Unity   : Async DNS Result:::ffff:192.168.0.2 for ::ffff:192.168.0.2: ::ffff:192.168.0.2                                                  │
03-10 11:14:19.938 29394 29495 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.938 29394 29495 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.938 29394 29495 I Unity   :                                                                                                                                 ┤
03-10 11:14:19.984 29394 29406 I Unity   : Client event: host=0 event=ConnectEvent error=0                                                                                 │
03-10 11:14:19.984 29394 29406 I Unity   :                                                                                                                                 ├
03-10 11:14:19.984 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.984 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.984 29394 29406 I Unity   : Client connected                                                                                                                │
03-10 11:14:19.984 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.984 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.984 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.986 29394 29406 I Unity   : NetworkManager:OnClientConnectInternal                                                                                          │
03-10 11:14:19.986 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.986 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.986 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.990 29394 29406 I Unity   : ClientScene::Ready() called with connection [hostId: 0 connectionId: 1 isReady: False channel count: 2]                         ┤
03-10 11:14:19.990 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.990 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:19.990 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.999 29394 29406 I Unity   : ClientScene::AddPlayer() for ID 0 called with connection [hostId: 0 connectionId: 1 isReady: True channel count: 2]             ┤
03-10 11:14:19.999 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:19.999 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:19.999 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.019 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0           
03-10 11:14:20.019 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.019 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.019 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.030 29394 29406 I Unity   : Script: TestA Channel: 0                                                                                                        │
03-10 11:14:20.030 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.030 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.030 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.066 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    │
03-10 11:14:20.066 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.066 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.066 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.069 29394 29406 I Unity   : SpawnFinished:0                                                                                                                 ┤
03-10 11:14:20.069 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.069 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.069 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.076 29394 29406 I Unity   : ClientScene::PrepareSpawnObjects sceneId:1                                                                                      ┤
03-10 11:14:20.076 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.076 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.076 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.086 29394 29406 I Unity   : Client spawn scene handler instantiating [netId:1 sceneId:1 pos:(0.0, 0.0, 0.0)                                                 ┤
03-10 11:14:20.086 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.086 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.086 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.089 29394 29406 I Unity   : Client spawn for [netId:1] [sceneId:1] obj:A                                                                                    │
03-10 11:14:20.089 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.089 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.089 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.093 29394 29406 I Unity   : SetLocalObject 1 A (UnityEngine.GameObject)                                                                                     ┤
03-10 11:14:20.093 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.093 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.093 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.095 29394 29406 I Unity   : SpawnFinished:1                                                                                                                 ┤
03-10 11:14:20.095 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.095 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.095 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.099 29394 29406 I Unity   : OnStartClient A (UnityEngine.GameObject) GUID:1 localPlayerAuthority:False                                                      ├
03-10 11:14:20.099 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.099 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.099 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.101 29394 29406 I Unity   : // A Starting on CLient with netId: 1  assetId: 03e03a64232c84b98afccf5819592527  
03-10 11:14:20.101 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.101 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.101 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.106 29394 29406 I Unity   : Client spawn handler instantiating [netId:2 asset ID:09a71469cca77bc4f89e3fe745bf86a9 pos:(0.0, 0.0, 0.0)]                      │
03-10 11:14:20.106 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.106 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.106 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:20.112 29394 29406 I Unity   : Client spawn handler instantiating [netId:2 asset ID:09a71469cca77bc4f89e3fe745bf86a9 pos:(0.0, 0.0, 0.0) rotation: (0.0, 0.0, 0│
03-10 11:14:20.112 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.112 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.112 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.116 29394 29406 I Unity   : SetLocalObject 2 DummyPlayer(Clone) (UnityEngine.GameObject)                                                                    ┤
03-10 11:14:20.116 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.116 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.116 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.116 29394 29406 I Unity   : OnStartClient DummyPlayer(Clone) (UnityEngine.GameObject) GUID:2 localPlayerAuthority:True                                      ┤
03-10 11:14:20.116 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.116 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.116 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.117 29394 29406 I Unity   : ClientScene::OnOwnerMessage - connectionId=1 netId: 2                                                                           ┤
03-10 11:14:20.117 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.117 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:20.117 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.119 29394 29406 W Unity   : ClientScene::InternalAddPlayer: playerControllerId : 0                                                                          │
03-10 11:14:20.119 29394 29406 W Unity   :                                                                                                                                 │
03-10 11:14:20.119 29394 29406 W Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.119 29394 29406 W Unity   :                                                                                                                                 │
03-10 11:14:20.124 29394 29406 I Unity   : // TestA: A -> default                                                                                                          ┤
03-10 11:14:20.124 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:20.124 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:20.124 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.054 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    ┤
03-10 11:14:21.054 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:21.054 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:21.054 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.056 29394 29406 I Unity   : ClientScene::OnRPCMessage hash:-1590938653 netId:1                                                                              ├
03-10 11:14:21.056 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.056 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:21.056 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.062 29394 29406 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   │
03-10 11:14:21.062 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.062 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:21.062 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.063 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    │
03-10 11:14:21.063 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.063 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:21.063 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:21.064 29394 29406 I Unity   : ClientScene::OnUpdateVarsMessage 1 channel:0                                                                                    │
03-10 11:14:21.064 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.064 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:21.064 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:21.755 29394 29406 I Unity   : // TestA: A -> default     
03-10 11:14:21.755 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:21.755 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:21.755 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:23.108 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    ┤
03-10 11:14:23.108 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:23.108 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:23.108 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.108 29394 29406 I Unity   : ClientScene::OnRPCMessage hash:-1590938653 netId:1                                                                              ┤
03-10 11:14:23.108 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.108 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:23.108 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.109 29394 29406 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   ┤
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.109 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.109 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    ┤
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.109 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:23.109 29394 29406 I Unity   : ClientScene::OnUpdateVarsMessage 1 channel:0                                                                                    │
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:23.109 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:23.109 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:23.426 29394 29406 I Unity   : // TestA: A -> default                                                                                                          ┤
03-10 11:14:23.426 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:23.426 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:23.426 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:24.781 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    ┤
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 ┤
03-10 11:14:24.781 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 ├
03-10 11:14:24.781 29394 29406 I Unity   : ClientScene::OnRPCMessage hash:-1590938653 netId:1                                                                              │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : // A ClientRPC called by server OK.  NetId: 1                                                                                   │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : Client event: host=0 event=DataEvent error=0                                                                                    │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : ClientScene::OnUpdateVarsMessage 1 channel:0                                                                                    │
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:24.781 29394 29406 I Unity   : (Filename: /Users/builduser/buildslave/unity/build/artifacts/generated/common/runtime/DebugBindings.gen.cpp Line: 51)           ┤
03-10 11:14:24.781 29394 29406 I Unity   :                                                                                                                                 │
03-10 11:14:25.097 29394 29406 I Unity   : // TestA: A -> default    
```
 
