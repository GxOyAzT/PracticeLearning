using Models;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public interface IUpdateFlashcardPracticeProperties
    {
        Task UpdateAsync(FlashcardDbModel flashcardDbModel);
    }
}
