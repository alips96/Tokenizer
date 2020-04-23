using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenizerProject
{
    public class Sharp : IGetBackToInitialState
    {
        MainForm mainForm;
        public Sharp(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        private void ToHashtagState()
        {
            mainForm.currentState = mainForm.hashtagState;
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

                if (currentChar >= 65 && currentChar <= 90 || //if it is an english character.
                   (currentChar >= 97 && currentChar <= 122))
                {
                    ExtendCurrentToken();
                    ToHashtagState();
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
