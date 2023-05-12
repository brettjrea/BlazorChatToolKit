# BlazorChatToolKit

---

#### blazorchattoolkit.csproj

This section provides an overview of the `blazorchattoolkit.csproj` file in the Blazor Chat Toolkit project. This file is a project configuration file that contains information about the project, including target framework, property settings, and package references.

##### Project Configuration

The project uses the following configuration:

- **TargetFramework**: net7.0
- **Nullable**: enable
- **ImplicitUsings**: enable
- **ServiceWorkerAssetsManifest**: service-worker-assets.js

##### Package References

The project depends on several NuGet packages. The package references are:

1. Microsoft.AspNetCore.Components.WebAssembly: Version 7.0.4
2. Microsoft.AspNetCore.Components.WebAssembly.DevServer: Version 7.0.4
3. Blazored.LocalStorage: Version 4.3.0
4. Blazored.SessionStorage: Version 2.3.0
5. Newtonsoft.Json: Version 13.0.3
6. OpenAI: Version 1.6.0
7. System.Net.Http.Json: Version 7.0.1

##### Service Worker

The project includes a service worker, which is configured in the `wwwroot\service-worker.js` file. The published content is specified as `wwwroot\service-worker.published.js`.

---

#### Program.cs

This section provides an overview of the `Program.cs` file in the Blazor Chat Toolkit project. This file is the entry point for the application and is responsible for configuring the dependency injection container, setting up the root components, and starting the application.

##### Dependencies

The `Program.cs` file imports several namespaces:

- Blazored.LocalStorage
- Blazored.SessionStorage
- Microsoft.AspNetCore.Components.Web
- Microsoft.AspNetCore.Components.WebAssembly.Hosting
- BlazorChatToolKit
- BlazorChatToolKit.Services
- BlazorChatToolKit.Shared.EncryptProviders
- System.Net.Http

##### Configuration

The `WebAssemblyHostBuilder` is used to create the default configuration:

```csharp
var builder = WebAssemblyHostBuilder.CreateDefault(args);
```

##### Root Components

Two root components are added to the application:

- `App` component with the selector "#app"
- `HeadOutlet` component with the selector "head::after"

```csharp
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
```

##### Dependency Injection

The following services are registered with the dependency injection container:

