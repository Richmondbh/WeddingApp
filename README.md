# WeddingApp

A wedding website built with ASP.NET Core Razor Pages. Guests can read about the
event, browse a small photo gallery and respond to the invitation. All data is
held in memory and there is no database.

Coursework for Programming in C# III at Malmö University .

## Built with

- C# / .NET 9
- ASP.NET Core Razor Pages
- Bootstrap 5 (CSS only)
- In-memory collections and service classes

No JavaScript is used anywhere in the project, and no database or ORM. Both are
constraints set by the assignment.

## Features

- Home page introducing the couple and the celebration
- Event page with title, date, time and location
- Photo gallery served from local images
- RSVP form with server-side validation via Data Annotations
- Confirmation page shown after a successful submission
- Guest list with full create, read, update and delete
- Shared layout with a navigation bar and footer across every page

## Project structure

```
WeddingApp/
├── Models/
│   ├── Event.cs             Title, date, time, location
│   ├── Guest.cs             RSVP data with validation attributes
│   ├── GalleryImage.cs      File name, caption, alt text
│   └── Notice.cs            Short updates for guests
├── Services/
│   ├── IGuestManager.cs
│   ├── GuestManager.cs      Owns the guest list and its CRUD operations
│   ├── IEventService.cs
│   └── EventService.cs      Owns the event details, images and notices
├── Pages/
│   ├── Index.cshtml         Home
│   ├── Event.cshtml
│   ├── Gallery.cshtml
│   ├── Rsvp.cshtml
│   ├── Confirmation.cshtml
│   ├── Guests/
│   │   ├── GuestList.cshtml
│   │   └── EditGuest.cshtml
│   └── Shared/_Layout.cshtml
├── wwwroot/
│   ├── css/site.css
│   └── images/
└── Program.cs
```

## Running the project

Requires the .NET 8 SDK.

```bash
git clone https://github.com/Richmondbh/WeddingApp.git
cd WeddingApp
dotnet run
```

Then open the URL printed in the terminal, usually `https://localhost:7115`.

The project can also be opened directly in Visual Studio 2022 and started with
F5.

## Design decisions

**Services are registered as singletons.** `GuestManager` and `EventService` are
registered with `AddSingleton` in `Program.cs`, so the whole application shares
one instance of each. Registering them as scoped or transient would give every
HTTP request its own empty guest list, and submitted responses would be lost the
moment the response was sent.

**Pages never touch the data directly.** Page models receive `IGuestManager` and
`IEventService` through constructor injection and depend on the interfaces
rather than the concrete classes. `GetAll()` returns `IReadOnlyList<Guest>` so a
page can display the guests but cannot modify the collection behind the
service's back.

**Guest IDs come from a counter that only increases.** Deriving an ID from the
current guest count breaks as soon as a guest is deleted, because the next
addition reuses an existing ID. A private counter avoids that.

**`WillAttend` is a nullable bool.** A plain `bool` defaults to `false`, which is
a valid value, so `[Required]` could never fail on it and an unanswered question
would silently be recorded as "not attending". Making it nullable gives the
field a genuine unanswered state.

**Validation runs on the server.** With client-side validation scripts removed,
invalid input is caught by `ModelState.IsValid` in the `OnPost` handler and the
page is redisplayed with the messages produced by the Data Annotations.

## Limitations

Guest responses exist only while the application is running and are cleared on
restart. This is intentional — persistence with Entity Framework Core is
introduced in a later assignment.

## Author

Richmond
