using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class UpdateFlashcardsListPracticeProps : IUpdateFlashcardsListPracticeProps
    {
        public UpdateFlashcardsListPracticeProps(IUpdateFlashcardPracticeProperties updateFlashcardPracticeProperties)
        {
            UpdateFlashcardPracticeProperties = updateFlashcardPracticeProperties;
        }

        public IUpdateFlashcardPracticeProperties UpdateFlashcardPracticeProperties { get; }

        public void Update(List<FlashcardDbModel> flashcardDbModels)
        {
            foreach(var item in flashcardDbModels)
            {
                UpdateFlashcardPracticeProperties.UpdateAsync(item);
            }
        }
    }
}
