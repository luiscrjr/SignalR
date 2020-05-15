using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.Mvc.Hubs
{
    public class AvaliationHub : Hub
    {
        // método responsável por gerenciar as notificações
        public async Task Send(string mensagem)
        {
            //propagando a mensagem para os clientes do Hub
            await Clients.All.SendAsync("Send", mensagem);
        }
    }
}
