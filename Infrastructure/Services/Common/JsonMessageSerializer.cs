using System.Text.Json;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Services.Common;

public class JsonMessageSerializer : IMessageSerializer

{
    public string Serialize(Message messageToSerialize)
    {
        return JsonSerializer.Serialize(messageToSerialize);
    }

    public Message? Deserialize(string raw)
    {
        return JsonSerializer.Deserialize<Message>(raw);
    }
}