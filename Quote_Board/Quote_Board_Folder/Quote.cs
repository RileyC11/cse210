
public class Quote
{
    // member variables
    private string author = "";
    private string quote = "";
    private Source source;

    // constructor for Quote
    public Quote(string author, string quote, Source source)
    {
        this.author = author;
        this.quote = quote;
        this.source = source;
    }

    // Checks to see if the uppercased name matches my uppercased author.
    public bool HasAuthor(string name)
    {
        if (author.ToUpper().Contains(name.ToUpper()))
        {
            return true;
        }
        return false;
    }

    public string GetQuote()
    {
        string url = source.getUrl();
        url = url != "" ? $"[{url}]" : "";

        // Does the same thing as the url = url ... but this shows what is actually happening.
        // if (url != "")
        // {
        //     url = $"[{url}]";
        // }
        // else
        // {
        //     url = "";
        // }

        return $"\"{quote}\"\n{author} - {source.getName()}{url}";
    }
}