using PBFramework.Dependencies;
using Coffee.UIExtensions;

namespace PBFramework.Graphics.Effects.CoffeeUI
{
    public class HsvEffect : BaseCoffeeEffect<UIHsvModifier>
    {
        public override bool UsesMaterial => true;


        [InitWithDependency]
        private void Init()
        {
            Component.range = 0f;
        }
    }
}