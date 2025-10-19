# Proyecto Integrador

## 🏋️‍♂️ Sistema de Gestión y Autoservicio para Club Deportivo

Este sistema está desarrollado para cubrir las necesidades de **autoservicio de socios y no socios**, así como la **gestión administrativa completa** por parte de los administradores. Permite registrar usuarios, administrar actividades, gestionar pagos y cuotas, y visualizar información relevante de manera clara y automatizada. El proyecto forma parte del **Proyecto Integrador** de la carrera y sigue una metodología ágil con fases planificadas.

## 📌 Descripción General

El sistema combina **funcionalidades de autoservicio** y **gestión administrativa**:

- **Para socios y no socios (autoservicio):**
  - Registro de nuevos usuarios.
  - Consulta de actividades disponibles.
  - Pago de cuotas (socios) o actividades individuales (no socios).
  - Visualización de carnets digitales y estado de pagos.

- **Para administradores (gestión):**
  - Registro y administración de socios y no socios.
  - Gestión de actividades, capacidad y costos.
  - Listado de cuotas vencidas y pagos pendientes.

## 🎯 Objetivos del Sistema

1. **Automatizar el registro de socios y no socios**, evitando procesos manuales y errores de ingreso de datos.
2. **Facilitar el pago de cuotas y actividades** de forma ágil, segura y controlada.
3. **Permitir el seguimiento del historial de pagos** y el estado de las cuotas para socios y administradores.
4. **Optimizar la gestión de actividades y usuarios** por parte de administradores.
5. **Mejorar la experiencia del usuario** mediante formularios claros y control de validaciones en tiempo real.
6. **Integrar un sistema de autoservicio y gestión centralizada** que garantice transparencia y control de la información del club.

## 🛠 Tecnologías Utilizadas

- **Lenguaje:** C#  
- **Framework:** .NET Framework / Windows Forms  
- **Base de datos:** MySQL  
- **ORM / Servicios:** Clases de repositorio personalizadas (SocioRepository, NoSocioRepository, ActividadRepository, PagoActividadRepository, CuotaRepository, AdministradorRepository)  
- **Patrones y prácticas:** Programación orientada a objetos, validaciones en formularios, control de flujo de formularios, manejo de errores con try/catch  

## 🧩 Estructura del Proyecto

- **Interfaces:** Carpeta que contiene las definiciones de contratos (interfaces) para modelos y servicios, ayudando a mantener consistencia y flexibilidad en la arquitectura.
  - **Modelos:** Contiene interfaces para las entidades principales, definiendo las propiedades que cada modelo debe implementar.
    - `IPersona`  
    - `ISocio`  
    - `INoSocio`  
    - `IActividad`  
    - `IPagoActividad`  
    - `ICuota`  
    - `IAdministrador`  
  - **Servicios:** Contiene interfaces para los repositorios y servicios, definiendo los métodos que deben implementar.
    - `IPersonaRepository`  
    - `ISocioRepository`  
    - `INoSocioRepository`  
    - `IActividadRepository`  
    - `IPagoActividadRepository`  
    - `ICuotaRepository`  
    - `IAdministradorRepository`

- **Modelos:** Definen las entidades principales del sistema:
  - `Persona`  
  - `Socio`  
  - `NoSocio`  
  - `Actividad`
  - `PagoActividad`  
  - `Cuota`  
  - `Administrador`  

- **Database:** Manejo de conexión a la base de datos con patrón singleton (`ConexionDB`) y funciones para ejecutar consultas y comandos.

- **Servicios / Repositorios:** Encapsulan la lógica de acceso a datos y operaciones CRUD de cada entidad, separando responsabilidades entre gestión de usuarios, actividades y pagos.

  - `PersonaRepository` → Clase base para operaciones generales sobre personas (socios y no socios), incluyendo registro, listado y búsqueda de usuarios.
  - `SocioRepository` → Gestión específica de socios: registro, obtención de datos, historial de cuotas, verificación de ficha médica y visualización de carnet.
  - `NoSocioRepository` → Gestión específica de no socios: registro, obtención de datos y seguimiento de pagos de actividades.
  - `ActividadRepository` → Gestión de actividades: listado de actividades, verificación de disponibilidad, control de cupos e inscripción de usuarios.
  - `PagoActividadRepository` → Gestión de pagos de actividades para no socios: registro de pagos, consulta de historial y validación de inscripción.
  - `CuotaRepository` → Gestión de cuotas de socios: historial de pagos, vencimientos, métodos de pago y promociones.
  - `AdministradorRepository` → Funcionalidades administrativas: listado y gestión de socios y no socios, supervisión de pagos y cuotas, control de usuarios y reportes de actividades.