- BlazoredLocalStorage
- BlazoredSessionStorage
- AesJsProvider (as an implementation of IEncryptProvider)
- HttpClient (with the base address set to the host environment's base address)
- ToggleSettingsService (as a singleton)

```csharp
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<BlazorChatToolKit.Shared.IEncryptProvider, AesJsProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<ToggleSettingsService>();
```

##### Run the Application

Finally, the application is built and run asynchronously:

```csharp
await builder.Build().RunAsync();
```

---

#### _Imports.razor

This file contains all the global using directives for the Blazor application. By including these namespaces in `_Imports.razor`, you make them available for all components in the project, so you don't need to include them individually in each component file.

- `@using BlazorChatToolKit`: Import the main namespace for the BlazorChatToolKit project.
- `@using BlazorChatToolKit.Shared`: Import the shared namespace containing common components and services.
- `@using Microsoft.AspNetCore.Components`: Import core components and features from the ASP.NET Core library.
- `@using Microsoft.AspNetCore.Components.Forms`: Import components for working with forms.
- `@using Microsoft.AspNetCore.Components.Routing`: Import components for handling routing.
- `@using Microsoft.AspNetCore.Components.Web`: Import components for working with web-specific features.
- `@using Microsoft.AspNetCore.Components.Web.Virtualization`: Import components for virtualization.
- `@using Microsoft.AspNetCore.Components.WebAssembly.Http`: Import components for handling HTTP requests in WebAssembly.
- `@using Microsoft.JSInterop`: Import features for interoperability between .NET and JavaScript.
- `@using System`, `@using System.Text`, and `@using System.Threading.Channels`: Import namespaces for common .NET functionality.
- `@using System.Net.Http`, `@using System.Net.Http.Json`, and `@using System.Net.Http.Headers`: Import namespaces for working with HTTP requests and responses.
- `@using System.Text.Json`: Import the namespace for the .NET JSON library.
- `@using Newtonsoft.Json`: Import the namespace for the Newtonsoft.Json library.
- `@using OpenAI_API`, `@using OpenAI_API.Chat`, `@using OpenAI_API.Completions`, `@using OpenAI_API.Embedding`, and `@using OpenAI_API.Models`: Import namespaces related to the OpenAI API.

In summary, `_Imports.razor` includes all the necessary namespaces for the BlazorChatToolKit project, making them available to all components in the application.

---

#### BlazorChatToolkit.sln

This is the solution file for the BlazorChatToolkit project. It contains information about the projects within the solution and their configurations.

- Microsoft Visual Studio Solution File, Format Version 12.00: Indicates the file format version for the solution file.
- Visual Studio Version 17: Indicates the Visual Studio version used to create or modify the solution file.
- VisualStudioVersion and MinimumVisualStudioVersion: Specifies the exact and minimum Visual Studio versions required to open the solution.
- Project: Contains the project GUID, project name, project file path, and a unique GUID for the project within the solution.
- GlobalSection(SolutionConfigurationPlatforms): Defines the solution-level build configurations (Debug and Release) for all projects.
- GlobalSection(ProjectConfigurationPlatforms): Specifies the project-level build configurations for each project, mapped to the solution-level configurations.
- GlobalSection(SolutionProperties): Contains solution-wide properties, such as hiding the solution node in Solution Explorer.
- GlobalSection(ExtensibilityGlobals): Contains extensibility-related properties, such as the SolutionGuid.

This file is used by Visual Studio to manage and build the solution, which includes the `BlazorChatToolKit.csproj` project file.

---

#### App.razor

This file contains the main routing configuration for the Blazor application.

- `<Router AppAssembly="@typeof(App).Assembly">`: The Router component provides client-side routing for the application. The `AppAssembly` parameter specifies the assembly containing the components used for routing.
- `<Found Context="routeData">`: This block is executed when a matching route is found. The `routeData` variable contains information about the matched route.
- `<RouteView RouteData="@routeData" DefaultLayout="@typeof(MainLayout)" />`: The RouteView component renders the matched component, passing the route data to it. The `DefaultLayout` parameter specifies the layout to be used for the matched route.
- `<FocusOnNavigate RouteData="@routeData" Selector="h1" />`: The FocusOnNavigate component sets the focus to the specified element (in this case, an "h1" element) when navigating to a new route.
- `<NotFound>`: This block is executed when no matching route is found.
- `<PageTitle>Not found</PageTitle>`: Sets the page title for the browser tab when the NotFound block is executed.
- `<LayoutView Layout="@typeof(MainLayout)">`: The LayoutView component renders the specified layout, allowing child content to be added within the layout.
- `<p role="alert">Sorry, there's nothing at this address.</p>`: The content displayed when no matching route is found.

In summary, `App.razor` sets up the routing for the Blazor application, specifying the layout to use and handling cases when no matching route is found.

---

#### AesJsProvider.cs

This file defines the `AesJsProvider` class, which is an implementation of the `IEncryptProvider` interface. The purpose of this class is to provide encryption and decryption functionality for the BlazorChatToolKit application using JavaScript interop with the help of the `IJSRuntime` interface.

- `IJSRuntime GetJSRuntime`: A private instance of the `IJSRuntime` interface to handle the communication between .NET and JavaScript.
- `HiddenKey`: An integer array that represents the encryption key used for the AES encryption and decryption processes.
- `JsEncryptMethod` and `JsDecryptMethod`: Static strings representing the names of the JavaScript functions used for encryption and decryption.

The `AesJsProvider` class has the following methods:

1. `TextDecrypt(string input)`: An asynchronous method that takes an encrypted string as input and returns the decrypted string using the `JsDecryptMethod`.
2. `TextEncrypt(string input)`: An asynchronous method that takes a plain string as input and returns the encrypted string using the `JsEncryptMethod`.
3. `Encrypt<T>(T input)`: A generic asynchronous method that takes an object of type `T` as input, serializes it into a JSON string, and returns the encrypted JSON string using the `JsEncryptMethod`.
4. `Decrypt<T>(string input)`: A generic asynchronous method that takes an encrypted JSON string as input, decrypts it using the `JsDecryptMethod`, and deserializes it into an object of type `T`.

These methods use `try-catch` blocks to handle exceptions that might occur during the encryption and decryption processes, returning an empty string or a default value when an exception is caught. The class uses the `IJSRuntime` interface to invoke JavaScript functions for encryption and decryption.

---
