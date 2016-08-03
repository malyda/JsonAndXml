namespace JSON
{
    interface IDB
    {
        string readAll();
        bool write(string xmlTo);
    }
}