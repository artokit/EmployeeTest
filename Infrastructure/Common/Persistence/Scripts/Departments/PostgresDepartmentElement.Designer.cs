﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infrastructure.Common.Persistence.Scripts.Departments {
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
    internal class PostgresDepartmentElement {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PostgresDepartmentElement() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Infrastructure.Common.Persistence.Scripts.Departments.PostgresDepartmentElement", typeof(PostgresDepartmentElement).Assembly);
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
        ///   Looks up a localized string similar to INSERT INTO departments (name, phone)
        ///VALUES (@name, @phone)
        ///    RETURNING 
        ///    id AS &quot;Id&quot;, 
        ///    name AS &quot;Name&quot;, 
        ///    phone AS &quot;Phone&quot;;
        ///.
        /// </summary>
        internal static string CreateDepartment {
            get {
                return ResourceManager.GetString("CreateDepartment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DELETE FROM departments
        ///WHERE id = @id;
        ///.
        /// </summary>
        internal static string DeleteDepartment {
            get {
                return ResourceManager.GetString("DeleteDepartment", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    id AS &quot;Id&quot;,
        ///    name AS &quot;Name&quot;,
        ///    phone AS &quot;Phone&quot;
        ///FROM departments;
        ///.
        /// </summary>
        internal static string GetAllDepartments {
            get {
                return ResourceManager.GetString("GetAllDepartments", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    id AS &quot;Id&quot;,
        ///    name AS &quot;Name&quot;,
        ///    phone AS &quot;Phone&quot;
        ///FROM departments
        ///WHERE id = @id;
        ///.
        /// </summary>
        internal static string GetDepartmentById {
            get {
                return ResourceManager.GetString("GetDepartmentById", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT
        ///    id AS &quot;Id&quot;,
        ///    name AS &quot;Name&quot;,
        ///    phone AS &quot;Phone&quot;
        ///FROM departments
        ///WHERE phone = @phone;
        ///.
        /// </summary>
        internal static string GetDepartmentByPhone {
            get {
                return ResourceManager.GetString("GetDepartmentByPhone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE departments
        ///SET name = @name, phone = @phone
        ///WHERE id = @id
        ///    RETURNING 
        ///    id AS &quot;Id&quot;, 
        ///    name AS &quot;Name&quot;, 
        ///    phone AS &quot;Phone&quot;;
        ///.
        /// </summary>
        internal static string UpdateDepartment {
            get {
                return ResourceManager.GetString("UpdateDepartment", resourceCulture);
            }
        }
    }
}
