using Leopotam.EcsLite;
using UnityEngine;
namespace Client {
    sealed class DoorInit : IEcsInitSystem {
        public void Init (IEcsSystems systems) {
            var go = GameObject.FindGameObjectsWithTag("Door");
            var world=systems.GetWorld();//создаем ссылку на мир
            foreach(var item in go)
            {
                var entity=world.NewEntity();//создаем новую сущность
                ref var _animator =ref world.GetPool<AnimatorComponent>().Add(entity);
                _animator.animator=item.GetComponent<Animator>();
            }
                    
                    
        }
    }
}