﻿using System;
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
                int currentChar = mainForm.plainTextQueue.First(); //finds the first element of queue.

                if ((currentChar >= 65 && currentChar <= 90) || //if it is an english character.
                        (currentChar >= 97 && currentChar <= 122) ||
                        currentChar == 44) // if it is a ','
                {
                    //mainForm.plainTextQueue.Dequeue();
                    //ExtendCurrentToken();
                    //ToDigitDotState();
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
            mainForm.tokensList.Add(new Token(mainForm.currentToken, "English Letter Token"));
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
