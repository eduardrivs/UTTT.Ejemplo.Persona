﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UTTT.Ejemplo.Linq.Data.Entity
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DBPersona")]
	public partial class DcGeneralDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertCatSexo(CatSexo instance);
    partial void UpdateCatSexo(CatSexo instance);
    partial void DeleteCatSexo(CatSexo instance);
    partial void InsertDireccion(Direccion instance);
    partial void UpdateDireccion(Direccion instance);
    partial void DeleteDireccion(Direccion instance);
    partial void InsertPersona(Persona instance);
    partial void UpdatePersona(Persona instance);
    partial void DeletePersona(Persona instance);
    partial void InsertCatEstadoCivil(CatEstadoCivil instance);
    partial void UpdateCatEstadoCivil(CatEstadoCivil instance);
    partial void DeleteCatEstadoCivil(CatEstadoCivil instance);
    #endregion
		
		public DcGeneralDataContext() : 
				base(global::UTTT.Ejemplo.Linq.Data.Properties.Settings.Default.DBPersonaConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DcGeneralDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DcGeneralDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DcGeneralDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DcGeneralDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CatSexo> CatSexo
		{
			get
			{
				return this.GetTable<CatSexo>();
			}
		}
		
		public System.Data.Linq.Table<Direccion> Direccion
		{
			get
			{
				return this.GetTable<Direccion>();
			}
		}
		
		public System.Data.Linq.Table<Persona> Persona
		{
			get
			{
				return this.GetTable<Persona>();
			}
		}
		
		public System.Data.Linq.Table<CatEstadoCivil> CatEstadoCivil
		{
			get
			{
				return this.GetTable<CatEstadoCivil>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CatSexo")]
	public partial class CatSexo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _strValor;
		
		private string _strDescripcion;
		
		private EntitySet<Persona> _Persona;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnstrValorChanging(string value);
    partial void OnstrValorChanged();
    partial void OnstrDescripcionChanging(string value);
    partial void OnstrDescripcionChanged();
    #endregion
		
		public CatSexo()
		{
			this._Persona = new EntitySet<Persona>(new Action<Persona>(this.attach_Persona), new Action<Persona>(this.detach_Persona));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strValor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strValor
		{
			get
			{
				return this._strValor;
			}
			set
			{
				if ((this._strValor != value))
				{
					this.OnstrValorChanging(value);
					this.SendPropertyChanging();
					this._strValor = value;
					this.SendPropertyChanged("strValor");
					this.OnstrValorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strDescripcion", DbType="VarChar(50)")]
		public string strDescripcion
		{
			get
			{
				return this._strDescripcion;
			}
			set
			{
				if ((this._strDescripcion != value))
				{
					this.OnstrDescripcionChanging(value);
					this.SendPropertyChanging();
					this._strDescripcion = value;
					this.SendPropertyChanged("strDescripcion");
					this.OnstrDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CatSexo_Persona", Storage="_Persona", ThisKey="id", OtherKey="idCatSexo")]
		public EntitySet<Persona> Persona
		{
			get
			{
				return this._Persona;
			}
			set
			{
				this._Persona.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Persona(Persona entity)
		{
			this.SendPropertyChanging();
			entity.CatSexo = this;
		}
		
		private void detach_Persona(Persona entity)
		{
			this.SendPropertyChanging();
			entity.CatSexo = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Direccion")]
	public partial class Direccion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idPersona;
		
		private string _strCalle;
		
		private string _strNumero;
		
		private string _strColonia;
		
		private EntityRef<Persona> _Persona;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidPersonaChanging(int value);
    partial void OnidPersonaChanged();
    partial void OnstrCalleChanging(string value);
    partial void OnstrCalleChanged();
    partial void OnstrNumeroChanging(string value);
    partial void OnstrNumeroChanged();
    partial void OnstrColoniaChanging(string value);
    partial void OnstrColoniaChanged();
    #endregion
		
		public Direccion()
		{
			this._Persona = default(EntityRef<Persona>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idPersona", DbType="Int NOT NULL")]
		public int idPersona
		{
			get
			{
				return this._idPersona;
			}
			set
			{
				if ((this._idPersona != value))
				{
					if (this._Persona.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidPersonaChanging(value);
					this.SendPropertyChanging();
					this._idPersona = value;
					this.SendPropertyChanged("idPersona");
					this.OnidPersonaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strCalle", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strCalle
		{
			get
			{
				return this._strCalle;
			}
			set
			{
				if ((this._strCalle != value))
				{
					this.OnstrCalleChanging(value);
					this.SendPropertyChanging();
					this._strCalle = value;
					this.SendPropertyChanged("strCalle");
					this.OnstrCalleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strNumero", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strNumero
		{
			get
			{
				return this._strNumero;
			}
			set
			{
				if ((this._strNumero != value))
				{
					this.OnstrNumeroChanging(value);
					this.SendPropertyChanging();
					this._strNumero = value;
					this.SendPropertyChanged("strNumero");
					this.OnstrNumeroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strColonia", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strColonia
		{
			get
			{
				return this._strColonia;
			}
			set
			{
				if ((this._strColonia != value))
				{
					this.OnstrColoniaChanging(value);
					this.SendPropertyChanging();
					this._strColonia = value;
					this.SendPropertyChanged("strColonia");
					this.OnstrColoniaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Persona_Direccion", Storage="_Persona", ThisKey="idPersona", OtherKey="id", IsForeignKey=true)]
		public Persona Persona
		{
			get
			{
				return this._Persona.Entity;
			}
			set
			{
				Persona previousValue = this._Persona.Entity;
				if (((previousValue != value) 
							|| (this._Persona.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Persona.Entity = null;
						previousValue.Direccion.Remove(this);
					}
					this._Persona.Entity = value;
					if ((value != null))
					{
						value.Direccion.Add(this);
						this._idPersona = value.id;
					}
					else
					{
						this._idPersona = default(int);
					}
					this.SendPropertyChanged("Persona");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Persona")]
	public partial class Persona : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _strClaveUnica;
		
		private string _strNombre;
		
		private string _strAPaterno;
		
		private string _strAMaterno;
		
		private int _idCatSexo;
		
		private System.Nullable<System.DateTime> _dteFechaNacimiento;
		
		private System.Nullable<int> _intNumHermano;
		
		private System.Nullable<int> _idCatEstadoCivil;
		
		private string _strCurp;
		
		private EntitySet<Direccion> _Direccion;
		
		private EntityRef<CatSexo> _CatSexo;
		
		private EntityRef<CatEstadoCivil> _CatEstadoCivil;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnstrClaveUnicaChanging(string value);
    partial void OnstrClaveUnicaChanged();
    partial void OnstrNombreChanging(string value);
    partial void OnstrNombreChanged();
    partial void OnstrAPaternoChanging(string value);
    partial void OnstrAPaternoChanged();
    partial void OnstrAMaternoChanging(string value);
    partial void OnstrAMaternoChanged();
    partial void OnidCatSexoChanging(int value);
    partial void OnidCatSexoChanged();
    partial void OndteFechaNacimientoChanging(System.Nullable<System.DateTime> value);
    partial void OndteFechaNacimientoChanged();
    partial void OnintNumHermanoChanging(System.Nullable<int> value);
    partial void OnintNumHermanoChanged();
    partial void OnidCatEstadoCivilChanging(System.Nullable<int> value);
    partial void OnidCatEstadoCivilChanged();
    partial void OnstrCurpChanging(string value);
    partial void OnstrCurpChanged();
    #endregion
		
		public Persona()
		{
			this._Direccion = new EntitySet<Direccion>(new Action<Direccion>(this.attach_Direccion), new Action<Direccion>(this.detach_Direccion));
			this._CatSexo = default(EntityRef<CatSexo>);
			this._CatEstadoCivil = default(EntityRef<CatEstadoCivil>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strClaveUnica", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strClaveUnica
		{
			get
			{
				return this._strClaveUnica;
			}
			set
			{
				if ((this._strClaveUnica != value))
				{
					this.OnstrClaveUnicaChanging(value);
					this.SendPropertyChanging();
					this._strClaveUnica = value;
					this.SendPropertyChanged("strClaveUnica");
					this.OnstrClaveUnicaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strNombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strNombre
		{
			get
			{
				return this._strNombre;
			}
			set
			{
				if ((this._strNombre != value))
				{
					this.OnstrNombreChanging(value);
					this.SendPropertyChanging();
					this._strNombre = value;
					this.SendPropertyChanged("strNombre");
					this.OnstrNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strAPaterno", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strAPaterno
		{
			get
			{
				return this._strAPaterno;
			}
			set
			{
				if ((this._strAPaterno != value))
				{
					this.OnstrAPaternoChanging(value);
					this.SendPropertyChanging();
					this._strAPaterno = value;
					this.SendPropertyChanged("strAPaterno");
					this.OnstrAPaternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strAMaterno", DbType="VarChar(50)")]
		public string strAMaterno
		{
			get
			{
				return this._strAMaterno;
			}
			set
			{
				if ((this._strAMaterno != value))
				{
					this.OnstrAMaternoChanging(value);
					this.SendPropertyChanging();
					this._strAMaterno = value;
					this.SendPropertyChanged("strAMaterno");
					this.OnstrAMaternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCatSexo", DbType="Int NOT NULL")]
		public int idCatSexo
		{
			get
			{
				return this._idCatSexo;
			}
			set
			{
				if ((this._idCatSexo != value))
				{
					if (this._CatSexo.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCatSexoChanging(value);
					this.SendPropertyChanging();
					this._idCatSexo = value;
					this.SendPropertyChanged("idCatSexo");
					this.OnidCatSexoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dteFechaNacimiento", DbType="DateTime")]
		public System.Nullable<System.DateTime> dteFechaNacimiento
		{
			get
			{
				return this._dteFechaNacimiento;
			}
			set
			{
				if ((this._dteFechaNacimiento != value))
				{
					this.OndteFechaNacimientoChanging(value);
					this.SendPropertyChanging();
					this._dteFechaNacimiento = value;
					this.SendPropertyChanged("dteFechaNacimiento");
					this.OndteFechaNacimientoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_intNumHermano", DbType="Int")]
		public System.Nullable<int> intNumHermano
		{
			get
			{
				return this._intNumHermano;
			}
			set
			{
				if ((this._intNumHermano != value))
				{
					this.OnintNumHermanoChanging(value);
					this.SendPropertyChanging();
					this._intNumHermano = value;
					this.SendPropertyChanged("intNumHermano");
					this.OnintNumHermanoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCatEstadoCivil", DbType="Int")]
		public System.Nullable<int> idCatEstadoCivil
		{
			get
			{
				return this._idCatEstadoCivil;
			}
			set
			{
				if ((this._idCatEstadoCivil != value))
				{
					if (this._CatEstadoCivil.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCatEstadoCivilChanging(value);
					this.SendPropertyChanging();
					this._idCatEstadoCivil = value;
					this.SendPropertyChanged("idCatEstadoCivil");
					this.OnidCatEstadoCivilChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strCurp", DbType="NChar(18)")]
		public string strCurp
		{
			get
			{
				return this._strCurp;
			}
			set
			{
				if ((this._strCurp != value))
				{
					this.OnstrCurpChanging(value);
					this.SendPropertyChanging();
					this._strCurp = value;
					this.SendPropertyChanged("strCurp");
					this.OnstrCurpChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Persona_Direccion", Storage="_Direccion", ThisKey="id", OtherKey="idPersona")]
		public EntitySet<Direccion> Direccion
		{
			get
			{
				return this._Direccion;
			}
			set
			{
				this._Direccion.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CatSexo_Persona", Storage="_CatSexo", ThisKey="idCatSexo", OtherKey="id", IsForeignKey=true)]
		public CatSexo CatSexo
		{
			get
			{
				return this._CatSexo.Entity;
			}
			set
			{
				CatSexo previousValue = this._CatSexo.Entity;
				if (((previousValue != value) 
							|| (this._CatSexo.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CatSexo.Entity = null;
						previousValue.Persona.Remove(this);
					}
					this._CatSexo.Entity = value;
					if ((value != null))
					{
						value.Persona.Add(this);
						this._idCatSexo = value.id;
					}
					else
					{
						this._idCatSexo = default(int);
					}
					this.SendPropertyChanged("CatSexo");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CatEstadoCivil_Persona", Storage="_CatEstadoCivil", ThisKey="idCatEstadoCivil", OtherKey="id", IsForeignKey=true)]
		public CatEstadoCivil CatEstadoCivil
		{
			get
			{
				return this._CatEstadoCivil.Entity;
			}
			set
			{
				CatEstadoCivil previousValue = this._CatEstadoCivil.Entity;
				if (((previousValue != value) 
							|| (this._CatEstadoCivil.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CatEstadoCivil.Entity = null;
						previousValue.Persona.Remove(this);
					}
					this._CatEstadoCivil.Entity = value;
					if ((value != null))
					{
						value.Persona.Add(this);
						this._idCatEstadoCivil = value.id;
					}
					else
					{
						this._idCatEstadoCivil = default(Nullable<int>);
					}
					this.SendPropertyChanged("CatEstadoCivil");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Direccion(Direccion entity)
		{
			this.SendPropertyChanging();
			entity.Persona = this;
		}
		
		private void detach_Direccion(Direccion entity)
		{
			this.SendPropertyChanging();
			entity.Persona = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CatEstadoCivil")]
	public partial class CatEstadoCivil : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _strValor;
		
		private string _strDescripcion;
		
		private EntitySet<Persona> _Persona;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnstrValorChanging(string value);
    partial void OnstrValorChanged();
    partial void OnstrDescripcionChanging(string value);
    partial void OnstrDescripcionChanged();
    #endregion
		
		public CatEstadoCivil()
		{
			this._Persona = new EntitySet<Persona>(new Action<Persona>(this.attach_Persona), new Action<Persona>(this.detach_Persona));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strValor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string strValor
		{
			get
			{
				return this._strValor;
			}
			set
			{
				if ((this._strValor != value))
				{
					this.OnstrValorChanging(value);
					this.SendPropertyChanging();
					this._strValor = value;
					this.SendPropertyChanged("strValor");
					this.OnstrValorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_strDescripcion", DbType="VarChar(50)")]
		public string strDescripcion
		{
			get
			{
				return this._strDescripcion;
			}
			set
			{
				if ((this._strDescripcion != value))
				{
					this.OnstrDescripcionChanging(value);
					this.SendPropertyChanging();
					this._strDescripcion = value;
					this.SendPropertyChanged("strDescripcion");
					this.OnstrDescripcionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CatEstadoCivil_Persona", Storage="_Persona", ThisKey="id", OtherKey="idCatEstadoCivil")]
		public EntitySet<Persona> Persona
		{
			get
			{
				return this._Persona;
			}
			set
			{
				this._Persona.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Persona(Persona entity)
		{
			this.SendPropertyChanging();
			entity.CatEstadoCivil = this;
		}
		
		private void detach_Persona(Persona entity)
		{
			this.SendPropertyChanging();
			entity.CatEstadoCivil = null;
		}
	}
}
#pragma warning restore 1591
