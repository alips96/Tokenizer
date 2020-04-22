using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class DigitDot : IState
    {
        MainForm mainForm;
        public DigitDot(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
