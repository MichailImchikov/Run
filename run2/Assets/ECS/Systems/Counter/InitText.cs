using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.UI;
namespace Client {
    sealed class InitText : IEcsInitSystem {
        public void Init (IEcsSystems systems) {
            var _Text = GameObject.FindGameObjectWithTag("CountText");
            var world=systems.GetWorld();//создаем ссылку на мир

                    var entity=world.NewEntity();//создаем новую сущность
                    ref var _text =ref world.GetPool<TextComponent>().Add(entity);
                    _text.text=_Text.GetComponent<Text>();
        }
    }
}