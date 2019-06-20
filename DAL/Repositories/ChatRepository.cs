using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly Context context;

        public ChatRepository(Context context)
        {
            this.context = context;
        }

        public Chat CreateChat(Chat chat)
        {
            context.Chats.Add(chat);
            context.SaveChanges();

            return chat;
        }

        public Chat GetChatById(string id)
        {
            return context.Chats.Include(x => x.UserChats).Include(x => x.Messages).SingleOrDefault(x => x.Id == id);
        }

        public void UpdateChat(Chat chat)
        {
            context.Chats.Update(chat);
            context.SaveChanges();
        }
    }
}
