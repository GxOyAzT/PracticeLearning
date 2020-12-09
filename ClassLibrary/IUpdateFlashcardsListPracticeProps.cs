using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    interface IUpdateFlashcardsListPracticeProps
    {
        public void Update(List<FlashcardDbModel> flashcardDbModels);
    }
}
