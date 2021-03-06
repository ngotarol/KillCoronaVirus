USE [master]

GO

/****** Object:  Database [KillCoronaVirus]    Script Date: 16/07/2022 21:50:54 ******/
CREATE DATABASE [KillCoronaVirus]

GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KillCoronaVirus].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KillCoronaVirus] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [KillCoronaVirus] SET ANSI_NULLS ON 
GO
ALTER DATABASE [KillCoronaVirus] SET ANSI_PADDING ON 
GO
ALTER DATABASE [KillCoronaVirus] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [KillCoronaVirus] SET ARITHABORT ON 
GO
ALTER DATABASE [KillCoronaVirus] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KillCoronaVirus] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [KillCoronaVirus] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [KillCoronaVirus] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [KillCoronaVirus] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KillCoronaVirus] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KillCoronaVirus] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET RECOVERY FULL 
GO
ALTER DATABASE [KillCoronaVirus] SET  MULTI_USER 
GO
ALTER DATABASE [KillCoronaVirus] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KillCoronaVirus] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KillCoronaVirus] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KillCoronaVirus] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KillCoronaVirus] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KillCoronaVirus] SET QUERY_STORE = OFF
GO
USE [KillCoronaVirus]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Atencion]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atencion](
	[nroAtencion] [int] IDENTITY(1,1) NOT NULL,
	[datAtencion] [text] NOT NULL,
	[idPac] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[fecha_hora] [datetime] NOT NULL,
 CONSTRAINT [PK_Atencion] PRIMARY KEY CLUSTERED 
(
	[nroAtencion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalleOrden]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleOrden](
	[idDetOrden] [int] IDENTITY(1,1) NOT NULL,
	[nroOrden] [int] NOT NULL,
	[codExa] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_detalleOrden] PRIMARY KEY CLUSTERED 
(
	[idDetOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[detalleReceta]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[detalleReceta](
	[idDetReceta] [int] IDENTITY(1,1) NOT NULL,
	[nroReceta] [int] NOT NULL,
	[codFar] [int] NOT NULL,
	[dosis] [text] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_detalleReceta] PRIMARY KEY CLUSTERED 
(
	[idDetReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EspecialidadMedico]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EspecialidadMedico](
	[idUsuario] [int] NOT NULL,
	[codEsp] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especilidad]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especilidad](
	[codEsp] [int] IDENTITY(1,1) NOT NULL,
	[nomEsp] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Especilidad] PRIMARY KEY CLUSTERED 
(
	[codEsp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examen]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examen](
	[codExa] [int] IDENTITY(1,1) NOT NULL,
	[nomExa] [varchar](100) NOT NULL,
	[codTipo] [int] NOT NULL,
 CONSTRAINT [PK_Examen] PRIMARY KEY CLUSTERED 
(
	[codExa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Farmaco]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Farmaco](
	[codFar] [int] IDENTITY(1,1) NOT NULL,
	[nomFar] [varchar](50) NOT NULL,
	[concentracion] [float] NOT NULL,
	[codUOM] [int] NOT NULL,
	[codPresentacion] [int] NOT NULL,
 CONSTRAINT [PK_Farmaco] PRIMARY KEY CLUSTERED 
(
	[codFar] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orden]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orden](
	[nroOrden] [int] IDENTITY(1,1) NOT NULL,
	[nroAtencion] [int] NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idPac] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Orden] PRIMARY KEY CLUSTERED 
(
	[nroOrden] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paciente]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paciente](
	[idPac] [int] IDENTITY(1,1) NOT NULL,
	[rutPac] [int] NOT NULL,
	[nomPac] [varchar](50) NOT NULL,
	[apPaterno] [varchar](50) NOT NULL,
	[apMaterno] [varchar](50) NOT NULL,
	[fecNacPac] [date] NOT NULL,
	[codSexo] [int] NOT NULL,
 CONSTRAINT [PK_Paciente] PRIMARY KEY CLUSTERED 
(
	[idPac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PresentacionFarmaco]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PresentacionFarmaco](
	[codPresentacion] [int] IDENTITY(1,1) NOT NULL,
	[nomPresentacion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PresentacionFarmaco] PRIMARY KEY CLUSTERED 
(
	[codPresentacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Receta]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Receta](
	[nroReceta] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[idPac] [int] NOT NULL,
	[nroAtencion] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_Receta] PRIMARY KEY CLUSTERED 
(
	[nroReceta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol](
	[codRol] [int] IDENTITY(1,1) NOT NULL,
	[nomRol] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[codRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sexo]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sexo](
	[codSexo] [int] IDENTITY(1,1) NOT NULL,
	[nomSexo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Sexo] PRIMARY KEY CLUSTERED 
(
	[codSexo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoExamen]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoExamen](
	[codTipo] [int] IDENTITY(1,1) NOT NULL,
	[nomTipo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoExamen] PRIMARY KEY CLUSTERED 
(
	[codTipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadDeMedida]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadDeMedida](
	[codUOM] [int] IDENTITY(1,1) NOT NULL,
	[nomUOM] [varchar](50) NOT NULL,
	[UOM] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UnidadDeMedida] PRIMARY KEY CLUSTERED 
(
	[codUOM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 16/07/2022 21:50:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[rutUsuario] [int] NOT NULL,
	[nomUsuario] [varchar](50) NOT NULL,
	[apPaternoUsuario] [varchar](50) NOT NULL,
	[apMaternoUsuario] [varchar](50) NOT NULL,
	[codRol] [int] NOT NULL,
	[codSexo] [int] NOT NULL,
	[password] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Atencion]  WITH CHECK ADD  CONSTRAINT [FK_Atencion_Paciente] FOREIGN KEY([idPac])
REFERENCES [dbo].[Paciente] ([idPac])
GO
ALTER TABLE [dbo].[Atencion] CHECK CONSTRAINT [FK_Atencion_Paciente]
GO
ALTER TABLE [dbo].[Atencion]  WITH CHECK ADD  CONSTRAINT [FK_Atencion_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Atencion] CHECK CONSTRAINT [FK_Atencion_Usuarios]
GO
ALTER TABLE [dbo].[detalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_detalleOrden_Examen] FOREIGN KEY([codExa])
REFERENCES [dbo].[Examen] ([codExa])
GO
ALTER TABLE [dbo].[detalleOrden] CHECK CONSTRAINT [FK_detalleOrden_Examen]
GO
ALTER TABLE [dbo].[detalleOrden]  WITH CHECK ADD  CONSTRAINT [FK_detalleOrden_Orden] FOREIGN KEY([nroOrden])
REFERENCES [dbo].[Orden] ([nroOrden])
GO
ALTER TABLE [dbo].[detalleOrden] CHECK CONSTRAINT [FK_detalleOrden_Orden]
GO
ALTER TABLE [dbo].[detalleReceta]  WITH CHECK ADD  CONSTRAINT [FK_detalleReceta_Farmaco] FOREIGN KEY([codFar])
REFERENCES [dbo].[Farmaco] ([codFar])
GO
ALTER TABLE [dbo].[detalleReceta] CHECK CONSTRAINT [FK_detalleReceta_Farmaco]
GO
ALTER TABLE [dbo].[detalleReceta]  WITH CHECK ADD  CONSTRAINT [FK_detalleReceta_Receta] FOREIGN KEY([nroReceta])
REFERENCES [dbo].[Receta] ([nroReceta])
GO
ALTER TABLE [dbo].[detalleReceta] CHECK CONSTRAINT [FK_detalleReceta_Receta]
GO
ALTER TABLE [dbo].[EspecialidadMedico]  WITH CHECK ADD  CONSTRAINT [FK_EspecialidadMedico_Especilidad] FOREIGN KEY([codEsp])
REFERENCES [dbo].[Especilidad] ([codEsp])
GO
ALTER TABLE [dbo].[EspecialidadMedico] CHECK CONSTRAINT [FK_EspecialidadMedico_Especilidad]
GO
ALTER TABLE [dbo].[EspecialidadMedico]  WITH CHECK ADD  CONSTRAINT [FK_EspecialidadMedico_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[EspecialidadMedico] CHECK CONSTRAINT [FK_EspecialidadMedico_Usuarios]
GO
ALTER TABLE [dbo].[Examen]  WITH CHECK ADD  CONSTRAINT [FK_Examen_TipoExamen] FOREIGN KEY([codTipo])
REFERENCES [dbo].[TipoExamen] ([codTipo])
GO
ALTER TABLE [dbo].[Examen] CHECK CONSTRAINT [FK_Examen_TipoExamen]
GO
ALTER TABLE [dbo].[Farmaco]  WITH CHECK ADD  CONSTRAINT [FK_Farmaco_PresentacionFarmaco] FOREIGN KEY([codPresentacion])
REFERENCES [dbo].[PresentacionFarmaco] ([codPresentacion])
GO
ALTER TABLE [dbo].[Farmaco] CHECK CONSTRAINT [FK_Farmaco_PresentacionFarmaco]
GO
ALTER TABLE [dbo].[Farmaco]  WITH CHECK ADD  CONSTRAINT [FK_Farmaco_UnidadDeMedida] FOREIGN KEY([codUOM])
REFERENCES [dbo].[UnidadDeMedida] ([codUOM])
GO
ALTER TABLE [dbo].[Farmaco] CHECK CONSTRAINT [FK_Farmaco_UnidadDeMedida]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Atencion] FOREIGN KEY([nroAtencion])
REFERENCES [dbo].[Atencion] ([nroAtencion])
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Atencion]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Paciente] FOREIGN KEY([idPac])
REFERENCES [dbo].[Paciente] ([idPac])
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Paciente]
GO
ALTER TABLE [dbo].[Orden]  WITH CHECK ADD  CONSTRAINT [FK_Orden_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Orden] CHECK CONSTRAINT [FK_Orden_Usuarios]
GO
ALTER TABLE [dbo].[Paciente]  WITH CHECK ADD  CONSTRAINT [FK_Paciente_Sexo] FOREIGN KEY([codSexo])
REFERENCES [dbo].[Sexo] ([codSexo])
GO
ALTER TABLE [dbo].[Paciente] CHECK CONSTRAINT [FK_Paciente_Sexo]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Atencion] FOREIGN KEY([nroAtencion])
REFERENCES [dbo].[Atencion] ([nroAtencion])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Atencion]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Paciente] FOREIGN KEY([idPac])
REFERENCES [dbo].[Paciente] ([idPac])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Paciente]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Paciente1] FOREIGN KEY([idPac])
REFERENCES [dbo].[Paciente] ([idPac])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Paciente1]
GO
ALTER TABLE [dbo].[Receta]  WITH CHECK ADD  CONSTRAINT [FK_Receta_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Receta] CHECK CONSTRAINT [FK_Receta_Usuarios]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Rol] FOREIGN KEY([codRol])
REFERENCES [dbo].[Rol] ([codRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Rol]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Sexo] FOREIGN KEY([codSexo])
REFERENCES [dbo].[Sexo] ([codSexo])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Sexo]
GO
USE [master]
GO
ALTER DATABASE [KillCoronaVirus] SET  READ_WRITE 
GO

USE [KillCoronaVirus]
GO

-- Insercion de datos basicos
INSERT INTO [dbo].[Sexo]
           ([nomSexo])
     VALUES
           ('Femenino'),
		   ('Masculino'),
		   ('Otro')
GO
INSERT INTO [dbo].[Especilidad]
           ([nomEsp])
     VALUES
           ('Medicina Interna'),
		   ('Cardiologia'),
		   ('Ginecologia')
GO
INSERT INTO [dbo].[PresentacionFarmaco]
           ([nomPresentacion])
     VALUES
           ('Capsula'),
		   ('Jarabe'),
		   ('Comprimido'),
		   ('Solucion inyectable')
GO
INSERT INTO [dbo].[Rol]
           ([nomRol])
     VALUES
           ('Administrador'),
		   ('Medico')
GO
INSERT INTO [dbo].[TipoExamen]
           ([nomTipo])
     VALUES
           ('Laboratorio'),
		   ('Imagenologia'),
		   ('Anatomia patologica')
GO
INSERT INTO [dbo].[UnidadDeMedida]
           ([nomUOM],[UOM])
     VALUES
           ('Miligramo','mg'),
		   ('Gramo','g'),
		   ('Mililitro','ml')
GO