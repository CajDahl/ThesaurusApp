namespace ThesaurusApp.Helpers
{
    /// <summary>
    /// Represents a thesaurus dictionary.
    /// </summary>
    public interface IWordsInstance
    {
        /// <summary>
        /// Get and set the dictionary thesaurus
        /// </summary>
        Dictionary<string, List<string>> WordsList { get; set; }
    }
}