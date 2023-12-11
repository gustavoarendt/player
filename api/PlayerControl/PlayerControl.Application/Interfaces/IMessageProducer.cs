namespace PlayerControl.Application.Interfaces
{
    public interface IMessageProducer
    {
        Task SendMessageAsync<T>(T message);
    }
}
