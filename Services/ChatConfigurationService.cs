using System;

namespace BlazorChatToolKit.Services
{
    public class ChatConfigurationService
    {
        public ChatArguments ChatArguments { get; set; } = new ChatArguments();
        public event Action OnConfigChanged;

        public void SaveConfig(ChatArguments args)
        {
            ChatArguments = args;
            NotifyConfigChanged();
        }

        private void NotifyConfigChanged() => OnConfigChanged?.Invoke();
    }

    public class ChatArguments // Add this class definition
    {
        public string[] Args { get; set; }
        public string ChatBinary { get; set; }
    }
}
