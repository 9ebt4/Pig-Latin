
Console.WriteLine("Welcome to the Pig Latin Translator.");
bool loop = true;

while (loop)
{
    Console.WriteLine("Type a word you would like translated.");
    string sentence = Console.ReadLine().Trim();
    string[] words = sentence.Split(" ");
    
    foreach (string word in words)
    {
        string pigWord = null;
        string pun = null;
        bool nextWord = true;
        foreach (char wo in word)
        {
            if (char.IsPunctuation(wo))
            {
                pun = Convert.ToString(wo);
                word.Append(wo);
            }
            if (char.IsDigit(wo))
            {
                pigWord = word;
                nextWord = false;
                break;
            }
            else if (char.IsSymbol(wo))
            {
                pigWord = word;
                nextWord = false;
                break;
            }
            else
            {
                nextWord = true;
            }
            //determine if letter is a vowel
            while (nextWord == true)
            {
                if (LetterChecker(word))
                {
                    pigWord = string.Concat(word, "way");
                    nextWord = false;
                }//operate on all other symbols
                else
                {

                    int lCounter = 0;
                    string letter = null;
                    foreach (char w in word)
                    {
                        letter = w.ToString();//turn char into string so LetterChecker can find vowels.


                        if (LetterChecker(letter) || letter == "y")//strip consonants up to first vowel.
                        {
                            string rWord = word.Substring(lCounter);
                            string cWord = word.Substring(0, lCounter);
                            string pWord = string.Concat(rWord, cWord);
                            pigWord = string.Concat(pWord, "ay");
                            nextWord = false;
                            break;
                        }
                        else//count number of consonants
                        {
                            lCounter++;
                        }
                    }
                }
            }
        }
        Console.Write(pigWord + " ");
        Console.WriteLine(pun + " ");
    }

        while (true)
        {
            Console.WriteLine("\nTranslate more? (y/n)");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                loop = true;
                break;
            }
            else if (ans == "n")
            {
                loop = false;
                break;
            }
            else
            {
                Console.WriteLine("enter y/n");
            }
        }

    }

Console.WriteLine("Bye");
static bool LetterChecker(string x)
{
    x.ToLower();
    return (x.StartsWith("a") || x.StartsWith("e") || x.StartsWith("i") || x.StartsWith("o") || x.StartsWith("u"));
}
