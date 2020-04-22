using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class Digit : IGetBackToInitialState
    {
        MainForm mainForm;
        public Digit(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        public void ToDigitDotState()
        {
            mainForm.currentState = mainForm.digitDotState;
        }

        public void UpdateState()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (mainForm.plainTextQueue.Count > 0)
            {
                int currentChar = mainForm.plainTextQueue.Last(); //finds the first element of queue.

                if (currentChar == 46) //if it is a '.'
                {
                    mainForm.plainTextQueue.Dequeue();
                    ExtendCurrentToken();
                    ToDigitDotState();
                }
                else
                    if (currentChar >= 48 && currentChar <= 57) //if it is a number again.
                {
                    mainForm.plainTextQueue.Dequeue();
                    ExtendCurrentToken();
                }
                else
                {
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
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "Digit Token"));
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
