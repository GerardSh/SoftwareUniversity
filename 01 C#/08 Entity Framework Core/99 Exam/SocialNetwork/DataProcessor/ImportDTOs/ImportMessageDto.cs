using SocialNetwork.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SocialNetwork.DataProcessor.ImportDTOs
{
    [XmlType(nameof(Message))]
    public class ImportMessageDto
    {
        [XmlAttribute("SentAt")]
        public string SentAt { get; set; } = null!;

        [Required]
        [MinLength(1)]
        [MaxLength(200)]
        public string Content { get; set; } = null!;

        public string Status { get; set; } = null!;

        public int ConversationId { get; set; }

        public int SenderId { get; set; }
    }
}
