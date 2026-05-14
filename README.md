# Todo API - .NET 9 Minimal API

Esta es una API para la gestión de tareas (TodoItems), construida con **.NET 9** y diseñada para ejecutarse sin configuraciones adicionales.

## 🚀 Inicio Rápido

1.  **Ejecutar la aplicación:**
    En la terminal escribe:
    ```bash
    dotnet run
    ```
2.  **Acceder a la Documentación:**
    Una vez que la aplicación esté corriendo, abre el enlace generado y añade `/scalar/v1` al final de la URL para probar los endpoints con **Scalar**.

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
