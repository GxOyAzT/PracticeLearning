using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class UpdateFlashcardPracticeProperties : IUpdateFlashcardPracticeProperties
    {
        public async Task UpdateAsync(FlashcardDbModel flashcardDbModel)
        {
            using (var db = new FlashcardsDbContext())
            {
                FlashcardDbModel fdb = db.FlashcardsDbModels.Find(flashcardDbModel);

                fdb.CorreactAnsInRow = flashcardDbModel.CorreactAnsInRow;
                fdb.NextPracticeDate = flashcardDbModel.NextPracticeDate;

                await db.SaveChangesAsync();
            }
        }
    }
}
