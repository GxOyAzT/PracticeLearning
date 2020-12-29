using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPractice
{
    public class MyViewViewModel
    {
        public Guid SelectedFlashcardIdForDelete { get; set; }
        public List<ObjectModel> ObjectModels { get; set; }
    }
}
