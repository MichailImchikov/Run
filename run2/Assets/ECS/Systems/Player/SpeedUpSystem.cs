using System;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class SpeedUpSystem : IEcsRunSystem {        
         readonly EcsFilterInject<Inc<SpeedUp>> _filterUp = default; 
         readonly EcsFilterInject<Inc<MoveComponent,JOInput>> _filterMove=default;  
        readonly EcsPoolInject<MoveComponent> _MoveComponent = default;  
        readonly EcsPoolInject<SpeedUp> _SpeedUp = default; 
        public void Run (IEcsSystems systems) {
            foreach(int Level in _filterUp.Value)
            {
                foreach(int Player in _filterMove.Value)
                {
                    ref var _moveComponent=ref _MoveComponent.Value.Get(Player);
                    _moveComponent.speed= _moveComponent.speed*1.2f;
                }
                _SpeedUp.Value.Del(Level);
            }
        }
    }
}