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
        public string ChatBinary { get; set; }
        public string Model { get; set; }
        public string Prompt { get; set; } 
        public bool Interactive { get; set; }
        public bool InteractiveStart { get; set; }
        public bool Color { get; set; }
        public string File { get; set; }
        public int Seed { get; set; }
        public int Threads { get; set; }
        public int NPredict { get; set; }
        public int TopK { get; set; }
        public double TopP { get; set; }
        public int RepeatLastN { get; set; }
        public double RepeatPenalty { get; set; }
        public int CtxSize { get; set; }        
        public int ContextMemory { get; set; } 
        public double Temp { get; set; }
        public int BatchSize { get; set; }
        public string ReversePrompt { get; set; }
        public string Additional { get; set; }
                
        public List<string> ToArgsList()
        {
            var args = new List<string>();
                
            if (!string.IsNullOrEmpty(Model)) args.AddRange(new[] { "-m", Model });    
            if (!string.IsNullOrEmpty(Prompt)) args.AddRange(new[] { "-p", Prompt });
            if (Interactive) args.Add("-i");
            if (InteractiveStart) args.Add("--interactive-start");
            if (Color) args.Add("--color");
            if (!string.IsNullOrEmpty(File)) args.AddRange(new[] { "-f", File });    
            if (Seed != 0) args.AddRange(new[] { "-s", Seed.ToString() });
            if (Threads != 0) args.AddRange(new[] { "-t", Threads.ToString() });
            if (NPredict != 0) args.AddRange(new[] { "-n", NPredict.ToString() });
            if (TopK != 0) args.AddRange(new[] { "--top_k", TopK.ToString() });
            if (TopP != 0) args.AddRange(new[] { "--top_p", TopP.ToString() });
            if (RepeatLastN != 0) args.AddRange(new[] { "--repeat_last_n", RepeatLastN.ToString() });
            if (RepeatPenalty != 0) args.AddRange(new[] { "--repeat_penalty", RepeatPenalty.ToString() });
            if (CtxSize != 0) args.AddRange(new[] { "-c", CtxSize.ToString() });
            if (ContextMemory != 0) args.AddRange(new[] { "--context_memory", ContextMemory.ToString() });
            if (Temp != 0) args.AddRange(new[] { "--temp", Temp.ToString() });
            if (BatchSize != 0) args.AddRange(new[] { "-b", BatchSize.ToString() });
            if (!string.IsNullOrEmpty(ReversePrompt)) args.AddRange(new[] { "-r", ReversePrompt });
            
            return args;
        }
    }
}
