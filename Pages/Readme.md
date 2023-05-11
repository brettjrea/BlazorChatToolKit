# BlazorChatToolKit

BlazorChatToolKit is a Blazor chat application that demonstrates encrypted API Key storage in local storage and uses GPT-3 to generate text responses or images. The application allows users to choose between the Chat API, Completions API, and Image Generation API.

## Index

The `Index` page in the Blazor application provides an overview of the Blazor Chat Tool Kit project.

### Project Description

BlazorChatToolKit is a project that aims to create a Blazor chat tool kit using GPT-3 to generate text responses, create a message list, and encrypt and store the API key in local storage. The project plans to integrate Dall-E image generation and other OpenAI endpoints in the future.

### Guides and References

This project is a culmination of several guides, which are cited and referenced within the application:

1. [Yash-FStack/ChatGPT_Blazor](https://github.com/Yash-FStack/ChatGPT_Blazor) - The initial implementation, which used plain local storage.
2. [Timmoth/blazor-npm-guide](https://github.com/Timmoth/blazor-npm-guide/tree/main) - A guide for using an npm package in a Blazor project.
3. [mahdiit/blazor-wasm-encryptstorage](https://github.com/mahdiit/blazor-wasm-encryptstorage/tree/main) - A guide for encrypting and storing data in Blazor WebAssembly.


## Encryption

The `Encryption` page in the Blazor application allows users to encrypt and decrypt data using the encryption provider. The implementation is based on the guide found at [mahdiit/blazor-wasm-encryptstorage](https://github.com/mahdiit/blazor-wasm-encryptstorage/tree/main).

### User Interface

The UI consists of several input fields, buttons, and labels. Users can enter text to be encrypted or decrypted and perform the following actions:

- Encrypt and Store
- Decrypt and Read
- Encrypt
- Decrypt
- Clear Textbox
- Store in Session and Local Storage
- Read from Store

### Code Behind

The `@code` block contains several properties and methods for managing encryption, decryption, and storage operations. The `IEncryptProvider` is injected for performing encryption and decryption, while `ISessionStorageService` and `ILocalStorageService` are injected for handling storage operations.

#### Methods

- `DoClear`: Clears the input fields.
- `DoEncrypt`: Encrypts the original text and updates the encrypted text field.
- `DoDecrypt`: Decrypts the encrypted text and updates the original text field.
- `DoStore`: Stores the encrypted text in both session and local storage.
- `ReadStore`: Reads the encrypted text from session storage and updates the encrypted text field.
- `EncryptandStore`: Encrypts the original text, updates the encrypted text field, and stores the encrypted text in local storage.
- `ReadandDecrypt`: Reads the encrypted text from local storage, updates the encrypted text field, decrypts the encrypted text, and updates the original text field.


## Conversation.razor

The `Conversation.razor` page is the main component of the BlazorChatToolKit. It contains a chat interface that allows users to interact with GPT-3 and see the generated responses. The main features of this page include:

1. Encrypting and storing the API Key in local storage.
2. Decrypting the API Key when needed for API calls.
3. Selecting between different GPT-3 APIs (Chat API, Completions API, or Image Generation API) using radio buttons.
4. Displaying the conversation in a message container with separate styles for user messages and GPT-3 responses.

The main functions in `Conversation.razor` are:

- `EncryptandStore`: Encrypts the provided API Key using the `EncryptProvider` and stores it in the local storage.
- `ReadandDecrypt`: Reads the encrypted API Key from local storage, decrypts it using the `EncryptProvider`, and stores the decrypted API Key in a variable.
- `GetResponseFromGPT3`: Calls different API methods depending on the radio button selection (Chat API, Completions API, or Image Generation API).
- `GetImageFromDALLE`, `GetCompletions`, and `GetChat`: Handle the specific API calls to generate responses, images, or completions.

By integrating this `Conversation.razor` page into your Blazor application, you can create an interactive chat experience where users can securely store their API Key and use GPT-3 to generate relevant responses or images based on their inputs.
## Todo

The `Todo` page demonstrates encrypted and decrypted todo storage in Local Storage and the use of GPT to generate todo suggestions. The page allows you to add, mark as done, and remove todos, which are encrypted and stored in the browser's local storage.

### Interface and Functionality

The interface consists of input fields and buttons to perform the following actions:

- **Add Todo**: You can input a value into the text field, and as you type, GPT will generate todo suggestions. You can select a suggestion or enter your own todo. Click the 'Add Todo' button to add the todo to your list and store it in local storage.
- **Mark as Done**: Check the box next to a todo to mark it as done.
- **Remove Completed Todos**: Clicking the 'Remove Completed Todos' button removes all todos marked as done from the list and local storage.

### Code

The `Todo` component uses the `ISyncLocalStorageService` from Blazored.LocalStorage to interact with the web browser's local storage. The service's methods are used to set, get, and remove items, as well as to interact with the encrypted data. The `IEncryptProvider` is used to encrypt and decrypt the data stored in local storage.

The `OnInitializedAsync` method initializes the todo list by fetching the encrypted todo keys and items from local storage, decrypting them, and adding them to the list.

The `GetTodoSuggestions` method is called when the user types in the input field. It uses GPT to generate todo suggestions based on the input and displays them in a dropdown menu. The user can select a suggestion or enter their own todo. The `AddTodo` method encrypts the todo content and stores it in local storage.

The `RemoveCompletedTodos` method removes todos marked as done from the list and local storage.


## LocalChat

The `LocalChat` page in the Blazor application provides a simple chat interface where the user can interact with an AI chatbot.

### Chat Interface

The chat interface consists of an input field for entering messages, a send button to submit messages, and an output container displaying the conversation thread. The user messages and chatbot responses are displayed in different styles to easily distinguish between them.

### Implementation

The `LocalChat` component has the following properties and methods:

- `InputText`: A string property for binding the input field text.
- `ConversationMessages`: A list of `Message` objects containing the conversation history.
- `SendMessage`: An asynchronous method that sends the user's message to the chatbot, and appends both the user's message and the chatbot's response to the conversation.

The chatbot's response is obtained by making an HTTP POST request to a predefined API endpoint (e.g., `http://127.0.0.1:5000/chat`) with the user's message as the request data.

### Styling

The component includes embedded CSS styles for the chat container, input field, send button, output container, conversation thread, and message elements.


## Configure Chat Binary

The `ConfigureChatBinary` page in the Blazor application allows users to configure various settings for the Chat Binary tool. The available settings include chat binary executable path, model path, input prompt, and other parameters related to generating chat output.

### Form Inputs

The form contains various input fields for each setting. The availability of these input fields is determined by the `ToggleSettingsService`, which provides toggle settings for each option. The values of these settings are bound to the properties of the `ChatArguments` class.

### Configure Chat Binary Button

When the user clicks on the "Configure Chat Binary" button, the `ConfigureChatBinary` method is called. This method applies the toggle settings and sends the configuration to the API endpoint located at `http://localhost:5000/configure`. If the configuration is successful, the method sends an empty message to the chat endpoint to receive the initial output.

### ChatArguments Class

The `ChatArguments` class is used to store the values of the settings entered by the user. The `ToArgsList` method of this class converts these settings into a list of strings representing command-line arguments to be passed to the Chat Binary tool.

## Highlight

The `Highlight` page in the Blazor application demonstrates how to use an npm package in a Blazor project. The implementation is based on the guide found at [Timmoth/blazor-npm-guide](https://github.com/Timmoth/blazor-npm-guide/tree/main).

### User Interface

The UI displays the guide's source and a code snippet with syntax highlighting.

### Code Behind

The `@code` block contains the `OnAfterRenderAsync` method, which is executed after the component has been rendered. The method checks if it is the first render of the component, and if so, it calls the JavaScript function `jslib.Highlight`.

### JavaScript Interop

The Blazor application communicates with the JavaScript `Highlight` function through JavaScript interop. The following code snippet shows the JavaScript function that imports and calls the `highlight` function from the npm package:

```javascript
import { highlight } from './highlight_lib';

export function Highlight() {
    return highlight();
}

The highlight function is invoked in the OnAfterRenderAsync method of the Blazor component, as mentioned earlier.
```

# Blazor Chat Toolkit - Toggle Settings

This document provides an overview of the Toggle Settings section in the Blazor Chat Toolkit. The Toggle Settings page allows users to enable or disable various settings for the chat application.

## Available Toggle Settings

1. Chat Binary
2. Model
3. Prompt
4. Interactive
5. Interactive Start
6. Color
7. File
8. Seed
9. Threads
10. NPredict
11. TopK
12. TopP
13. Repeat Last N
14. Repeat Penalty
15. Ctx Size
16. Context Memory
17. Temperature
18. Batch Size
19. Reverse Prompt

Each toggle switch controls a specific setting within the chat application, allowing users to customize the behavior and appearance of the chat interface. To enable or disable a setting, simply click on the toggle switch next to its label.

When you're finished adjusting the settings, the changes will take effect immediately, providing a tailored experience for each user.

## Sync

The `Sync` page demonstrates the use of Blazored's non-async LocalStorage service. This page allows you to add, read, remove, and clear items in the local storage of the web browser.

### Interface and Functionality

The interface consists of input fields and buttons to perform the following actions:

- **Add Item to local storage**: You can input a value into the text field and click the 'Save' button to store it in local storage with the key 'name'.
- **Remove item from local storage**: Clicking the 'Remove Item' button removes the item with the key 'name' from local storage.
- **Clear local storage**: The 'Clear All' button removes all items from local storage.

The page also displays the following information:

- **Value Read from local storage**: This shows the current value stored in local storage with the key 'name'.
- **Items in local storage**: This displays the total number of items in local storage.
- **Item exist in local storage**: This indicates whether an item with the key 'name' exists in local storage.
- **String Read from local storage**: This shows the current string value stored in local storage with the key 'name'.

### Code

The `Sync` component uses the `ISyncLocalStorageService` from Blazored.LocalStorage to interact with the web browser's local storage. The service's methods are used to set, get, remove, and clear items, as well as to check the length of local storage and whether a specific key exists.

The component's `OnInitialized` method sets up an event handler for the `localStorage.Changed` event, which logs any changes to local storage items.
