# 🖥️ Sistema de Gestión para Ciber Café (CiberCafePiloso)

![Estado del Proyecto](https://img.shields.io/badge/Estado-Funcional-brightgreen)
![Lenguaje](https://img.shields.io/badge/C%23-.NET_Framework-blue)
![DB](https://img.shields.io/badge/SQL_Server-Express-red)

Un software de escritorio robusto diseñado para la administración integral de centros de cómputo y ciber cafés. Desarrollado como proyecto académico, implementando una arquitectura en capas para separar la lógica de negocio, el acceso a datos y la interfaz de usuario.

---

## 🚀 Características Principales

El sistema permite el control total del flujo de negocio:

* **🔒 Control de Sesiones:** Gestión de inicio y fin de uso de equipos con cálculo automático de tiempo y costo.
* **💰 Punto de Venta (POS):** Venta de servicios adicionales (impresiones, escaneos) y productos (snacks, bebidas).
* **📊 Reportes y Métricas:**
    * Uso por horas (Picos de actividad).
    * Clientes frecuentes.
    * Historial de sesiones.
* **👥 Gestión de Usuarios:**
    * Roles de Administrador y Empleado.
    * Control de acceso seguro (Login).
* **💵 Control de Caja:** Apertura y cierre de caja con arqueo de ingresos y gastos.
* **🎟️ Membresías:** Administración de clientes suscritos y descuentos.

---

## 🛠️ Tecnologías Utilizadas

* **Lenguaje:** C# (Windows Forms).
* **Base de Datos:** Microsoft SQL Server.
* **Arquitectura:** N-Capas (Presentation, Domain, DataAccess).
* **Librerías:** `System.Data.SqlClient` (ADO.NET puro para máximo rendimiento).

---

## 📋 Pre-requisitos e Instalación

Para ejecutar este proyecto en tu entorno local:

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/TU_USUARIO/CiberCafePiloso.git](https://github.com/TU_USUARIO/CiberCafePiloso.git)
    ```

2.  **Base de Datos:**
    * Asegúrate de tener instalado **SQL Server Express**.
    * Ejecuta el script `DatabaseScript.sql` (ubicado en la carpeta `db` o raíz) para crear la estructura de tablas y procedimientos almacenados.
    * *Nota:* El script crea la base de datos `CiberCafeDB`.

3.  **Configuración:**
    * Abre la solución en **Visual Studio**.
    * Verifica el archivo `App.config` o `ConnectionSql.cs` en la capa de datos para asegurarte de que la cadena de conexión apunte a tu instancia local de SQL Server.

4.  **Compilar y Correr:**
    * Dale a `Start` y loguéate con las credenciales por defecto (si las hay en el script) o crea un usuario en la base de datos.

---

## 🐛 Estado Actual y Mantenimiento

Este proyecto fue desarrollado originalmente como parte de un curso universitario de 2do semestre.

* **Última actualización:** Corrección crítica en el módulo de reportes (`UsageDao.cs`) para solucionar inconsistencias en el mapeo de columnas y cálculos de tiempo (`SQLException`).
> **Nota de Arquitectura:** Este repositorio contiene únicamente el **Módulo de Servidor/Administración**. El software cliente (bloqueo de terminales) se maneja en una solución separada y se comunica vía sockets/TCP (no incluido en este repo).

---

## ✒️ Autores

* **Teilor** - *Líder del Proyecto, Arquitectura, Diseño de Base de Datos y Lógica del Servidor.*
* **Ivan** - *Colaboración en el Módulo de Reportes.*
* **Kenneth** - *Desarrollo del Software Cliente (Bloqueo de Terminales - Repositorio Externo).*

---
