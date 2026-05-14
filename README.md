# Todo API - .NET 9 Minimal API

Esta es una API para la gestión de tareas (TodoItems), construida con **.NET 9** y diseñada para ejecutarse sin configuraciones adicionales.

⚠️ IMPORTANTE: Al abrir el proyecto en GitHub Codespaces por primera vez, el sistema ejecutará automáticamente la configuración del entorno (instalación de herramientas como dotnet-ef).

## 🚀 Inicio Rápido
🚨 Por favor, espera a que la terminal muestre el mensaje "Finished configuring codespace" antes de ejecutar cualquier comando.
1.  **Ejecutar la aplicación:**
    En la terminal escribe:
    ```bash
    dotnet run --project src/TodoApi/TodoApi.csproj
    ```
2.  **Acceder a la Documentación:**
    Haz clic en **"Open in Browser"**. La aplicación te redirigirá automáticamente a la documentación interactiva de **Scalar** para que pruebes los endpoints.

## 🛠️ Características Técnicas

*   **Minimal APIs:** Estructura limpia y de alto rendimiento.
*   **Entity Framework Core:** Gestión de datos con **SQLite**.
*   **Migraciones Automáticas:** La base de datos se crea y se actualiza sola al iniciar la app (Zero Configuration).
*   **Scalar:** Documentación interactiva moderna (reemplazo de Swagger).
*   **DevContainer:** Entorno de desarrollo preconfigurado con las herramientas necesarias (`dotnet-ef`).

## 📂 Estructura del Proyecto

*   `Program.cs`: Configuración central y automatización de base de datos.
*   `/Data`: Contexto de la base de datos (`AppDbContext`).
*   `/Endpoints`: Definición de las rutas CRUD para `TodoItem`.
*   `/Migrations`: Historial de versiones de la base de datos.

---
