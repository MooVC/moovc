﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MooVC {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MooVC.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to The event must be provided..
        /// </summary>
        internal static string EmittedEventArgsEventRequired {
            get {
                return ResourceManager.GetString("EmittedEventArgsEventRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The exception must be provided..
        /// </summary>
        internal static string ExceptionEventArgsExceptionRequired {
            get {
                return ResourceManager.GetString("ExceptionEventArgsExceptionRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The message must be provided..
        /// </summary>
        internal static string ExceptionEventArgsMessageRequired {
            get {
                return ResourceManager.GetString("ExceptionEventArgsMessageRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The handler for each exception must be provided..
        /// </summary>
        internal static string ExceptionExtensionsExplodeHandlerRequired {
            get {
                return ResourceManager.GetString("ExceptionExtensionsExplodeHandlerRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The timer that manages the job queue must be provided..
        /// </summary>
        internal static string JobQueueTimerRequired {
            get {
                return ResourceManager.GetString("JobQueueTimerRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The mapping between the outter store and the inner store must be provided..
        /// </summary>
        internal static string MappedStoreInnerMappingRequired {
            get {
                return ResourceManager.GetString("MappedStoreInnerMappingRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The mapping between the inner store and the outter store must be provided..
        /// </summary>
        internal static string MappedStoreOutterMappingRequired {
            get {
                return ResourceManager.GetString("MappedStoreOutterMappingRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The inner store must be provided..
        /// </summary>
        internal static string MappedStoreStoreRequired {
            get {
                return ResourceManager.GetString("MappedStoreStoreRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from waiting for continuation to cease..
        /// </summary>
        internal static string ProcessorContinuationAbortFailure {
            get {
                return ResourceManager.GetString("ProcessorContinuationAbortFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from continuing its processing..
        /// </summary>
        internal static string ProcessorContinuationInteruppted {
            get {
                return ResourceManager.GetString("ProcessorContinuationInteruppted", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from starting..
        /// </summary>
        internal static string ProcessorStartFailure {
            get {
                return ResourceManager.GetString("ProcessorStartFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Processor {0} has encountered an issue that has prevented it from stopping..
        /// </summary>
        internal static string ProcessorStopFailure {
            get {
                return ResourceManager.GetString("ProcessorStopFailure", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The process cannot be started because another process has initiated a Start operation..
        /// </summary>
        internal static string StartOperationInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("StartOperationInvalidExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The process cannot be stopped because another process has initiated a Stop operation..
        /// </summary>
        internal static string StopOperationInvalidExceptionMessage {
            get {
                return ResourceManager.GetString("StopOperationInvalidExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A failure has occured during the handling of a timed event by {0}..
        /// </summary>
        internal static string TimedProcessorCallbackHandlingFailure {
            get {
                return ResourceManager.GetString("TimedProcessorCallbackHandlingFailure", resourceCulture);
            }
        }
    }
}
