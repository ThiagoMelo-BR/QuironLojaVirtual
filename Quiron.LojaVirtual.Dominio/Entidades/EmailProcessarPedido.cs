using System.Net;
using System.Net.Mail;
using System.Text;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            _emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = true;                
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario,_emailConfiguracoes.Senha,  _emailConfiguracoes.ServidorSmtp);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido")
                .AppendLine("-------------------")
                .AppendLine("Itens");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subtotal = item.Quantidade * item.Produto.Preco;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Quantidade, item.Produto.Nome, subtotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c}", carrinho.ObterValorTotalCarrinho())
                    .AppendLine("-------------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("-------------------")
                    .AppendFormat("Para presente?: {0}", pedido.EmbrulhaParaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(_emailConfiguracoes.De, 
                                                          _emailConfiguracoes.Para, 
                                                          "Novo Pedido", 
                                                          body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
