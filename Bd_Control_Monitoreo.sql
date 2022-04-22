drop database Control_Monitoreo
create database Control_Monitoreo
use Control_Monitoreo

create table Maestro_Clientes(
Codigo_Cliente int primary key not null,
Ruc_Cliente int not null,
Razon_Social varchar(100) not null,
Correo varchar(100) not null,
Telefono int not null,
Contacto varchar(100) not null
)
Go
create table Maestro_Servicio(
Codigo_Servicio int primary key not null,
Descripcion_Servicio text not null,
Tipo_Servicio varchar(100) not null,
Precio_Referencia int not null
)
Go
create table Maestro_Usuario(
Usuario varchar(200) primary key not null,
Nombre varchar(200) not null,
Apellidos varchar(200) not null,
Contraseña varchar(200) not null,
Perfil varchar(200) not null,
Fecha_Registro datetime not null,
Fecha_Modificacion datetime not null
)
Go
create table Orden_Servicio(
Codigo_Solicitud int primary key not null,
Cod_Cliente int not null,
Cod_Servicio int not null,
Fecha_Solicitud datetime not null,
Fecha_Tentativa datetime not null,
Usuario_Registro varchar(200) not null,
Estado_Solicitud varchar(100) not null,
constraint fk_cliente foreign key (Cod_Cliente) references Maestro_Clientes(Codigo_Cliente),
constraint fk_servicio foreign key (Cod_Servicio) references Maestro_Servicio(Codigo_Servicio),
constraint fk_usuario foreign key (Usuario_Registro) references Maestro_Usuario(Usuario),
)
Go
create table Lugares_Muestreo(
Codigo_Muestreo int primary key not null,
Cod_Orden int not null,
Lugar_Muestreo varchar(200) not null,
Coordenada_Longitud varchar(100) not null,
Coordenada_Latitud varchar(100) not null,
Nombre_Punto varchar(100) not null,
constraint fk_solicitud foreign key (Cod_Orden) references Orden_Servicio(Codigo_Solicitud)
)
Go
create table Parametros_Lugar_Muestra(
Codigo_Lugar int primary key not null,
Cod_Orden int not null,
Lugar_Muestreo varchar(200) not null,
Coordenada_Longitud varchar(100) not null,
Coordenada_Latitud varchar(100) not null,
Nombre_Punto varchar(100) not null,
constraint fk_lugar foreign key (Codigo_Lugar) references Lugares_Muestreo(Codigo_Muestreo)
)
Go
create table Plan_Proyecto(
Codigo_Solicitud int primary key not null,
Fecha_Inicio datetime not null,
Dias_Monitoreo int not null,
Cantidad_Analistas int not null,
Monto_Viaticos int not null,
Precio_Final_Servicio int not null,
constraint fk_sol foreign key (Codigo_Solicitud) references Orden_Servicio(Codigo_Solicitud)
)
Go
create table Maestro_Equipo(
Codigo_Equipo varchar(100) primary key not null,
Descripcion_Equipo text not null,
Marca varchar(100) not null,
Modelo varchar(100) not null,
Serie varchar(100) not null,
Estado varchar(100) not null,
Ubicacion varchar(200) not null
)
Go
create table Equipos_Proyecto(
Codigo_Solicitud int primary key not null,
Equipo varchar(100) not null,
Cantidad int not null,
Matriz varchar(100) not null,
Fecha_Salida datetime not null,
Fecha_Retorno datetime not null,
constraint fk_sol_1 foreign key (Codigo_Solicitud) references Plan_Proyecto(Codigo_Solicitud),
constraint fk_equipo foreign key (Equipo) references Maestro_Equipo(Codigo_Equipo)
)
Go
create table Planilla_Analista(
Codigo_Analista varchar(100) primary key not null,
Tipo varchar(100) not null,
Grado_Instruccion varchar(100) not null,
Especialidad varchar(100) not null,
Fecha_Ingreso datetime not null,
Fecha_Cese datetime not null
)
Go
create table Analista_Proyecto(
Codigo_Solicitud int primary key not null,
Codigo_Analista varchar(100) not null,
Cargo varchar(100) not null,
Tarea_Asignada varchar(100) not null,
constraint fk_sol_2 foreign key (Codigo_Solicitud) references Plan_Proyecto(Codigo_Solicitud),
constraint fk_analista foreign key (Codigo_Analista) references Planilla_Analista(Codigo_Analista)
)
Go