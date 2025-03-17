using ThesaurusApp.Helpers;

namespace ThesaurusApp.BusinessLogic
{
    /// <summary>
    /// Represents a thesaurus dictionary.
    /// </summary>
    public class WordsInstance : IWordsInstance
    {
        /// <summary>
        /// Initiate the dictionary thesaurus
        /// </summary>
        public Dictionary<string, List<string>> WordsList { get; set; }
        public WordsInstance()
        {
            WordsList = new Dictionary<string, List<string>>()
            {
                 {"decimera", ["minska", "reducera", "nedbringa"]  },
                 {"minska", ["decimera", "reducera", "nedbringa"] },
                 {"reducera", ["decimera", "minska", "nedbringa"] },
                 {"nedbringa", ["decimera", "minska", "reducera"] },
                 {"alla", ["samtliga"] },
                 {"samtliga", ["alla"] },
            };
        }
    }
}
