using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace Client {
    sealed class WriteTextSystem : IEcsRunSystem {  
        readonly EcsFilterInject<Inc<TextComponent>> _filter = default;     
        readonly EcsPoolInject<TextComponent> _TextComponent = default;    
        public void Run (IEcsSystems systems) 
        {
            foreach(int item in _filter.Value)
            {
                ref var _textComponent= ref _TextComponent.Value.Get(item);
                CountCoin countCoin = systems.GetShared<CountCoin> ();
                _textComponent.text.text=$"Number of coin :{countCoin.NumberCoin} ";
            }
        }
    }
}