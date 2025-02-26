﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Common.Persistence.Scripts.Passports {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class PostgresPassportElement {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PostgresPassportElement() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Common.Persistence.Scripts.Passports.PostgresPassportElement", typeof(PostgresPassportElement).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO passports (type, number, employee_id) VALUES (@type, @number, @employeeId) RETURNING id as &quot;Id&quot;.
        /// </summary>
        internal static string CreatePassport {
            get {
                return ResourceManager.GetString("CreatePassport", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT id AS &quot;Id&quot;,
        ///       type AS &quot;Type&quot;,
        ///       number AS &quot;Number&quot;,
        ///       employee_id AS &quot;EmployeeId&quot;
        ///FROM passports
        ///WHERE employee_id = @employeeId;.
        /// </summary>
        internal static string GetPassportByEmployeeId {
            get {
                return ResourceManager.GetString("GetPassportByEmployeeId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE passports
        ///SET type = @type,
        ///    number = @number,
        ///    employee_id = @employeeId
        ///WHERE id = @id
        ///    RETURNING id AS &quot;Id&quot;, 
        ///          type AS &quot;Type&quot;, 
        ///          number AS &quot;Number&quot;, 
        ///          employee_id AS &quot;EmployeeId&quot;;
        ///.
        /// </summary>
        internal static string UpdatePassport {
            get {
                return ResourceManager.GetString("UpdatePassport", resourceCulture);
            }
        }
    }
}
