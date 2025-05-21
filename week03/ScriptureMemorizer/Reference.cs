public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }
    public int? EndVerse { get; } // Nullable for multi-verse support

    public Reference(string book, int chapter, int verse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
        EndVerse = endVerse;
    }

    public string GetDisplayText()
    {
        return EndVerse.HasValue ? $"{Book} {Chapter}:{Verse}-{EndVerse}" : $"{Book} {Chapter}:{Verse}";
    }
}
