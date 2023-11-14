using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Leopotam.EcsLite.ExtendedSystems;
namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;        
        IEcsSystems _systems;

        void Start () {
            _world = new EcsWorld ();
            CountCoin countCoin=new CountCoin();
            _systems = new EcsSystems (_world,countCoin);
            _systems
                // register your systems here, for example:
                .Add (new InitPlayer ())
                ////.Add(new InitCamera())
                .Add(new InitText())
                .Add(new DoorInit())
                //.Add(new JoustickInit())
                ////.Add (new MoveForwardCamera ())
                //.Add(new UzerInputSystem())
                //.Add(new JosticGetData())
                .Add(new SpeedUpSystem())
                //.Add(new BrigeUpSystem())
                //.Add(new BridgeUpStopSystem())
                .Add(new JumpSystem())
                .Add(new MovePlayerSystem())
                .Add(new OpenDoorSystem())
                .Add(new GetCoinSystem())
                .Add(new WriteTextSystem())
                // register additional worlds here, for example:
                // .AddWorld (new EcsWorld (), "events")
#if UNITY_EDITOR
                // add debug systems for custom worlds here, for example:
                // .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ("events"))
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Inject()
                .Init ();
        }

        void Update () {
            // process systems here.
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }
            
            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}