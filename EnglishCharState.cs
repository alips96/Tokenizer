using System.Linq;

namespace TokenizerProject
{
    public class EnglishCharState : IGetBackToInitialState
    {
        MainForm mainForm;
        public EnglishCharState(MainForm _mainForm)
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
                int currentChar = mainForm.plainTextQueue.Dequeue(); //extracts the first element of queue.            

                if (currentChar == 32) //if it is a space.
                {
                    ExtendCurrentToken();
                    WriteCurrentTokenInList();
                    ToInitialState();
                }
                else
                    if ((currentChar >= 33 && currentChar <= 47) ||  //if it is a special character.
                    (currentChar >= 58 && currentChar <= 64) ||
                    currentChar >= 91 && currentChar <= 96 ||
                    currentChar >= 123 && currentChar <= 126)
                {
                    WriteCurrentTokenInList();
                    mainForm.currentToken += mainForm.tokensLinkedList.First();
                    mainForm.tokensLinkedList.RemoveFirst();
                    mainForm.tokensList.Add(new Token(mainForm.currentToken, "Special Token"));
                    mainForm.currentToken = null;
                    ToInitialState();
                }
                else
                {
                    ExtendCurrentToken();
                }
            }
            else
            {
                if(mainForm.currentToken != null)
                {
                    WriteCurrentTokenInList();
                }

                mainForm.isFinished = true; // Stops the Main While of program.
            }
        }

        private void WriteCurrentTokenInList()
        {
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "English Char Token"));
            mainForm.currentToken = null;
        }

        private void ExtendCurrentToken()
        {
            if(mainForm.tokensLinkedList.First() != ' ')
            {
                mainForm.currentToken += mainForm.tokensLinkedList.First();
            }

            mainForm.tokensLinkedList.RemoveFirst();

            if(mainForm.tokensLinkedList.Count == 0)
            {
                WriteCurrentTokenInList();
            }
        }
    }
}
