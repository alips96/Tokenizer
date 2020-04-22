using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class RealNumber : IState
    {
        MainForm mainForm;
        public RealNumber(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
