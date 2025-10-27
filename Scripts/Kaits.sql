CREATE DATABASE Kaits;

GO

USE Kaits;
GO

CREATE TABLE cliente(
	id_cliente INT IDENTITY(1,1) NOT NULL,
	nombres VARCHAR(150) NULL,
	apellido_paterno VARCHAR(150) NULL,
	apellido_materno VARCHAR(150) NULL,
	dni CHAR(8) NULL,
	fecha_creacion DATETIME NOT NULL,
	fecha_actualizacion DATETIME NULL,
	estado BIT NOT NULL,
	CONSTRAINT cliente_pk PRIMARY KEY (id_cliente),
	CONSTRAINT AK_dni UNIQUE (dni),
	CONSTRAINT CK_cliente_dni_len CHECK (LEN(dni)=8)
);

CREATE TABLE producto(
	id_producto INT IDENTITY(1,1) NOT NULL,
	descripcion VARCHAR(250) NULL,
	precio_unitario DECIMAL(15, 2) NULL,
	fecha_creacion DATETIME NOT NULL,
	fecha_actualizacion DATETIME NULL,
	estado BIT NOT NULL,
	CONSTRAINT producto_pk PRIMARY KEY (id_producto),
	CONSTRAINT CK_precio_unitario CHECK (precio_unitario >= 0)
);

CREATE TABLE pedido(
	id_pedido INT IDENTITY(1,1) NOT NULL,
	fecha DATETIME NULL,
	id_cliente INT NOT NULL,
	total DECIMAL(15,2) NOT NULL,
	fecha_creacion DATETIME NOT NULL,
	fecha_actualizacion DATETIME NULL,
	estado BIT NOT NULL,
	CONSTRAINT pedido_pk PRIMARY KEY (id_pedido),
	CONSTRAINT fk_pedido_cliente FOREIGN KEY (id_cliente)
		REFERENCES cliente(id_cliente)
);

CREATE TABLE detalle_pedido(
	id_detalle_pedido INT IDENTITY(1,1) NOT NULL,
	id_producto INT NOT NULL,
	id_pedido INT NOT NULL,
	cantidad INT NULL,
	subtotal DECIMAL(15, 2) NULL,
	fecha_creacion DATETIME NOT NULL,
	fecha_actualizacion DATETIME NULL,
	estado BIT NOT NULL,
	CONSTRAINT detalle_pedido_pk PRIMARY KEY (id_detalle_pedido),
	CONSTRAINT fk_detalle_pedido__producto FOREIGN KEY (id_producto)
		REFERENCES producto(id_producto),
	CONSTRAINT fk_detalle_pedido__pedido FOREIGN KEY (id_pedido)
		REFERENCES pedido(id_pedido),
	CONSTRAINT CK_cantidad CHECK (cantidad > 0),
	CONSTRAINT UQ_detalle_por_pedido UNIQUE (id_pedido, id_producto)
);