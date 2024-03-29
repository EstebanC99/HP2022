﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CuidadosModernos.CrossCutting.Exceptions {
    using System;
    
    
    /// <summary>
    /// A strongly-typed resource class, for looking up localized strings, formatting them, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilderEx class via the ResXFileCodeGeneratorEx custom tool.
    // To add or remove a member, edit your .ResX file then rerun the ResXFileCodeGeneratorEx custom tool or rebuild your VS.NET project.
    // Copyright (c) Dmytro Kryvko 2006-2022 (http://dmytro.kryvko.googlepages.com/)
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("DMKSoftware.CodeGenerators.Tools.StronglyTypedResourceBuilderEx", "3.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
#if !SILVERLIGHT
    [global::System.Reflection.ObfuscationAttribute(Exclude=true, ApplyToMembers=true)]
#endif
    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces")]
    public partial class Messages {
        
        private static global::System.Resources.ResourceManager _resourceManager;
        
        private static object _internalSyncObject;
        
        private static global::System.Globalization.CultureInfo _resourceCulture;
        
        /// <summary>
        /// Initializes a Messages object.
        /// </summary>
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public Messages() {
        }
        
        /// <summary>
        /// Thread safe lock object used by this class.
        /// </summary>
        public static object InternalSyncObject {
            get {
                if (object.ReferenceEquals(_internalSyncObject, null)) {
                    global::System.Threading.Interlocked.CompareExchange(ref _internalSyncObject, new object(), null);
                }
                return _internalSyncObject;
            }
        }
        
        /// <summary>
        /// Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(_resourceManager, null)) {
                    global::System.Threading.Monitor.Enter(InternalSyncObject);
                    try {
                        if (object.ReferenceEquals(_resourceManager, null)) {
                            global::System.Threading.Interlocked.Exchange(ref _resourceManager, new global::System.Resources.ResourceManager("CuidadosModernos.CrossCutting.Exceptions.Messages", typeof(Messages).Assembly));
                        }
                    }
                    finally {
                        global::System.Threading.Monitor.Exit(InternalSyncObject);
                    }
                }
                return _resourceManager;
            }
        }
        
        /// <summary>
        /// Overrides the current thread's CurrentUICulture property for all
        /// resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return _resourceCulture;
            }
            set {
                _resourceCulture = value;
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'La Descripcion no puede estar vacía.'.
        /// </summary>
        public static string LaDescripcionNoPuedeEstarVacia {
            get {
                return ResourceManager.GetString(ResourceNames.LaDescripcionNoPuedeEstarVacia, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'La Fecha Hora de Fin es Requerida.'.
        /// </summary>
        public static string LaFechaHoraFinEsRequerida {
            get {
                return ResourceManager.GetString(ResourceNames.LaFechaHoraFinEsRequerida, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'La Fecha Hora de Inicio es Requerida.'.
        /// </summary>
        public static string LaFechaHoraInicioEsRequerida {
            get {
                return ResourceManager.GetString(ResourceNames.LaFechaHoraInicioEsRequerida, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'El campo {0} es requerido.'.
        /// </summary>
        public static string LaPropiedadEsRequerida {
            get {
                return ResourceManager.GetString(ResourceNames.LaPropiedadEsRequerida, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'Es requerido un Mail o Telefono.'.
        /// </summary>
        public static string MailOTelefonoRequeridos {
            get {
                return ResourceManager.GetString(ResourceNames.MailOTelefonoRequeridos, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'No hay ningun Turno por cumplir.'.
        /// </summary>
        public static string NoHayTurnosPorCumplir {
            get {
                return ResourceManager.GetString(ResourceNames.NoHayTurnosPorCumplir, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'La Empleada seleccionada no pudo encontrarse.'.
        /// </summary>
        public static string NoSeEncontroLaEmpleada {
            get {
                return ResourceManager.GetString(ResourceNames.NoSeEncontroLaEmpleada, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'No se encontro la Encargada para la Empleada.'.
        /// </summary>
        public static string NoSeEncontroLaEncargadaParaLaEmpleada {
            get {
                return ResourceManager.GetString(ResourceNames.NoSeEncontroLaEncargadaParaLaEmpleada, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'No se encontro la Frecuencia elegida.'.
        /// </summary>
        public static string NoSeEncontroLaFrecuenciaElegida {
            get {
                return ResourceManager.GetString(ResourceNames.NoSeEncontroLaFrecuenciaElegida, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'No se encontró la Tarea seleccionada.'.
        /// </summary>
        public static string NoSeEncontroLaTarea {
            get {
                return ResourceManager.GetString(ResourceNames.NoSeEncontroLaTarea, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'Usuario o contraseña incorrectos.'.
        /// </summary>
        public static string UsuarioOContraseniaIncorrectos {
            get {
                return ResourceManager.GetString(ResourceNames.UsuarioOContraseniaIncorrectos, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'Ya existe un usuario creado con nombre de usuario: {0}.'.
        /// </summary>
        public static string YaExisteUsuarioConNombreX {
            get {
                return ResourceManager.GetString(ResourceNames.YaExisteUsuarioConNombreX, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Looks up a localized string similar to 'Ya se registro una Empleada con DNI: {0}.'.
        /// </summary>
        public static string YaSeRegistroUnaEmpleadaConDNIX {
            get {
                return ResourceManager.GetString(ResourceNames.YaSeRegistroUnaEmpleadaConDNIX, _resourceCulture);
            }
        }
        
        /// <summary>
        /// Formats a localized string similar to 'El campo {0} es requerido.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string LaPropiedadEsRequeridaFormat(object arg0) {
            return string.Format(_resourceCulture, LaPropiedadEsRequerida, arg0);
        }
        
        /// <summary>
        /// Formats a localized string similar to 'Ya existe un usuario creado con nombre de usuario: {0}.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string YaExisteUsuarioConNombreXFormat(object arg0) {
            return string.Format(_resourceCulture, YaExisteUsuarioConNombreX, arg0);
        }
        
        /// <summary>
        /// Formats a localized string similar to 'Ya se registro una Empleada con DNI: {0}.'.
        /// </summary>
        /// <param name="arg0">An object (0) to format.</param>
        /// <returns>A copy of format string in which the format items have been replaced by the String equivalent of the corresponding instances of Object in arguments.</returns>
        public static string YaSeRegistroUnaEmpleadaConDNIXFormat(object arg0) {
            return string.Format(_resourceCulture, YaSeRegistroUnaEmpleadaConDNIX, arg0);
        }
        
        /// <summary>
        /// Lists all the resource names as constant string fields.
        /// </summary>
        public class ResourceNames {
            
            /// <summary>
            /// Stores the resource name 'LaDescripcionNoPuedeEstarVacia'.
            /// </summary>
            public const string LaDescripcionNoPuedeEstarVacia = "LaDescripcionNoPuedeEstarVacia";
            
            /// <summary>
            /// Stores the resource name 'LaFechaHoraFinEsRequerida'.
            /// </summary>
            public const string LaFechaHoraFinEsRequerida = "LaFechaHoraFinEsRequerida";
            
            /// <summary>
            /// Stores the resource name 'LaFechaHoraInicioEsRequerida'.
            /// </summary>
            public const string LaFechaHoraInicioEsRequerida = "LaFechaHoraInicioEsRequerida";
            
            /// <summary>
            /// Stores the resource name 'LaPropiedadEsRequerida'.
            /// </summary>
            public const string LaPropiedadEsRequerida = "LaPropiedadEsRequerida";
            
            /// <summary>
            /// Stores the resource name 'MailOTelefonoRequeridos'.
            /// </summary>
            public const string MailOTelefonoRequeridos = "MailOTelefonoRequeridos";
            
            /// <summary>
            /// Stores the resource name 'NoHayTurnosPorCumplir'.
            /// </summary>
            public const string NoHayTurnosPorCumplir = "NoHayTurnosPorCumplir";
            
            /// <summary>
            /// Stores the resource name 'NoSeEncontroLaEmpleada'.
            /// </summary>
            public const string NoSeEncontroLaEmpleada = "NoSeEncontroLaEmpleada";
            
            /// <summary>
            /// Stores the resource name 'NoSeEncontroLaEncargadaParaLaEmpleada'.
            /// </summary>
            public const string NoSeEncontroLaEncargadaParaLaEmpleada = "NoSeEncontroLaEncargadaParaLaEmpleada";
            
            /// <summary>
            /// Stores the resource name 'NoSeEncontroLaFrecuenciaElegida'.
            /// </summary>
            public const string NoSeEncontroLaFrecuenciaElegida = "NoSeEncontroLaFrecuenciaElegida";
            
            /// <summary>
            /// Stores the resource name 'NoSeEncontroLaTarea'.
            /// </summary>
            public const string NoSeEncontroLaTarea = "NoSeEncontroLaTarea";
            
            /// <summary>
            /// Stores the resource name 'UsuarioOContraseniaIncorrectos'.
            /// </summary>
            public const string UsuarioOContraseniaIncorrectos = "UsuarioOContraseniaIncorrectos";
            
            /// <summary>
            /// Stores the resource name 'YaExisteUsuarioConNombreX'.
            /// </summary>
            public const string YaExisteUsuarioConNombreX = "YaExisteUsuarioConNombreX";
            
            /// <summary>
            /// Stores the resource name 'YaSeRegistroUnaEmpleadaConDNIX'.
            /// </summary>
            public const string YaSeRegistroUnaEmpleadaConDNIX = "YaSeRegistroUnaEmpleadaConDNIX";
        }
    }
}
