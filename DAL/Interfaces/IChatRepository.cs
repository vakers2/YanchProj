using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IChatRepository
    {
        Chat CreateChat(Chat chat);

        Chat GetChatById(string id);

        void UpdateChat(Chat chat);
    } 
}
