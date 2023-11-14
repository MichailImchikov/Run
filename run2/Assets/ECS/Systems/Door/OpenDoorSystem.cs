using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class OpenDoorSystem : IEcsRunSystem { 
        readonly EcsFilterInject<Inc<OpenDoor>> _filterEvent = default;     
        readonly EcsFilterInject<Inc<AnimatorComponent>> _filterAnim = default;    
        readonly EcsPoolInject<OpenDoor>_OpenDoor   = default;  
         readonly EcsPoolInject<AnimatorComponent>_AnimatorComponent   = default;
        public void Run (IEcsSystems systems) 
        {
            foreach(int i in _filterEvent.Value)
            {
                foreach(int p in _filterAnim.Value)
                {
                    ref var _animatorComponent= ref  _AnimatorComponent.Value.Get(p);
                    _animatorComponent.animator.enabled=true;
                }
                _OpenDoor.Value.Del(i);
            }
        }
    }
}