namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = true;
        public string ServidorSmtp = "smtp.gmail.com";
        public int ServidorPorta = 587;
        public string Usuario = "tthiagoalvesmelo@gmail.com";
        public string PastaArquivo = @"c:\EnvioEmail";
        public bool EscreverArquivo = true;
        public string De = "tthiagoalvesmelo@gmail.com";
        public string Para = "thiago.melo@outlook.com.br";
        public string Senha = "AdmSenac2129949";
    }
}
