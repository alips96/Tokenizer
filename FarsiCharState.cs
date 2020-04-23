using System;
using System.Linq;

namespace TokenizerProject
{
    public class FarsiCharState : IGetBackToInitialState
    {
        MainForm mainForm;
        public FarsiCharState(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }

        public void ToInitialState()
        {
            mainForm.currentState = mainForm.initialState;
        }

        public void UpdateState()
        {
            CheckForInput();
        }

        private void CheckForInput()
        {
            if (mainForm.plainTextQueue.Count > 0)
            {
                int currentChar = mainForm.plainTextQueue.First(); //finds the first element of queue.

                if ((currentChar >= 1570 && currentChar <= 1607) || //if it is a farsi character.
                        currentChar == 1662 ||
                        currentChar == 1705 ||
                        currentChar == 1711 ||
                        currentChar == 1608 ||
                        currentChar == 1662 ||
                        currentChar == 1740 ||
                        currentChar == 1670 ||
                        currentChar == 1548 ||
                        currentChar == 8204) //Half_space
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
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "Farsi Letter Token"));
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
