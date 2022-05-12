public class Source
{
    // member variables
    private string name = "";
    private string url = "";

    // public Source() is my constructor because it has the same name as class.
    // Have to specify that the parameters are strings because they are only local to that 
    //  constructor and not globally like the member variables.
    // Pass default "" for url in case source doesn't have url.
    // this.name = name assigns member variable value of name passed into constructor.
    // If you call the parameter name "n" rather than "name", then you could just say name = n.
    public Source(string name, string url="")
    {
        this.name = name;
        this.url = url;
    }
    
    // Returns the member variable "name" when this method is called in another class or program.
    public string getName()
    {
        return name;
    }

    // Returns the member variable "url" when this method is called in another class or program.
    public string getUrl()
    {
        return url;
    }
}