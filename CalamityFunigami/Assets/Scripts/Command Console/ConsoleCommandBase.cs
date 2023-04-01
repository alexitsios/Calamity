public abstract class ConsoleCommandBase
{
    //the string that must be typed into the console to call the command
    private string m_commandID;
    //a description of the command for ease of use
    private string m_commandDescription;
    //how the input string should be formatted. This will be identical to commandID unless also passing an additional variable such as a float/int
    private string m_commandFormat;

    public string CommandID => m_commandID;
    public string CommandDescription => m_commandDescription;
    public string CommandFormat => m_commandFormat;

    public ConsoleCommandBase(string id, string description, string format)
    {
        m_commandID = id;
        m_commandDescription = description;
        m_commandFormat = format;
    }

    public abstract void Invoke(string[] args);
}