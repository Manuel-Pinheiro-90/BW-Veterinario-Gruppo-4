namespace BW_Clinica_Veterinaria.Interface
{
    public interface IPasswordEncoder
    {
        string Encode(string password);
        bool IsSame(string plainText, string codedText);
    }
}
