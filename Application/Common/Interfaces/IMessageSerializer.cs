using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IMessageSerializer
{
    public string Serialize(Message messageToSerialize);

    public Message Deserialize(string raw);
}