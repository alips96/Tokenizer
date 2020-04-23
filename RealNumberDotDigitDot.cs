using System;
using System.Linq;

namespace TokenizerProject
{
    public class RealNumberDotDigitDot : IGetBackToInitialState
    {
        MainForm mainForm;
        public RealNumberDotDigitDot(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        private void ToIPAddressState()
        {
            mainForm.currentState = mainForm.ipAddressState;
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
                    ToIPAddressState();
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
        }
    }
}
