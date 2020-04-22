using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class SpecialToken : IState
    {
        MainForm mainForm;
        public SpecialToken(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void UpdateState()
        {
            throw new NotImplementedException();
        }
    }
}
