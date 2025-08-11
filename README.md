CharityConnect.MVC
CharityConnect.MVC is a full-stack ASP.NET Core MVC web application that acts as a central platform for connecting three types of users:

Donors – individuals or organizations who want to help.

Needy individuals – people requesting help or support.

Administrators – who manage and monitor the platform.

This project was built to make charitable giving more transparent, organized, and efficient.
It provides a simple way for people in need to request help, for donors to respond, and for admins to manage the process — all in a secure role-based system.

✨ Features
1. User Authentication & Authorization
Secure login and logout with JWT (JSON Web Token) authentication.

JWT is stored in session storage to keep users logged in between requests.

Automatic role-based redirection after login:

Admin → Admin Dashboard

Donor → Donor Dashboard

Needy → Needy Dashboard

2. Role-Specific Dashboards
Admin Dashboard – View and manage all registered users, oversee help requests, ensure compliance.

Donor Dashboard – Browse available help requests, choose which ones to support, view donation history.

Needy Dashboard – Create and manage personal help requests, track progress, view donor responses.

3. Help Request Management
Needy users can create new help requests (e.g., food, housing, education, medical aid).

Donors can browse and select requests to fulfill.

Requests are tracked and visible to admins for monitoring.

4. Secure API Communication
Uses IHttpClientFactory for efficient and reusable HTTP calls to the backend API.

All requests to the API are authenticated with the stored JWT.

Session handling includes token validation and parsing to prevent unauthorized access.

5. Modern UI
Fully responsive design with Bootstrap 5.

Clean navigation layout with a main menu linking to Home, Login, Create Help Request, and Privacy Policy.

🛠 Technologies Used
Technology	Purpose
ASP.NET Core MVC	Main web framework (Model-View-Controller architecture)
C#	Application logic and backend code
Bootstrap 5	Responsive styling and UI components
IHttpClientFactory	Secure and efficient HTTP calls to backend API
JSON Web Token (JWT)	Authentication and authorization
Session Storage	Storing JWT tokens and user role info
Entity Framework Core	(If connected to backend DB) Data handling
Razor Views	Server-side rendering of HTML pages

CharityConnect.MVC/
│
├── Controllers/
│   ├── AuthController.cs        # Handles login/logout and authentication
│   ├── DashboardController.cs   # Role-based dashboard routing
│   ├── HelpRequestController.cs # Creating and managing help requests
│   └── HomeController.cs        # Static pages like Home and Privacy
│
├── Models/
│   ├── LoginViewModel.cs        # Data model for login form
│   ├── HelpRequest.cs           # Data model for help requests
│   └── ApiResponse.cs           # Wrapper for API responses
│
├── Views/
│   ├── Auth/                    # Login view and related auth pages
│   ├── Dashboard/               # Views for Admin, Donor, Needy dashboards
│   ├── HelpRequest/             # Views for creating/viewing help requests
│   └── Shared/                  # Layout, navigation bar, and footer
│
├── wwwroot/                     # Static files (CSS, JS, images)
│
├── Program.cs                   # Application startup and middleware configuration
└── appsettings.json             # Configuration (API URLs, secrets, etc.)


