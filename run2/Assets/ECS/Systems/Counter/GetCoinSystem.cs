using System.Numerics;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
namespace Client {
    sealed class GetCoinSystem : IEcsRunSystem {   
         readonly EcsFilterInject<Inc<GetCoin>> _filterCoin = default; 
        readonly EcsPoolInject<GetCoin> _GetCoin=default; 
        public void Run (IEcsSystems systems) {
            CountCoin countCoin = systems.GetShared<CountCoin> ();
            foreach(var entity in _filterCoin.Value)
            {
                countCoin.NumberCoin++;
               _GetCoin.Value.Del(entity);
            }
        }
    }
}