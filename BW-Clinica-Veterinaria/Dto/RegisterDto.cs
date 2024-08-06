namespace BW_Clinica_Veterinaria.Dto
{
    public class RegisterDto
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Ruolo { get; set; } //veterinario o farmacista
    }
}
