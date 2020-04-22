using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class RealNumberDotDigitDot : IState
    {
        MainForm mainForm;
        public RealNumberDotDigitDot(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
