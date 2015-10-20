using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace Task_width_adjustment
{
    class MyLittleMSWord
    {
        private ITextJustifer itj;
        public MyLittleMSWord()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ITextJustifer, VoloshynTextJustifier>(new ContainerControlledLifetimeManager());
            itj = container.Resolve<ITextJustifer>();
        }

        public string MakeSomeStringMagic(string text, int maxLineWidth)
        {
            return itj.Justify(text, maxLineWidth);
        }
    }
}
