using PBFramework.Dependencies;
using Coffee.UIExtensions;

namespace PBFramework.Graphics.Effects.CoffeeUI
{
    public class DissolveEffect : BaseCoffeeEffect<UIDissolve> {

        public override bool UsesMaterial => true;


        [InitWithDependency]
        private void Init()
        {
            Component.effectFactor = 0f;
        }
    }
}