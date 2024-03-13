# Real Estate Sales Platform

## Overview
This project develops a full-stack application aimed at modernizing the real estate sales process. 
By leveraging the latest in backend, web, and mobile app development technologies, this platform provides an efficient, 
user-friendly way for sellers to list properties and for buyers to explore and express interest in these listings.

## Components
The system is divided into three main components:
* Backend: Developed with C# and .NET 7, this component handles the business logic, including data management, user authentication, and service orchestration.
* Web Frontend: Built with Angular, this part offers a dynamic and responsive interface for sellers to manage property listings and for administrators to oversee the platform operations.
* Mobile App: Created using Ionic, this component allows buyers to browse property listings, offering a seamless experience across various devices.
  
## Key Features
* **User Authentication:** Secure login mechanism for different user roles (administrators, sellers, buyers) using JWT for session management.
* **Property Listings Management:** Sellers can create, update, and remove listings, complete with detailed descriptions and images.
* **Search and Filters:** Buyers can easily search for properties and apply filters based on their preferences.
* **Notifications:** Automatic email notifications for buyers based on their interests and actions of sellers.
* **Analytics Dashboard:** Administrators can view platform analytics, helping in strategic decision-making.
  
## Technologies & Tools
* **Backend**
  * C# & .NET 7: For robust and scalable server-side logic.
  * SQL Server Management Studio (SSMS): Database management and schema design.
  * Entity Framework: ORM for database interaction.
* **Web Frontend**
  * Angular: For building a dynamic and interactive user interface.
  * DevExpress: UI components for enhanced visualization and interaction.
  * Node.js: Supporting Angular in the development environment.
* **Mobile App**
  * Ionic: For cross-platform mobile app development, providing a native-like experience.
  * Angular: Reused within Ionic for consistency in web and mobile app development logic.
* **Development Tools**
  * Visual Studio & Visual Studio Code: Integrated development environments for C# and Angular development, respectively.
  * Git & GitHub: Version control and source code management.
  * Swagger: API documentation and testing.
    
## Architecture
The application adopts a layered architecture approach, ensuring separation of concerns and making the system easy to maintain and scale. 
The backend handles business logic and data persistence, the web frontend serves the application's UI, and the mobile app extends the platform's accessibility.

## Project Structure
The repository is organized into three main directories, each representing a core component of the system. 
Shared utilities and common libraries are located in a separate directory to promote code reuse and maintainability.

## Conclusion
This project showcases the integration of multiple technologies to create a comprehensive solution for the real estate market. 
The combination of C#, .NET, Angular, and Ionic demonstrates a powerful stack for full-stack development, 
catering to various user needs from property listing management to real-time property browsing on mobile devices.
