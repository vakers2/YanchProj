using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

namespace Vue2Spa.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IHubContext<ChatHub> chatHub;
        private readonly IChatRepository chatRepository;
        private readonly IUserRepository userRepository;
        private readonly HttpContext httpContext;

        public ChatHub(IHubContext<ChatHub> chatHub, IChatRepository chatRepository, IUserRepository userRepository, HttpContext httpContext)
        {
            this.chatHub = chatHub;
            this.chatRepository = chatRepository;
            this.userRepository = userRepository;
            this.httpContext = httpContext;
        }

        public async Task ConnectToChatAsync(string chatId, string name)
        {
            var chat = chatRepository.GetChatById(chatId);
            var user1 = userRepository.CheckUser(httpContext.User.Identity.Name);
            var user2 = userRepository.CheckUser(name);
            if (chat != null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
            }

            chat = new Chat();
            var userChats = new List<UserChat>
            {
                new UserChat
                {
                    User = user1,
                    Chat = chat
                },
                new UserChat
                {
                    User = user2,
                    Chat = chat
                }
            };

            chat.UserChats = userChats;
            chat = chatRepository.CreateChat(chat);

            await Groups.AddToGroupAsync(Context.ConnectionId, chat.Id);
        }

        public async Task SendMessageAsync(string chatId, string name, string text)
        {
            var chat = chatRepository.GetChatById(chatId);
            var user = userRepository.CheckUser(name);
            chat.Messages.Add(new Message
            {
                CreationTime = DateTime.Now,
                Sender = user,
                Text = text
            });
            chatRepository.UpdateChat(chat);
            await Clients.Group(chatId).SendAsync("get_message", new { sender = user.Name, date = DateTime.Now, text });
        }
    }
}
