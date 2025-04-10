﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialNetwork.Data;
using SocialNetwork.DataProcessor.ExportDTOs;
using SocialNetwork.Utilities;
using System.Globalization;

namespace SocialNetwork.DataProcessor
{
    public class Serializer
    {
        public static string ExportUsersWithFriendShipsCountAndTheirPosts(SocialNetworkDbContext dbContext)
        {
            var friendships = dbContext.Friendships
                .ToList();

            var users = dbContext.Users
                .OrderBy(u => u.Username)
                .Include(u => u.Posts)
                .ToList()
                .Select(u => new ExportUserDto
                {
                    Friendships = friendships.Count(f => f.UserOneId == u.Id || f.UserTwoId == u.Id),
                    Username = u.Username,
                    Posts = u.Posts
                            .OrderBy(p => p.Id)
                            .Select(p => new ExportPostDto
                            {
                                Content = p.Content,
                                CreatedAt = p.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")
                            })
                            .ToList()
                })
                .ToList();

            var result = XmlHelper.Serialize(users, "Users");
            return result;
        }

        public static string ExportConversationsWithMessagesChronologically(SocialNetworkDbContext dbContext)
        {
            var conversations = dbContext.Conversations
                .OrderBy(c => c.StartedAt)
                .Select(c => new
                {
                    c.Id,
                    c.Title,
                    StartedAt = c.StartedAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                    Messages = c.Messages
                               .OrderBy(m => m.SentAt)
                               .Select(m => new
                               {
                                   m.Content,
                                   SentAt = m.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
                                   m.Status,
                                   SenderUsername = m.Sender.Username
                               })
                               .ToList()
                })
                .ToList();

            var result = JsonConvert.SerializeObject(conversations, Formatting.Indented);
            return result;
        }
    }
}

// Created on: 30/03/2025 11:01:32