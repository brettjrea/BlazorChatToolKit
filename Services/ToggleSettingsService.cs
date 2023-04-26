using System;
namespace BlazorChatToolKit.Services
{
    public class ToggleSettingsService
    {
        public Settings ToggleSettings { get; set; } = new Settings();

        public class Settings
        {
            public bool ChatBinary { get; set; } = false; 
            public bool Model { get; set; } = false;
            public bool Prompt { get; set; } = false;
            public bool Interactive { get; set; } = false;
            public bool InteractiveStart { get; set; } = false;
            public bool Color { get; set; } = false;   
            public bool File { get; set; } = false;
            public bool Seed { get; set; } = false;
            public bool Threads { get; set; } = false;
            public bool NPredict { get; set; } = false;
            public bool TopK { get; set; } = false;
            public bool TopP { get; set; } = false;
            public bool RepeatLastN { get; set; } = false;
            public bool RepeatPenalty { get; set; } = false;
            public bool CtxSize { get; set; } = false;
            public bool ContextMemory { get; set; } = false;
            public bool Temp { get; set; } = false;
            public bool BatchSize { get; set; } = false;
            public bool ReversePrompt { get; set; } = false;
            
            // Add other properties here
        }
    }
}
