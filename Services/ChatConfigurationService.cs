using System;
using SocketIOClient;

namespace BlazorChatToolKit.Services
{
    public class ChatConfigurationService
    {
        public SocketIO Socket { get; set; }
        public ChatArguments ChatArguments { get; set; } = new ChatArguments();
        public event Action OnConfigChanged;

        public void SaveConfig(ChatArguments args)
        {
            ChatArguments = args;
            NotifyConfigChanged();
        }

        private void NotifyConfigChanged() => OnConfigChanged?.Invoke();
    }

    public class ChatArguments
    {
        public string[] Args { get; set; }
        public string ChatBinary { get; set; }

        public int Threads { get; set; }

        public List<string> ToArgsList()
        {
            var args = new List<string>();

            if (Threads != 0) args.AddRange(new[] { "-t", Threads.ToString() });

            return args;
        }
    }
}
