using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class FlashcardDbModel
    {
        public Guid Id { get; set; }
        public PracticeDirection PracticeDirection { get; set; }
        public string NativeLanguage { get; set; }
        public string ForeignLanguage { get; set; }
        public int? CorreactAnsInRow { get; set; }
        public DateTime NextPracticeDate { get; set; }
        public Guid GroupDbModelId { get; set; }
        

        public virtual GroupDbModel GroupDbModel { get; set; }
    }
}
