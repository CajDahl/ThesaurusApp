using ThesaurusApp.Helpers;

namespace ThesaurusApp.BusinessLogic
{
    /// <summary>
    /// Methode for Thesaurus
    /// </summary>
    public class Thesaurus : IThesaurus
    {
        private readonly IWordsInstance _wordsInstance;

        public Thesaurus(IWordsInstance wordsInstance)
        {
            _wordsInstance = wordsInstance;
        }

        /// <summary>
        /// Add synonyms to thesaurus
        /// </summary>
        /// <param name="synonyms"></param>
        public void AddSynonyms(IEnumerable<string> synonyms)
        {
            var words = synonyms.Distinct().ToList();
            foreach (var word in words)
            {
                var wordsynonyms = words.Where(x => x != word);
                if (!_wordsInstance.WordsList.ContainsKey(word))
                {
                    List<string> wordadd = new List<string>();
                    wordadd.AddRange(wordsynonyms);
                    _wordsInstance.WordsList.Add(word, wordadd);
                }
                else
                {
                    foreach (var synonym in wordsynonyms)
                    {
                        if (!_wordsInstance.WordsList[word].Contains(synonym))
                            _wordsInstance.WordsList[word].Add(synonym);
                    }
                }

            }
        }

        /// <summary>
        /// Adds the given synonyms to the thesaurus
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public IEnumerable<string> GetSynonyms(string word)
        {
            if (_wordsInstance.WordsList.ContainsKey(word))
                return _wordsInstance.WordsList[word];
            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Gets all words from the thesaurus.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetWords()
        {
            if (_wordsInstance.WordsList.Count != 0)
                return _wordsInstance.WordsList.AsEnumerable().Select(x => x.Key).ToList();
            return Enumerable.Empty<string>();
        }
    }
}
