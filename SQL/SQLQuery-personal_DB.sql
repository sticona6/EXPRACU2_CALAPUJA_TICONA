create database personal_DB;
go
use personal_DB;

go
CREATE TABLE Asingacion_Escolar
( 
	id_asignacion_escolar int identity(1,1) NOT NULL ,
	numero_hijos         int  NOT NULL ,
	monto_total          decimal(5,2)  NOT NULL ,
	id_tipo_asignacion   int  NOT NULL ,
	descripcion          varchar(200)  NULL ,
	fecha_emision        datetime  NULL ,
	id_personal          int  NULL 
)
go



ALTER TABLE Asingacion_Escolar
	ADD CONSTRAINT XPKAsingacion_Escolar PRIMARY KEY  CLUSTERED (id_asignacion_escolar ASC)
go



CREATE TABLE Compensacion
( 
	id_compensacion      int identity(1,1) NOT NULL ,
	motivo               varchar(150)  NULL ,
	fecha                datetime  NOT NULL ,
	id_tipo_compensacion int  NULL ,
	id_personal          int  NULL 
)
go



ALTER TABLE Compensacion
	ADD CONSTRAINT XPKcompensacion PRIMARY KEY  CLUSTERED (id_compensacion ASC)
go



CREATE TABLE Control_Horario
( 
	id_horario           int identity(1,1) NOT NULL ,
	hora_entrada         datetime  NOT NULL ,
	hora_salida          datetime  NULL ,
	horas_normales       datetime  NULL ,
	horas_extras         datetime  NULL ,
	horas_totales        datetime  NULL ,
	horas_incompletas    datetime  NULL ,
	fecha_hora           datetime  NOT NULL ,
	id_permiso           datetime  NULL ,
	conte_horas_extras   integer  NULL ,
	id_personal          int  NULL 
)
go



ALTER TABLE Control_Horario
	ADD CONSTRAINT XPKControl_Horario PRIMARY KEY  CLUSTERED (id_horario ASC)
go



CREATE TABLE Permiso
( 
	id_permiso           int identity(1,1) NOT NULL ,
	fecha_permiso        datetime  NULL ,
	fecha_solicitud      datetime  NULL ,
	gose_salario         varchar(1)  NULL ,
	id_personal          int  NULL ,
	tipo_personal        varchar(50)  NULL ,
	numero_permiso       int  NULL ,
	estado_permiso       varchar(1)  NULL ,
	tipo_permisos        char(1)  NULL ,
	motivo               varchar(250)  NULL ,
	obervacion           varchar(250)  NULL ,
	id_tipo_licencia     int  NULL 
)
go



ALTER TABLE Permiso
	ADD CONSTRAINT XPKPermiso PRIMARY KEY  CLUSTERED (id_permiso ASC)
go



CREATE TABLE Personal
( 
	id_personal          int identity(1,1) NOT NULL ,
	nombres_personal     varchar(100)  NULL ,
	apellidos_personal   varchar(100)  NULL ,
	DNI_personal         varchar(8)  NULL ,
	direccion_personal   varchar(100)  NULL ,
	tipo_personal        varchar(50)  NULL ,
	fecha_nacimiento     date  NULL
)
go



ALTER TABLE Personal
	ADD CONSTRAINT XPKPersonal PRIMARY KEY  CLUSTERED (id_personal ASC)
go



CREATE TABLE Prestamo
( 
	id_prestamo          int identity(1,1)  NOT NULL ,
	razon                varchar(250)  NULL ,
	descripcion          varchar(200)  NULL ,
	monto                decimal(6,2)  NULL ,
	fecha_prestamo       datetime  NULL ,
	fecha_pago           datetime  NULL ,
	id_tipo_pago_prestamo int  NULL ,
	id_personal          int  NULL 
)
go



ALTER TABLE Prestamo
	ADD CONSTRAINT XPKPrestamo PRIMARY KEY  CLUSTERED (id_prestamo ASC)
go



CREATE TABLE Tipo_Asignacion
( 
	id_tipo_asignacion   int identity(1,1) NOT NULL ,
	discapacidad         varchar(50)  NULL ,
	monto_mensual        decimal(5,2)  NULL 
)
go



ALTER TABLE Tipo_Asignacion
	ADD CONSTRAINT XPKTipo_Asignacion PRIMARY KEY  CLUSTERED (id_tipo_asignacion ASC)
go



CREATE TABLE Tipo_Compensacion
( 
	id_tipo_compensacion int  NOT NULL ,
	tipo                 varchar(50)  NOT NULL ,
	monto_compensacion   decimal(5,2)  NOT NULL 
)
go



ALTER TABLE Tipo_Compensacion
	ADD CONSTRAINT XPKtipo_compensacion PRIMARY KEY  CLUSTERED (id_tipo_compensacion ASC)
go



CREATE TABLE tipo_Licencia
( 
	id_tipo_licencia     int identity(1,1) NOT NULL ,
	tipo                 varchar(50)  NOT NULL ,
	descripcion          varchar(200)  NULL 
)
go



ALTER TABLE tipo_Licencia
	ADD CONSTRAINT XPKtipo_licencia PRIMARY KEY  CLUSTERED (id_tipo_licencia ASC)
go



CREATE TABLE Tipo_Pago_Prestamo
( 
	nombre_tipo_pago     varchar(100)  not null ,
	interes              int  NULL ,
	fecha_utlimo_dia_pago datetime NULL ,
	morosidad            int  NULL ,
	id_tipo_pago_prestamo int identity(1,1)  NOT NULL 
)
go



ALTER TABLE Tipo_Pago_Prestamo
	ADD CONSTRAINT XPKTipo_Pago_Prestamo PRIMARY KEY  CLUSTERED (id_tipo_pago_prestamo ASC)
go




ALTER TABLE Asingacion_Escolar
	ADD CONSTRAINT R_9 FOREIGN KEY (id_tipo_asignacion) REFERENCES Tipo_Asignacion(id_tipo_asignacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Asingacion_Escolar
	ADD CONSTRAINT R_20 FOREIGN KEY (id_personal) REFERENCES Personal(id_personal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Compensacion
	ADD CONSTRAINT R_3 FOREIGN KEY (id_tipo_compensacion) REFERENCES Tipo_Compensacion(id_tipo_compensacion)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Compensacion
	ADD CONSTRAINT R_18 FOREIGN KEY (id_personal) REFERENCES Personal(id_personal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Control_Horario
	ADD CONSTRAINT R_21 FOREIGN KEY (id_personal) REFERENCES Personal(id_personal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Permiso
	ADD CONSTRAINT R_5 FOREIGN KEY (id_tipo_licencia) REFERENCES tipo_Licencia(id_tipo_licencia)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Prestamo
	ADD CONSTRAINT R_10 FOREIGN KEY (id_tipo_pago_prestamo) REFERENCES Tipo_Pago_Prestamo(id_tipo_pago_prestamo)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go




ALTER TABLE Prestamo
	ADD CONSTRAINT R_19 FOREIGN KEY (id_personal) REFERENCES Personal(id_personal)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
go