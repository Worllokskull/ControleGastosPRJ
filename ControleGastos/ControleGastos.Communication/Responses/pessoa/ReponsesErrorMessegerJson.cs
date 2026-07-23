namespace ControleGastos.Communication.Responses.pessoa
{
    public class ReponsesErrorMessegerJson
    {
        public List<string> Errors { get; private set; }
        public ReponsesErrorMessegerJson(string message)
        {
            Errors = [message]; 
        }
        public ReponsesErrorMessegerJson(List<string> messages)
        {
            Errors = messages;
        }
    }
}
