using Leopotam.EcsLite;
using UnityEngine;
namespace Client
{
    sealed class InitPlayer : IEcsInitSystem {
        public void Init (IEcsSystems systems) {
             var Player = GameObject.FindGameObjectWithTag("Player");
             var JO = GameObject.FindGameObjectWithTag("joystick");
            var world=systems.GetWorld();//создаем ссылку на мир

                    var entity=world.NewEntity();//создаем новую сущность
                    ref var _target =ref world.GetPool<MoveComponent>().Add(entity);
                    _target.rigidbody=Player.GetComponent<Rigidbody>();
                    _target.speed=5f;
                    _target.transform=Player.transform;

                    ref var _joInput =ref world.GetPool<JOInput>().Add(entity);
                    _joInput.jOtoch=JO.GetComponent<JOtoch>();

                    var CoinScript=Player.GetComponent<CollisionMen>();
                    CoinScript.GetWorldCoin(world);
        }
    }

}