using ThesaurusApp.BusinessLogic;
using ThesaurusApp.Helpers;

namespace ThesaurusApp
{
    /// <summary>
    /// Start application with run three difference funktions.
    //  1 = Add synonyms
    //  2 = Get synonyms for word
    //  3 = Get all words in the ´thesaurus
    /// </summary>
    class App
    {
        private readonly IWordsInstance _wordsInstance;

        public App(IWordsInstance wordsInstance)
        {
            _wordsInstance = wordsInstance;
        }
        public void Run(string[] args)
        {

            Console.WriteLine("Välj funktion");
            Console.WriteLine("1 = Lägg till synonymer");
            Console.WriteLine("2 = Synonym för givet ord");
            Console.WriteLine("3 = Lista alla ord i synonymordlistan");
            Console.WriteLine("Tryck enter för exit");
            string input = "0";
            do
            {              
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Console.Write("Lägg till ord i synonymordlistan: ");
                            string? wordlist = Console.ReadLine();
                            if (wordlist == null)
                            {
                                Console.WriteLine("Inga ord är valda att läggas till i synonymordlistan.");
                            };
                            var words = wordlist.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x);
                            if (!words.Any())
                            {
                                Console.WriteLine("Inga ord är valda att läggas till i synonymordlistan.");
                            }
                            var objadd = new Thesaurus(_wordsInstance);
                            objadd.AddSynonyms(words);
                            Console.WriteLine("Ord tillagda");
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Välj ett ord: ");
                            string? wordget = Console.ReadLine();
                            var objadd = new Thesaurus(_wordsInstance);
                            var result = objadd.GetSynonyms(wordget);
                            if (!result.Any())
                            {
                                Console.WriteLine("Ordet finns ej med i synonymordlistan.");
                            }
                            else
                            {
                                var wordslist = string.Join(" ", result);
                                Console.WriteLine("Synonymer till ordet " + wordget + ": " + wordslist);
                            }
                            break;
                        }
                    case "3":
                        {
                            var objadd = new Thesaurus(_wordsInstance);
                            var result = objadd.GetWords();
                            if (!result.Any())
                            {
                                Console.WriteLine("Inga orde i synonymordlistan.");
                            }
                            else
                            {
                                var wordslist = string.Join(" ", result);
                                Console.WriteLine("Alla ord i synonymordlistan: " + wordslist);
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(input);
                            return;
                        }

                }
            } while (input == "1" || input == "2" || input == "3");
        }
    }
}
