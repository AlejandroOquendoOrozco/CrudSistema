# Proyecto Web API con .NET y Dapper

Este proyecto demuestra cómo construir una API web utilizando .NET Web API y Dapper para la interacción con bases de datos. La combinación de .NET Web API con Dapper permite crear servicios de API eficientes y fáciles de mantener, optimizando las operaciones de acceso a datos.

## Descripción

El proyecto ofrece una implementación de una API RESTful para gestionar recursos (por ejemplo, empleados, productos, etc.) utilizando .NET Web API. Dapper, un micro ORM (Object-Relational Mapper), se utiliza para manejar las operaciones de base de datos de manera rápida y eficiente, proporcionando una forma sencilla de mapear resultados de consultas SQL a objetos de C#.

## Tecnologías Utilizadas

- **.NET Web API:** Framework para construir servicios web RESTful que permiten la comunicación entre aplicaciones a través de HTTP.
- **Dapper:** Micro ORM que facilita el acceso a datos mediante la ejecución de consultas SQL y el mapeo de resultados a objetos C# de manera eficiente.
- **SQL Server (u otro sistema de gestión de bases de datos):** Sistema de base de datos utilizado para almacenar y gestionar los datos.

## Funcionalidades

- **CRUD para Recursos:** Implementa operaciones básicas de Crear, Leer, Actualizar y Eliminar (CRUD) para gestionar los datos de recursos.
- **Consultas Personalizadas:** Permite la ejecución de consultas SQL personalizadas para obtener datos específicos o realizar operaciones complejas.
- **Optimización de Consultas:** Utiliza Dapper para una ejecución eficiente de consultas SQL, minimizando el overhead de un ORM completo.