- **Controladores / Formularios:** Interfaces y lógica de interacción con el usuario, diferenciando entre funcionalidades de autoservicio (socios y no socios) y administración (administrador).

  - `frmPreRegistro` → Pantalla de selección para registrarse como socio o no socio.
  - `frmRegistroSocio` → Formulario de registro de socio con validaciones, ficha médica y flujo de pago inicial de cuota.
  - `frmRegistroNoSocio` → Formulario de registro de no socio con validaciones y flujo de pago de actividad.
  - `frmPrincipalSocio` → Panel principal de socio, con acceso a pagos de cuotas, visualización de carnet y historial de cuotas.
  - `frmPrincipalNoSocio` → Panel principal de no socio, con acceso a inscripción y pago de actividades.
  - `frmPrincipalAdmin` → Panel de administración, acceso a gestión de usuarios, listado de cuotas vencidas y actividades.
  - `frmAgregarActividad` → Formulario para agregar nuevas actividades al sistema (solo administrador).
  - `frmListadoCuotasVencidas` → Listado de cuotas vencidas de socios para seguimiento administrativo.
  - `frmLogin` → Formulario de inicio de sesión para todos los tipos de usuarios.
  - `frmPagarActividad` → Formulario de pago de actividad para no socios.
  - `frmPagarCuota` → Formulario de pago de cuota para socios.
  - `frmVerActividades` → Visualización de todas las actividades disponibles, estado de inscripción y cupos.
  - `frmVerCarnet` → Visualización digital del carnet del socio.
  - `frmVerCuotas` → Visualización del historial de cuotas de un socio.
  - `frmVerPerfilNoSocio` → Visualización del perfil de un no socio.
  - `frmVerPerfilSocio` → Visualización del perfil de un socio.
  - `frmVerUsuarios` → Listado completo de socios y no socios para supervisión administrativa.


## ⚙ Funcionalidades Principales

- Registro de **socios** y **no socios** con validación de datos.
- Pago de **cuotas** para socios y de **actividades individuales** para no socios.
- Visualización de **carnet digital**, historial de pagos y actividades.
- Gestión de actividades: listado, capacidad, estado y disponibilidad.
- Gestión de usuarios por administradores: alta, listado y seguimiento.
- Listado de **cuotas vencidas** para administración y control de pagos pendientes.

## 🔒 Validaciones Implementadas

- Campos obligatorios y límites de caracteres.
- Validación de formato de DNI, nombres y apellidos.
- Validación de fechas (no se permiten fechas futuras de nacimiento).
- Contraseñas mínimas de 6 caracteres.
- Verificación de ficha médica para registro de socio.
- Control de disponibilidad de actividades y estado de inscripción.

## 🚀 Flujo de Uso

1. El usuario abre la aplicación y se encuentra con la pantalla de login o pre-registro.
2. Puede registrarse como **socio** o **no socio** a través de formularios de autoservicio.
3. Una vez registrado:
   - Los socios acceden a su panel con opciones de pago de cuotas, visualización de carnet y cuotas.  
   - Los no socios acceden a su panel con opciones de pago de actividades y ver actividades disponibles.
4. Los administradores tienen acceso a un panel de gestión donde pueden:
   - Listar socios y no socios.
   - Gestionar actividades y cuotas vencidas.

## 📝 Notas Adicionales

- Todos los formularios usan **Windows Forms** con validaciones en tiempo real.
- Se maneja la apertura y cierre de formularios para garantizar que solo haya una ventana principal activa por tipo de usuario.
- La base de datos se conecta a través de la clase `ConexionDB`, usando un patrón **singleton** para control de la conexión.
- Los repositorios manejan todas las operaciones CRUD necesarias para cada entidad.

## 🚀 Ejecución del Proyecto

Para poner en funcionamiento el sistema, seguir estos pasos:

1. **Ejecutar los scripts SQL**  
   - Ejecutar los archivos en el siguiente orden para asegurar la integridad de los datos y relaciones:
     1. `UsuarioSistema.sql` → Crea usuario genérico para el acceso y manejo de la conexión MySQL.
     2. `Creaciones.sql` → Crea la base de datos, las tablas y relaciones principales.
     3. `Inserciones.sql` → Inserta datos iniciales en las tablas.
     4. `ProcedureLogin.sql` → Crea procedimiento almacenado para el login.

2. **Configurar la conexión a la base de datos**  
   - El proyecto utiliza variables de entorno para la configuración de la conexión a MySQL. Los valores por defecto se usan si no se encuentra la variable de entorno:
     - `DB_NAME` → Nombre de la base de datos (por defecto: `club_deportivo`)
     - `DB_SERVER` → Servidor MySQL (por defecto: `localhost`)
     - `DB_PORT` → Puerto MySQL (por defecto: `3306`)
     - `DB_USER` → Usuario de la base de datos (por defecto: `club_user`)
     - `DB_PASS` → Contraseña del usuario (por defecto: `MiPass123`)

   - Para cambiar estos valores, se puede:
     1. Crear un archivo `.env` en la raíz del proyecto con las variables:
        ```env
        DB_NAME=clubdeportivo
        DB_SERVER=localhost
        DB_PORT=3306
        DB_USER=tu_usuario
        DB_PASS=tu_contraseña
        ```
     2. Asegurarse de que la aplicación lea las variables de entorno (si se usa `Environment.GetEnvironmentVariable`, no se necesita modificar `ConexionDB.cs`).
   - **Nota:** No es necesario modificar directamente la clase `ConexionDB.cs` salvo que se quiera cambiar los valores por defecto de forma permanente para todos los entornos locales.

3. **Compilar y ejecutar el proyecto**  
   - Abrir Visual Studio.
   - Compilar la solución.
   - Ejecutar el proyecto.


## 👥 Equipo de Trabajo
- **Iván Shifman**
- **Ángel Sabato** 
- **Flavio Rinaldi**  
- **Marcelo Zárate**  
