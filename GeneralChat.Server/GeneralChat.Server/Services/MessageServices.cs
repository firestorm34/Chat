using GeneralChat.Server.DataAccess;
using GeneralChat.Server.Models;

namespace GeneralChat.Server.Services
{
    public class MessageServices
    {
        private UnitOfWork unit;
        public MessageServices(UnitOfWork unitOfWork)

        {
            this.unit = unitOfWork;
        }

        public async Task SendMessage(int authorId, int chatId, string text)
        {

            Message message= new Message{UserId= authorId, ChatId = chatId, Text = text, SentTime = DateTime.Now  };
            await unit.MessageRepository.AddAsync(message);
            await unit.UnreadMessageRepository.AddAsync(new UnreadMessage { UserId=authorId, ChatId= chatId, MessageId=message.Id });
            await unit.SaveAsync();
        }

        public async Task<OperationResult> EditText(int messageId, string newText)
        {
            Message? message = await unit.MessageRepository.GetAsync(messageId);
            if (message != null)
            {
                message.Text = newText;
                unit.MessageRepository.Update(message);
                await unit.SaveAsync();
                return new OperationResult(OperationStatus.Successed);
            }
            return new OperationResult(OperationStatus.Failed, new Exception("Text is null"));
        }

        public async Task Delete(int id)
        {
            await unit.MessageRepository.DeleteAsync(id);
            await unit.SaveAsync();
        }

        public async Task<OperationResult> ViewMessage(int id)
        {
            Message? message = await unit.MessageRepository.GetAsync(id);
            if(message != null) { 
                await unit.UnreadMessageRepository.DeleteAsync(message.UserId, message.Id);
                await unit.SaveAsync();
                return new OperationResult(OperationStatus.Successed);
            }
            return new OperationResult(OperationStatus.Failed, new Exception($"Message with id = {id} is not found in database"));
        }

        public async Task<List<Message>> GetAll()
        {
            return await unit.MessageRepository.GetAllAsync();
        }

        public async Task<Message?> GetAsync(int id)
        {
            return await unit.MessageRepository.GetAsync(id);
        }

        public async Task<List<Message>> GetForChat(int chatId)
        {
            return await unit.MessageRepository.GetByChatId(chatId);
        }

        public async Task<List<Message>> GetBatchForChat(int chatId, int batch_size)
        {
            return await unit.MessageRepository.GetBatchByChatId(chatId, batch_size);
        }
    }

}
