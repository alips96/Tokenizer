using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class RealNumberDotDigit : IGetBackToInitialState
    {
        MainForm mainForm;
        public RealNumberDotDigit(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        private void ToRealNumberDotDigitDotState()
        {
            mainForm.currentState = mainForm.realNumberDotDigitDotState;
        }

        public void UpdateState()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (mainForm.plainTextQueue.Count > 0)
            {
                int currentChar = mainForm.plainTextQueue.Dequeue(); //finds the first element of queue.

                if (currentChar >= 48 && currentChar <= 57) //if it is a digit
                {
                    ExtendCurrentToken();
                }
                else
                    if(currentChar == 46) //if it is a '.'
                {
                    ExtendCurrentToken();
                    ToRealNumberDotDigitDotState();
                }
                else
                {
                    ExtendCurrentToken();
                    WriteCurrentTokenInList();
                    ToInitialState();
                }
            }
            else
            {
                if (mainForm.currentToken != null)
                {
                    WriteCurrentTokenInList();
                }

                mainForm.isFinished = true; // Stops the Main While of program.
            }
        }

        private void WriteCurrentTokenInList()
        {
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "Unknown Token"));
            mainForm.currentToken = null;
        }

        private void ExtendCurrentToken()
        {
            int ascii = Convert.ToInt32(mainForm.tokensLinkedList.First());

            if (!(ascii > 0 && ascii <= 32))
            {
                mainForm.currentToken += mainForm.tokensLinkedList.First();
            }

            mainForm.tokensLinkedList.RemoveFirst();

            //if (mainForm.tokensLinkedList.Count == 0)
            //{
            //    WriteCurrentTokenInList();
            //}
        }
    }
}
