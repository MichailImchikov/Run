using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class JumpSystem : IEcsRunSystem { 
        readonly EcsFilterInject<Inc<MoveComponent,JOInput>> _filterPL = default;     
        readonly EcsFilterInject<Inc<Jump>> _filterJump = default;    
        readonly EcsPoolInject<MoveComponent>_MoveComponent   = default;  
         readonly EcsPoolInject<Jump>_Jump   = default;
        public void Run (IEcsSystems systems) 
        {
            foreach(int i in _filterJump.Value)
            {
                foreach(int p in _filterPL.Value)
                {
                    ref var _moveComponent= ref  _MoveComponent.Value.Get(p);
                    _moveComponent.rigidbody.AddForce(0,600,0);
                }
                _Jump.Value.Del(i);
            }
        }
    }
}