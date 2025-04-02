using Newtonsoft.Json;
using WarehouseApp.Data;
using WarehouseApp.Data.Models;
using WarehouseApp.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace WarehouseApp.Data.temp
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format.";
        private const string DuplicatedDataMessage = "Duplicated data.";
        private const string SuccessfullyImportedMessageEntity = "Successfully imported message (Sent at: {0}, Status: {1})";
        private const string SuccessfullyImportedPostEntity = "Successfully imported post (Creator {0}, Created at: {1})";

        public static string ImportMessages(WarehouseDbContext dbContext, string xmlString)
        {
            var output = new StringBuilder();

            //var messageDtos = XmlHelper.Deserialize<ImportMessageDto[]>(xmlString, "Messages");

            //if (messageDtos == null || messageDtos.Count() == 0) return string.Empty;

            //var validMessages = new List<Message>();

            //foreach (var messageDto in messageDtos)
            //{
            //    bool isDateValid = DateTime.TryParseExact(messageDto.SentAt, "yyyy-MM-ddTHH:mm:ss",
            //                       CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            //    bool isStatusValid = Enum.TryParse(messageDto.Status, out MessageStatus status)
            //                         && Enum.IsDefined(typeof(MessageStatus), status);

            //    var conversation = dbContext.Conversations.Find(messageDto.ConversationId);
            //    var sender = dbContext.Users.Find(messageDto.SenderId);
            //    var messagesInDb = dbContext.Messages.ToList();

            //    if (!IsValid(messageDto) || !isDateValid || !isStatusValid || conversation == null || sender == null)
            //    {
            //        output.AppendLine(ErrorMessage); continue;
            //    }

            //    if (messagesInDb.Any(m => m.Content == messageDto.Content && m.SentAt == date
            //        && m.Status == status && m.ConversationId == messageDto.ConversationId)
            //        || validMessages.Any(m => m.Content == messageDto.Content
            //        && m.SentAt == date && m.Status == status && m.ConversationId == messageDto.ConversationId))
            //    {
            //        output.AppendLine(DuplicatedDataMessage); continue;
            //    }

            //    var message = new Message()
            //    {
            //        Content = messageDto.Content,
            //        ConversationId = messageDto.ConversationId,
            //        SenderId = messageDto.SenderId,
            //        SentAt = date,
            //        Status = status,
            //    };

            //    validMessages.Add(message);
            //    output.AppendLine(string.Format(SuccessfullyImportedMessageEntity, message.SentAt.ToString("yyyy-MM-ddTHH:mm:ss"),
				        //                        message.Status));
            //}

            //dbContext.Messages.AddRange(validMessages);
            //dbContext.SaveChanges();

            return output.ToString().Trim();
        }

        public static string ImportPosts(WarehouseDbContext dbContext, string jsonString)
        {
            var output = new StringBuilder();

            //var postDtos = JsonConvert.DeserializeObject<ImportPostDto[]>(jsonString);

            //if (postDtos == null || postDtos.Count() == 0) return string.Empty;

            //var validPosts = new List<Post>();

            //var creatorIdsInDb = dbContext.Users
            //    .Select(u => u.Id)
            //    .ToHashSet();

            //var postsInDb = dbContext.Posts
            //    .ToList();

            //foreach (var postDto in postDtos)
            //{
            //    bool isDateValid = DateTime.TryParseExact(postDto.CreatedAt, "yyyy-MM-ddTHH:mm:ss",
            //                       CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            //    if (!IsValid(postDto) || !isDateValid || !creatorIdsInDb.Contains(postDto.CreatorId))
            //    {
            //        output.AppendLine(ErrorMessage); continue;
            //    }

            //    if (postsInDb.Any(p => p.CreatorId == postDto.CreatorId && p.CreatedAt == date && p.Content == postDto.Content)
            //        || validPosts.Any(p => p.CreatorId == postDto.CreatorId && p.CreatedAt == date && p.Content == postDto.Content))
            //    {
            //        output.AppendLine(DuplicatedDataMessage); continue;
            //    }

            //    var post = new Post()
            //    {
            //        Content = postDto.Content,
            //        CreatedAt = date,
            //        CreatorId = postDto.CreatorId,
            //    };

            //    validPosts.Add(post);
            //    output.AppendLine(string.Format(SuccessfullyImportedPostEntity, dbContext.Users.Find(post.CreatorId).Username,
				        //                        post.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss")));
            //}

            //dbContext.Posts.AddRange(validPosts);
            //dbContext.SaveChanges();

            return output.ToString().Trim();
        }

        public static bool IsValid(object dto)
        {
            ValidationContext validationContext = new ValidationContext(dto);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validationContext, validationResults, true);

            foreach (ValidationResult validationResult in validationResults)
            {
                if (validationResult.ErrorMessage != null)
                {
                    string currentMessage = validationResult.ErrorMessage;
                }
            }

            return isValid;
        }
    }
}
