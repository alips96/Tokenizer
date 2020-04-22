using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class UnknownToken : IGetBackToInitialState
    {
        MainForm mainForm;
        public UnknownToken(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            throw new NotImplementedException();
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
