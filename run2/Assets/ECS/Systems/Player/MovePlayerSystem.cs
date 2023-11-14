using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
namespace Client {
    sealed class MovePlayerSystem : IEcsRunSystem {  
        readonly EcsFilterInject<Inc<MoveComponent,JOInput>> _filterPL = default; // находим все сущности сдержащие компонент MoveCom  
        readonly EcsPoolInject<JOInput> _JOInput = default;    
        readonly EcsPoolInject<MoveComponent>_MoveComponent   = default;  
        public void Run (IEcsSystems systems) {
            foreach(int Player in _filterPL.Value)
            {
                ref var _moveComponent=ref _MoveComponent.Value.Get(Player);
                 ref var joInput= ref _JOInput.Value.Get(Player);                
                _moveComponent.transform.Translate(new UnityEngine.Vector3(joInput.jOtoch.GetDirection(),0,1)*Time.deltaTime*_moveComponent.speed);
            }
        }
    }
}